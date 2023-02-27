﻿using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class MESword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MESword");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "电磁刃");
            Tooltip.SetDefault("MESword");
            Tooltip.AddTranslation(GameCulture.Chinese, "");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 200;
            item.melee = true;
            item.width = 66;
            item.height = 72;
            item.useTime = 24;
            item.rare = 11;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
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
                int num40 = Projectile.NewProjectile(hitbox.Center.X + v.X * 0.5f, hitbox.Center.Y + v.X * 0.5f, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.mod.ProjectileType("Lighting2"), item.damage * 5, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 240;
            }
            if (Main.rand.Next(15) == 1)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(hitbox.Center.X, hitbox.Center.Y, v.X, v.Y, mod.ProjectileType("GoldPosiDust"), item.damage, 0.5f, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(92, 143);
            }
            if (Main.rand.Next(48) == 1)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(hitbox.Center.X, hitbox.Center.Y, v.X, v.Y, 254, item.damage, 0.5f, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(210, 367);
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for(int i = 0;i < 4;i++)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(target.Center.X, target.Center.Y, v.X, v.Y, 254, item.damage, 0.5f, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(210, 367);
            }
            for (int i = 0; i < 4; i++)
            {
                float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                Vector2 v = player.Center - new Vector2(target.Center.X, target.Center.Y);
                int num40 = Projectile.NewProjectile(target.Center.X + v.X * 0.5f, target.Center.Y + v.X * 0.5f, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.mod.ProjectileType("Lighting2"), item.damage * 5, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 300;
            }
            for (int i = 0; i < 8; i++)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(target.Center.X, target.Center.Y, v.X, v.Y, mod.ProjectileType("GoldPosiDust"), item.damage, 0.5f, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(92, 143);
            }
        }
    }
}