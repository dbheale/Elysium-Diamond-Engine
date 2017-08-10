using System.Collections.Generic;

namespace GameServer.GameTalent {
    public static class TalentManager {
        /// <summary>
        /// Hashset de todos os talentos.
        /// </summary>
        public static HashSet<TalentData> Talent { get; set; } = new HashSet<TalentData>();
    }
}