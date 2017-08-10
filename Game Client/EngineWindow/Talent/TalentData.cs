using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elysium_Diamond.Network;
using Lidgren.Network;

namespace Elysium_Diamond.EngineWindow {
    public static class TalentData {
        public static void ReceiveTalentData(NetIncomingMessage msg) {
            WindowTalent.Level = msg.ReadInt32();
            WindowTalent.Experience = msg.ReadInt64();
            WindowTalent.Points = msg.ReadInt32();
        }
    }
}
