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

namespace MythMod.Items.Weapons
{
    public class ShadowWithBright : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("耀影之刃");
            // Tooltip.SetDefault("由昼夜之辉交叠铸造而成");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 108;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 52;
            Item.height = 58;
            Item.useTime = 42;
            Item.rare = 10;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 50000;
            Item.scale = 1f;
            Item.shoot = 706;
            Item.shootSpeed = 16f;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 1)
            {
                float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                Vector2 v = player.Center - new Vector2(hitbox.Center.X, hitbox.Center.Y);
                int num40 = Projectile.NewProjectile(hitbox.Center.X + v.X * 0.5f, hitbox.Center.Y + v.X * 0.5f, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("DarkLighting").Type, Item.damage / 2, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 200;
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(Main.rand.Next(3) == 1)
            {
                Vector2 v1 = target.Center;
                Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                v2 = v2 / v2.Length() * 2;
                Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1500 + Main.rand.Next(-200, 600), v2.X, v2.Y, Mod.Find<ModProjectile>("DarkLightingBolt").Type, Item.damage * 21, 0.5f, Main.myPlayer, v1.X, v1.Y);
                base.OnHitNPC(player, target, damage, knockBack, crit);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    type = 706;
                    Item.shootSpeed = 16f;
                    break;
                case 2:
                    type = 706;
                    Item.shootSpeed = 16f;
                    break;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("ShadowWithBright").Type, 1);
            recipe.AddIngredient(675, 1);
            recipe.AddIngredient(3458, 12);
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }	
    }
}
