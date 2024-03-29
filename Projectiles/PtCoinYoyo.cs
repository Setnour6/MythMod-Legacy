﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	public class PtCoinYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("铂金币悠悠球");
        }
        public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 550f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 550f, 16f);
            if ((int)(Main.time / 5f) % 15 == 0)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 80) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("PtCoin"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/铂金币悠悠球light"), base.projectile.Center - Main.screenPosition, null, new Color(0.4f, 0.4f, 0.4f, 0), 0, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            X = 100;
            for (int j = 0; j < 5; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("PtCoin"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            X = 100;
            return false;
		}
	}
}
