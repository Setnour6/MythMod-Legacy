using System;
using Terraria;
using Terraria.DataStructures;
using MythMod.UI.YinYangLife;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.IO;

using System.Collections.Generic;


using Terraria.IO;

using MythMod.UI.Stones;

namespace MythMod.Items.Corals
{
    public class TerrariaContinent : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("泰拉大陆");
            base.Tooltip.SetDefault("传送回主世界\n开发者专用");
        }
        public override void SetDefaults()
        {
            base.Item.width = 90;
            base.Item.height = 120;
            base.Item.useAnimation = 45;
            base.Item.useTime = 45;
            base.Item.useStyle = 4;
            base.Item.UseSound = SoundID.Item105;
            base.Item.consumable = false;
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if(false)
            {
                MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + "wld.bak"))
                {
                    mplayer.create = true;
                }
                else
                {
                    mplayer.create = false;
                }
                Main.menuMode = 10;
                Player.SavePlayer(Main.ActivePlayerFileData, false);
                WorldGen.SaveAndQuit();
                Main.ActiveWorldFileData = new WorldFileData("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                WorldGen.playWorld();
                player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-240.0f, 0.0f);
        }
    }
}
