namespace WorldServer.GameGuild {
    public partial class Guild {

        public static void UpdatePlayerStatus(int guildID, int playerID, MemberStatus status) {
            var member = FindGuildByID(guildID).FindMemberByID(playerID);
            member.Status = status;

            //atualiza o status e envia pra todos os jogadores conectados
        }

        public static void UpdateAnnouncement(int guildID, string announcement) {
            var guild = FindGuildByID(guildID);
            guild.Announcement = announcement;

            //atualiza o status e envia pra todos os jogadores conectados
        }

        public static void UpdatePlayerSelfIntro(int guildID, int playerID, string message) {
            GuildMember member = FindGuildByID(guildID).FindMemberByID(playerID);
            member.SelfIntro = message;

            //atualiza o status e envia pra todos os jogadores conectados
        }
    }
}
