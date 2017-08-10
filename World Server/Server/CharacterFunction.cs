using System.Drawing;
using WorldServer.Common;
using WorldServer.Database;
using WorldServer.Network;
using Elysium.Logs;
using Lidgren.Network;

namespace WorldServer.Server {
    public static class CharacterFunction {
        /// <summary>
        /// Envia o pré carregamento dos personagens.
        /// </summary>
        /// <param name="connection"></param>
        public static void RequestPreLoad(NetConnection connection) {
            var pData = Authentication.FindByConnection(connection);

            pData.Character = new Character[Constants.MaxCharacter];

            //Carrega os personagens (preload)
            CharacterDB.PreLoad(pData);

            //Envia o preload
            WorldPacket.PreLoad(pData);
        }

        /// <summary>
        /// Adiciona um novo personagem.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="data"></param>
        public static void CreateCharacter(NetConnection connection, NetIncomingMessage data) {
            //Se a crição de personagem não estiver ativa, envia mensagem de erro
            if (!Configuration.CharacterCreation) {
                WorldPacket.Message(connection, (short)PacketList.WS_CL_CharacterCreationDisabled);
                return;
            }

            //nome do personagem 
            var charactername = data.ReadString();
            //se encontrar nome nao permitido, envia mensagem de erro
            if (ProhibitedNames.Compare(charactername)) {
                WorldPacket.Message(connection, (short)PacketList.WS_CL_CharNameInUse);
                return;
            }

            // Se o nome existir no banco de dados, envia mensagem de erro
            if (CharacterDB.Exist(charactername)) {
                WorldPacket.Message(connection, (short)PacketList.WS_CL_CharNameInUse);
                return;
            }

            //encontra o usuário para adicionar as informações
            var pData = Authentication.FindByConnection(connection);

            var slot = data.ReadByte();
            var classe = data.ReadInt32();
            var gender = data.ReadByte();
            var sprite = data.ReadInt32();

            // Se não estiver dentro da sequencia correta, envia mensagem de erro
            if (slot >= 5) {
                WorldPacket.Message(connection, (short)PacketList.Error);
                return;
            }

            // Insere o personagem no banco de dados
            CharacterDB.InsertCharacter(pData.HexID, gender, classe, charactername, sprite, slot);

            // Carrega os personagens
            CharacterDB.PreLoad(pData);

            // Envia o PreLoad
            WorldPacket.PreLoad(pData);

            // Volta para a selação de personagens.
            WorldPacket.GameState(pData.HexID, GameState.Character);

            // Insere os items equipados
            CharacterDB.InsertEquippedItems(charactername, classe);

            // Insere os items no inventário
            CharacterDB.InsertInventoryItems(charactername, classe);
        }

        /// <summary>
        /// Exclusão. Primeira Etapa: Verifica e calcula o tempo de exclusão do personagem.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void DeleteCharacter(NetConnection connection, int slot) {
            // Se a exclusão de personagem não estiver ativa, envia mensagem de erro
            if (!Configuration.CharacterDelete) {
                WorldPacket.Message(connection, (short)PacketList.WS_CL_CharacterDeleteDisabled);
                return;
            }

            var pData = Authentication.FindByConnection(connection);
            var level = CharacterDB.GetLevel(pData.AccountID, slot);

            // Se o ocorrer algum erro, envia mensagem de erro
            // level -1, não encontrou dados do personagem
            if (level <= 0) {
                WorldPacket.Message(connection, (short)PacketList.Error);
                return;
            }

            //Se o level não estiver entre a faixa, envia mensagem de erro
            if (level < Configuration.CharacterDeleteMinLevel & level > Configuration.CharacterDeleteMaxLevel) {
                WorldPacket.Message(connection, (short)PacketList.WS_CL_InvalidLevelToDelete);
                return;
            }

            //obtem o horario da exclusão.
            var date = DeleteTime.GetDate(level);
            var name = CharacterDB.GetName(pData.AccountID, slot);
            var charID = CharacterDB.ID(name);

            CharacterDB.UpdateDeletionDate(pData.AccountID, charID, date);
            CharacterDB.UpdatePendingDeletion(pData.AccountID, charID, 1); //ativa a exclusão.
            DeleteTime.AddCharacter(charID, pData.AccountID, slot, date);

            WorldPacket.AlertDeleteCharacter(pData.Connection, DeleteTime.GetMinutes(level), date, (byte)slot);
        }

        /// <summary>
        /// Exclusão. Segunda Etapa: Deleta um personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charID"></param>
        /// <param name="slot"></param>
        public static void DeleteCharacter(int accountID, int charID, int slot) {
            Log.Write($"Character deleted: From: {accountID} Char: {charID} {CharacterDB.GetName(accountID, slot)}", Color.Magenta);

            var result = CharacterDB.Delete(accountID, slot);
            CharacterDB.Delete(charID, "DELETE FROM player_inventory WHERE char_id=?charID");
            CharacterDB.Delete(charID, "DELETE FROM player_equippeditem WHERE char_id=?charID");
            CharacterDB.Delete(charID, "DELETE FROM mail WHERE recipient_id=?charID");

            var pData = Authentication.FindByAccountID(accountID);

            //somente envia se o jogador estiver online.
            if (pData != null) {
                if (!result) {
                    WorldPacket.Message(pData.Connection, (short)PacketList.Error);
                    return;
                }

                //Carrega os personagens (preload)
                CharacterDB.PreLoad(pData);

                // Envia o PreLoad
                // pré carregamento do personagem, apenas informações básicas sprite, level, nome e classe (exibição na seleção de personagem).
                WorldPacket.PreLoad(pData);
                WorldPacket.Message(pData.Connection, (short)PacketList.WS_CL_CharacterDeleted);
            }
        }

        /// <summary>
        /// Verifica se há personagens para serem excluídos.
        /// </summary>
        /// <param name="pData"></param>
        public static void CheckPendingDeletion(PlayerData pData) {
            //adiciona personagens pendentes à lista de exclusão.
            for (int n = 0; n < Constants.MaxCharacter; n++) {
                if (pData.Character[n].PendingDeletion) {

                    //se o tempo já expirou, deleta o personagem e limpa o slot
                    if (pData.Character[n].IsPendingDateExpired()) {
                        Log.Write($"Character deleted: From: {pData.AccountID} Char: {pData.Character[n].ID} {CharacterDB.GetName(pData.AccountID, n)}", Color.Magenta);

                        CharacterDB.Delete(pData.AccountID, n);
                        pData.Character[n].Clear();
                        continue;
                    }

                    if (!DeleteTime.FindByID(pData.Character[n].ID))
                        DeleteTime.AddCharacter(pData.Character[n].ID, pData.AccountID, n, pData.Character[n].DeletionTime);
                }
            }
        }

        /// <summary>
        /// Remove a exclusão programada quando o personagem é usado.
        /// </summary>
        /// <param name="pData"></param>
        public static void RemovePendingDeletion(PlayerData pData) {
            if (pData.Character[pData.CharSlot].PendingDeletion) {
                pData.Character[pData.CharSlot].PendingDeletion = false;
                DeleteTime.CancelDelete(pData.Character[pData.CharSlot].ID);
                CharacterDB.UpdatePendingDeletion(pData.AccountID, pData.Character[pData.CharSlot].ID, 0); //desativa a exclusão
                WorldPacket.RemovePendingDelete(pData.Connection, (byte)pData.CharSlot);
            }
        }
    }
}
