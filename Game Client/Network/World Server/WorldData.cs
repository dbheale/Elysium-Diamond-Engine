using System;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.EngineWindow;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameClient;
using Elysium_Diamond.Resource;

namespace Elysium_Diamond.Network {
    public class WorldData {
        public static void PlayerCash(int cash) {
            Client.PlayerLocal.Cash = cash;
        }

        /// <summary>
        /// Carrega os personagens para exibição.
        /// </summary>
        /// <param name="data"></param>
        public static void PreLoad(NetIncomingMessage msg) {
            var classeIndex = 0;

            //limpa os dados dos personagens
            WindowCharacter.Clear();

            for (var index = 0; index < Configuration.MAX_CHARACTER; index++) {
                WindowCharacter.Player[index].Name = msg.ReadString();

                classeIndex = Classes.ClasseManager.GetIndexByID(msg.ReadInt32());

                WindowCharacter.Player[index].Class = Classes.ClasseManager.Classes[classeIndex].Name;
                WindowCharacter.Player[index].Sprite = msg.ReadInt16();
                WindowCharacter.Player[index].Level = msg.ReadInt32();
                WindowCharacter.Player[index].Pending = msg.ReadBoolean();

                if (WindowCharacter.Player[index].Pending) {
                    var hour = msg.ReadByte();
                    var minute = msg.ReadByte();
                    var second = msg.ReadByte();
                    WindowCharacter.Player[index].Time = new TimeSpan(hour, minute, second);
                }
            }
        }

        /// <summary>
        /// Recebe os dados do game server.
        /// </summary>
        /// <param name="data"></param>
        public static void GameServerData(NetIncomingMessage msg) {
            Configuration.IPAddress[(int)SocketEnum.GameServer] = new IPAddress(msg.ReadString(), msg.ReadInt32());
               
            NetworkSocket.Disconnect(SocketEnum.GameServer);
        }

        public static void AddTextChat(NetIncomingMessage msg) {
            var type = msg.ReadByte();
            var channel = msg.ReadByte();
            var from = msg.ReadString();
            var text = msg.ReadString();

            WindowChat.AddText(from, text, (MessageType)type);
        }

        public static void SetTimeToDelete(NetIncomingMessage msg) {
            var time = msg.ReadInt16();
            var slot = msg.ReadByte();
            var hour = msg.ReadByte();
            var minute = msg.ReadByte();
            var second = msg.ReadByte();

            WindowCharacter.Player[slot].Time = new TimeSpan(hour, minute, second);
            WindowCharacter.Player[slot].Pending = true;

            EngineMessageBox.Show($"The character will be deleted in {time} minute(s).");
        }

        public static void RemovePendingDelete(NetIncomingMessage msg) {
            var slot = msg.ReadByte();

            WindowCharacter.Player[slot].Pending = false;
        }
 
        #region PIN Function
        /// <summary>
        /// Mostra a mensagem de pin incorreto.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max_value"></param>
        /// <param name="time"></param>
        public static void IncorrectPin(NetIncomingMessage msg) {
            byte value = msg.ReadByte();
            byte max_value = msg.ReadByte();
            short time = msg.ReadInt16();

            EngineMessageBox.Enabled = true;
            EngineMessageBox.Show($"Incorrect! Attempts {value} out of {max_value}. Penalty: blocked for {time} minutes.");
        }

        /// <summary>
        /// Mostra a mensagem de pin incorreto.
        /// </summary>
        public static void IncorrectPin() {
            EngineMessageBox.Enabled = true;
            EngineMessageBox.Show($"Invalid Pin.");
        }

        /// <summary>
        /// Pede o registro de um novo ping.
        /// </summary>
        public static void RegisterPin() {
            EngineMessageBox.Enabled = true;
            EngineMessageBox.Show("Register the user pin.");
            WindowPin.Visible = true;
            WindowPin.ChangeState(PinState.Initialize);
        }

        /// <summary>
        /// Exibe ou esconde a janela de PIN.
        /// </summary>
        /// <param name="value"></param>
        public static void ShowPinWindow(bool value) {
            WindowPin.ChangeState(PinState.Login);
            WindowPin.Visible = value;
        }

        #endregion

        public static void ReceivePageItems(NetIncomingMessage msg) {
            var value = msg.ReadByte();
            WindowCash.MaxPage = (value > 0) ? value : (byte)1;
 
            var lenght = msg.ReadByte();

            for (var n = 0; n < 6; n++) WindowCash.Items[n].Clear();

            for (var n = 0; n < lenght; n++) {
                WindowCash.Items[n].CashItemID = msg.ReadInt32();
                var itemID = msg.ReadInt32();
                WindowCash.Items[n].Item = DataManager.FindItemByID(itemID);
                WindowCash.Items[n].Quantity = msg.ReadInt16();
                WindowCash.Items[n].Price = msg.ReadInt32();
                WindowCash.Items[n].Item.Durability = msg.ReadInt16();
                WindowCash.Items[n].Item.Enchant = msg.ReadInt16();
                WindowCash.Items[n].Item.Tradeable = msg.ReadByte();
                WindowCash.Items[n].Item.SoulBound = msg.ReadByte();

                for (var i = 0; i < 9; i++) { WindowCash.Items[n].Item.Slot[n] = msg.ReadInt16(); }      
            }

            WindowCash.WaitData = false;
        }

        public static void ReceiveItemDetail(NetIncomingMessage msg) {
            WindowCash.GiftEnabled = msg.ReadBoolean();
            WindowCash.BuyLimit = msg.ReadInt16();
            WindowCash.ExpireDays = msg.ReadInt32();

            WindowCash.PrepareItemText();

            WindowCash.WaitData = false;
            WindowCash.BuyItemVisible = true;
        }

        public static void ReceivePurchaseStatus(byte value) {
            var status = (CashItemPurchaseStatus)value;

            if (status == CashItemPurchaseStatus.InvalidName) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("The character name was not found");
                WindowCash.WaitData = false;
            }

            if (status == CashItemPurchaseStatus.NotEnoughCash) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("Insufficient amount for the purchase");
                WindowCash.WaitData = false;
            }

            if (status == CashItemPurchaseStatus.InvalidItem ) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("This item does not exist in the store");
                WindowCash.BuyItemVisible = false;
                WindowCash.WaitData = false;
                WindowCash.Quantity = 1;
            }

            if (status == CashItemPurchaseStatus.SuccessPurchase) {
                EngineMessageBox.Enabled = true;
                EngineMessageBox.Show("The item was successfully purchased");
                WindowCash.BuyItemVisible = false;
                WindowCash.WaitData = false;
                WindowCash.Quantity = 1;
            }
        }

        public static void ReceiveMailTitle(NetIncomingMessage msg) {
            var count = msg.ReadInt16();
            WindowMail.Messages.Clear();

            for (var n = 0; n < count; n++)
                WindowMail.Messages.Add(new WindowMail.Mail() { ID = msg.ReadInt32(), Read = msg.ReadBoolean(), Title = msg.ReadString() });
        }

        public static void ReceiveMail(NetIncomingMessage msg) {
            var index = WindowMail.SelectedMail;

            WindowMail.Messages[index].Sender = msg.ReadString();
            WindowMail.Messages[index].Title = msg.ReadString();
            WindowMail.Messages[index].Text = msg.ReadString();
            WindowMail.Messages[index].Currency = msg.ReadInt64();

            WindowMail.Item.ID = msg.ReadInt32();

            if (WindowMail.Item.ID > 0) {
                WindowMail.IconID = DataManager.FindItemByID(WindowMail.Item.ID).IconID;

                WindowMail.Item.Quantity = msg.ReadInt16();
                WindowMail.Item.Durability = msg.ReadInt16();
                WindowMail.Item.Enchant = msg.ReadInt16();
                WindowMail.Item.Tradeable = msg.ReadByte();
                WindowMail.Item.SoulBound = msg.ReadByte();
               // WindowMail.Item.Slots = msg.ReadString();
                WindowMail.Item.Expire = msg.ReadByte();

                if (WindowMail.Item.Expire > 0) {
                    var day = msg.ReadByte();
                    var month = msg.ReadByte();
                    var year = msg.ReadByte();
                    var hour = msg.ReadByte();
                    var minute = msg.ReadByte();
                    var second = msg.ReadByte();

                    WindowMail.Item.ExpireDate = new DateTime(year, month, day, hour, minute, second);
                }
            }

            WindowMail.Messages[index].Read = true;
            WindowMail.ReadMail = true;
        }
    }
}
