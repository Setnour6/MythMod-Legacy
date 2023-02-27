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
            DisplayName.SetDefault("耀影之刃");
            Tooltip.SetDefault("由昼夜之辉交叠铸造而成");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 108;
            item.melee = true;
            item.width = 52;
            item.height = 58;
            item.useTime = 42;
            item.rare = 10;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 50000;
            item.scale = 1f;
            item.shoot = 706;
            item.shootSpeed = 16f;

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
                int num40 = Projectile.NewProjectile(hitbox.Center.X + v.X * 0.5f, hitbox.Center.Y + v.X * 0.5f, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.mod.ProjectileType("DarkLighting"), item.damage / 2, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 200;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(Main.rand.Next(3) == 1)
            {
                Vector2 v1 = target.Center;
                Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                v2 = v2 / v2.Length() * 2;
                Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1500 + Main.rand.Next(-200, 600), v2.X, v2.Y, mod.ProjectileType("DarkLightingBolt"), item.damage * 21, 0.5f, Main.myPlayer, v1.X, v1.Y);
                base.OnHitNPC(player, target, damage, knockBack, crit);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            switch (Main.rand.Next(1, 3))
            {
                case 1:
                    type = 706;
                    item.shootSpeed = 16f;
                    break;
                case 2:
                    type = 706;
                    item.shootSpeed = 16f;
                    break;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(675, 1);
            recipe.AddIngredient(3458, 12);
            recipe.requiredTile[0] = 412;
            recipe.SetResult(mod.ItemType("ShadowWithBright"), 1); 
            recipe.AddRecipe();
        }	
    }
}
