using System;
using System.Collections.Generic;
using System.Linq;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameClient;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Maps;
using System.Text;
using SharpDX;
using SharpDX.Direct3D9;

namespace Elysium_Diamond.EngineWindow {
    public static class WindowGame {
        const int MAX_INVENTORY = 56;

        /// <summary>
        /// Barra de experiência.
        /// </summary>
        public static EngineExperienceBar ExperienceBar { get; set; }

        public static EngineShortcut Shortcut { get; set; }

        
        public static void Initialize() {
            ExperienceBar = new EngineExperienceBar("bar", 519, 36);
            ExperienceBar.Position = new Point(245, 639);

            Shortcut = new EngineShortcut();
            Shortcut.Position = new Point(285, 600);

            WindowChat.Initialize();
            WindowStatus.Initialize();
            WindowOption.Initialize();
            WindowInventory.Initialize();


            //WindowGuild.Initialize();
        }

        public static void Draw() {

            Client.PlayerLocal.Character.Draw();

            EngineFont.DrawText(Client.PlayerLocal.Character.Coordinate.X + " " + Client.PlayerLocal.Character.Coordinate.Y, 700, 100, Color.White, EngineFontStyle.Regular);

            foreach (var character in MapManager.Player) character.Draw();
        
            foreach(var npc in MapManager.Npc) npc.Draw();  

            WindowOption.Draw();

            WindowChat.Draw();

            WindowInventory.Draw();

            WindowCash.Draw();

            Shortcut.Draw();

            ExperienceBar.Percentage = Convert.ToInt32(((double)Client.PlayerLocal.Exp / (double)ExperienceManager.Experience[Client.PlayerLocal.Level + 1]) * 100);
            ExperienceBar.Draw(Client.PlayerLocal.Exp + "/" + ExperienceManager.Experience[Client.PlayerLocal.Level + 1]);
            ExperienceBar.Draw();

            ////  ShortCut.Draw(285, 521);
            //     ShortCut.Draw(285, 560);
            //    ShortCut.Draw(285, 600);

            WindowSkill.Draw();

            WindowTalent.Draw();

            WindowStatus.Draw();

            WindowViewItem.Draw();

            if (WindowSelectedItem.ObjectID > 0) {
                WindowSelectedItem.Position = new Point(EngineCore.MousePosition.X - 20, EngineCore.MousePosition.Y - 20);
                WindowSelectedItem.Draw();
            }
        }
    }
}