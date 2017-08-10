using System.Collections.Generic;
using System.Linq;

namespace WorldServer.GameGuild {
    public sealed partial class Guild {
        public HashSet<GuildMember> Member { get; set; }

        /// <summary>
        /// Número de identificação
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID do fundador.
        /// </summary>
        public int OwnerID { get; set; }

        /// <summary>
        /// Nome do fundador.
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Nome de guild.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Anúncio.
        /// </summary>
        public string Announcement { get; set; }

        /// <summary>
        /// Quantidade de jogadores online.
        /// </summary>
        public int OnlineMembers { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public Guild() {
            Member = new HashSet<GuildMember>();
        }

        /// <summary>
        /// Realiza uma busca pelo id de personagem.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public GuildMember FindMemberByID(int pID) {
            var find_value = from mData in Member
                          where mData.ID.CompareTo(pID) == 0
                          select mData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de personagem.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public GuildMember FindMemberByName(int pName) {
            var find_value = from mData in Member
                             where mData.Name.CompareTo(pName) == 0
                             select mData;

            return find_value.FirstOrDefault();
        }

        /// <summary>
        /// Verifica os jogadores que estão conectados.
        /// </summary>
        public void VerifyMembers() {
            var count = 0;

            foreach (var mData in Member) {
                if (mData.Status == (GuildMemberStatus.Online | GuildMemberStatus.Busy))
                    count++;
            }

            OnlineMembers = count;
        }
    }
}