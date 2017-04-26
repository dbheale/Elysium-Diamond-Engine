using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace TextEditor {
    public class EditorData {
        public static HashSet<NpcData> Npc;

        public static Experience Experience;
        
        public static NpcData FindNpcByID(int uniqueID) {
            var find = from npc in Npc
                       where npc.ID.CompareTo(uniqueID) == 0
                       select npc;

            return find.FirstOrDefault();
        }
    }
}
