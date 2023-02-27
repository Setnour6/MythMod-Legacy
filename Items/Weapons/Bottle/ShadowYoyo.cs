using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.Bottle
{
    public class ShadowYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            DisplayName.SetDefault("封印球");
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("ShadowYoyo");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.knockBack = 0.2f;
            item.damage = 20;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 3;
        }
    }
}
