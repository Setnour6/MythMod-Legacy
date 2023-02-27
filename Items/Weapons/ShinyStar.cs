using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class ShinyStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("魔星之辉");
            base.Tooltip.SetDefault("降下魔化落星");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 37;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 60;
            item.rare = 2;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 9;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("MagicStar");
            item.shootSpeed = 11f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float X = Main.rand.NextFloat(-250, 250);
            float Y = Main.rand.NextFloat(-250, 250);
            Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
            v2 = v2 / v2.Length() * 13f;
            Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, type, (int)damage * 2, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EvilScaleDust", 24);
            recipe.AddIngredient(65, 1);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
