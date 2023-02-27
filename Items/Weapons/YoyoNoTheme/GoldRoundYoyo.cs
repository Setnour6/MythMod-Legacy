using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class GoldRoundYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "金边球");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public static short GetGlowMask = 0;
        private int o = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("GoldRoundYoyo");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.knockBack = 0.2f;
            item.damage = 280;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 11;
            ItemID.Sets.Yoyo[base.item.type] = true;
        }
    }
}
