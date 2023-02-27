using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.TreasureBag
{
    public class StarJellyFishTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Treasure Bag");
            base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.maxStack = 999;
            base.Item.consumable = true;
            base.Item.width = 24;
            base.Item.height = 24;
            base.Item.rare = 9;
            base.Item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("BloodyJellyfishStaff").Type, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("CarmineBlade").Type, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("GlowingJellyStaff").Type, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("LightOfFrozenSea").Type, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("RedGlassSpear").Type, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("TentacleBow").Type, 1);
            }
        }
    }
}
