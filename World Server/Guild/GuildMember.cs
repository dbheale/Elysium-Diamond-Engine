namespace WorldServer.GameGuild {
    public struct GuildMember {
        /// <summary>
        /// ID de personagem.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Introdução.
        /// </summary>
        public string SelfIntro { get; set; }

        /// <summary>
        /// Estado do personagem.
        /// </summary>
        public MemberStatus Status { get; set; }
    }
}
