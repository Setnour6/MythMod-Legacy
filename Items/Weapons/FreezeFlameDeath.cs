using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
namespace MythMod.Items.Weapons
{
    public class FreezeFlameDeath : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰火寂灭");
            // Tooltip.SetDefault("力量足以震动地壳");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 400;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 52;
            Item.height = 62;
            Item.useTime = 18;
            Item.rare = 11;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 22;
            Item.value = 1000000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("MoonPlus").Type;
            Item.shootSpeed = 12f;
        }
        private int a = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (a % 3 == 0)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("DeathKnife").Type, (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            if (a % 3 == 1)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("MoonPlus").Type, (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            if (a % 3 == 2)
            {
                int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("FreezeKnife").Type, (int)((double)damage * 2.4d), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            }
            a += 1;
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1327, 1);
            modRecipe.AddIngredient(1306, 1);
            modRecipe.AddIngredient(null, "CrimsonMoon", 1);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
