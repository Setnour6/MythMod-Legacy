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
    public class WhiteLazarSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("白激光刃");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        private int o = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 150;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 88;
            Item.height = 88;
            Item.useTime = 42;
            Item.rare = 6;
            Item.useAnimation = 42;
            Item.useStyle = 1;
            Item.knockBack = 5.0f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 100000;
            Item.scale = 1f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (o == 0)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WhiteLazarSwordHead").Type, (int)(Item.damage * player.GetDamage(DamageClass.Melee)), Item.knockBack, Main.myPlayer, 0f, 0f);
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
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 100 / 255f, 100 / 255f, 100 / 255f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(3768, 1);
            recipe.AddIngredient(null, "LazarBattery", 9);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
