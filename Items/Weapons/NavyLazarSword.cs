using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class NavyLazarSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("海蓝激光刃");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        private int o = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 150;
            item.melee = true;
            item.width = 88;
            item.height = 88;
            item.useTime = 42;
            item.rare = 6;
            item.useAnimation = 42;
            item.useStyle = 1;
            item.knockBack = 5.0f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 100000;
            item.scale = 1f;
            item.noMelee = true;
            item.noUseGraphic = true;
        }
        public override bool UseItem(Player player)
        {
            if (o == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("NavyLazarSwordHead"), (int)(item.damage * player.meleeDamage), item.knockBack, Main.myPlayer, 0f, 0f);
                o += 1;
            }
            if (!Main.mouseLeft)
            {
                o = 0;
            }
            return base.UseItem(player);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2((float)hitbox.X, (float)hitbox.Y), 0 / 255f, 12 / 255f, 220 / 255f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NavyCrystalSword", 1);
            recipe.AddIngredient(null, "LazarBattery", 9);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
    }
}
