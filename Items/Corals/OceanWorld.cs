using System;
using Terraria;
using Terraria.DataStructures;
//using MythMod.UI.YinYangLife;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Terraria.IO;

//using MythMod.UI.Stones;

namespace MythMod.Items.Corals
{
    public class OceanWorld : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("海洋世界");
            base.Tooltip.SetDefault("传送到泰拉大陆边缘");
        }
        public override void SetDefaults()
        {
            base.item.width = 90;
            base.item.height = 120;
            base.item.useAnimation = 5;
            base.item.useTime = 5;
            base.item.useStyle = 4;
            base.item.UseSound = SoundID.Item105;
            base.item.consumable = false;
        }
        public override bool UseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (Main.worldName != mplayer.worldnm)
            {
                Dictionary<string, string> worlddefaults = new Dictionary<string, string>();
                Main.menuMode = 10;

                int nums = 200;
                FieldInfo field = typeof(WorldFileData).GetField("WorldSizeY", BindingFlags.Instance | BindingFlags.Public);
                field.SetValue(Main.ActiveWorldFileData, nums);
                FieldInfo field2 = typeof(WorldGen).GetField("lastMaxTilesY", BindingFlags.Static | BindingFlags.NonPublic);
                field2.SetValue(null, nums);
                MethodInfo method = typeof(Main).GetMethod("InitMap", BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(Main.instance, null);

                Player.SavePlayer(Main.ActivePlayerFileData, false);
                WorldGen.SaveAndQuit();
                if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + "wld.bak"))
                {
                    mplayer.create = true;
                }
                else
                {
                    mplayer.create = false;
                }
                if (Main.expertMode)
                {
                    mplayer.wExpert = true;
                }
                if (MythWorld.Myth)
                {
                    mplayer.wMyth = true;
                }
                if (MythWorld.downedHYFY && mplayer.worldnm != Main.worldName)
                {
                    mplayer.worldnm = Main.worldName;
                }
                //if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + ".wld"))
                //{
                Main.ActiveWorldFileData = new WorldFileData("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                //}
                //else
                //{
                //WorldFileData.FromInvalidWorld("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                //}
                WorldGen.playWorld();
                player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
                MythWorld.WorldType = 1;
                //Stones.Open = false;
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "MysteriesPearl", 30);
            modRecipe.AddIngredient(null, "YellowSpongeChannel", 40);
            modRecipe.AddIngredient(null, "PurpleSpongeChannel", 40);
            modRecipe.AddIngredient(null, "GorgonianPiece", 40);
            modRecipe.AddIngredient(null, "BlueTreeCoral", 8);
            modRecipe.AddIngredient(null, "RedCoral", 8);
            modRecipe.requiredTile[0] = 134;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
