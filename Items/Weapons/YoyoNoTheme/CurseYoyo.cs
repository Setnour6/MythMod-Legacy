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
    public class CurseYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "诅咒焰球");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "用烈焰熔化抑郁\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
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
            item.shoot = mod.ProjectileType("CurseYoyo");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.knockBack = 0.2f;
            item.damage = 30;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 3;
            ItemID.Sets.Yoyo[base.item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CurseflameScale"), 5);
            recipe.AddIngredient(3279, 1); 
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
    }
}
