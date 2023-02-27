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
            base.Item.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            base.Item.width = 32;
            base.Item.height = 32;
            base.Item.useTime = 25;
            base.Item.useAnimation = 25;
            base.Item.useTurn = true;
            base.Item.useStyle = 1;
            base.Item.value = 5000;
            base.Item.UseSound = SoundID.Item1;
            base.Item.autoReuse = true;
            base.Item.rare = 6;
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
