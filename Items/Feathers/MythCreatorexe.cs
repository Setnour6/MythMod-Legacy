using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;

namespace MythMod.Items.Feathers
{
    public class MythCreatorexe : ModItem
    {
        private bool num = true;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("MythCreator.exe");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "MythCreator.exe");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "地形生成器\n警告:非开发人员勿用\n可能导致地图存档毁坏和游戏崩溃");
        }
        public override void SetDefaults()
        {
            base.item.melee = false;
            base.item.width = 32;
            base.item.height = 32;
            base.item.useTime = 25;
            base.item.useAnimation = 25;
            base.item.useTurn = true;
            base.item.useStyle = 1;
            base.item.value = 5000;
            base.item.UseSound = SoundID.Item1;
            base.item.autoReuse = true;
            base.item.rare = 6;
        }
        public override void AddRecipes()
        {

        }
        public override bool AltFunctionUse(Player player)
        { return true; }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.LanternMoon)
            {
                mplayer.LanternMoonPoint = 100001;
            }
            return base.CanUseItem(player);
        }
    }
}
