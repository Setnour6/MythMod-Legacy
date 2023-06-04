using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class ShinyStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("魔星之辉");
            // base.Tooltip.SetDefault("降下魔化落星");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 37;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 36;
            Item.height = 36;
            Item.useTime = 60;
            Item.rare = 2;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 5.0f ;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 9;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("MagicStar").Type;
            Item.shootSpeed = 11f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "EvilScaleDust", 24);
            recipe.AddIngredient(65, 1);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
