﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000A70 RID: 2672
    public class PoisonGas : ModProjectile
	{
		// Token: 0x060031FF RID: 12799 RVA: 0x001B1094 File Offset: 0x001AF294
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.alpha = 255;
			base.projectile.scale = 1f;
			base.projectile.friendly = false;
            base.projectile.hostile = false;

            base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 10;
            base.projectile.ignoreWater = false;
            base.projectile.tileCollide = true;
        }
        private bool c = false;
		// Token: 0x06003200 RID: 12800 RVA: 0x001B1124 File Offset: 0x001AF324
		public override void AI()
		{
            if(!c)
            {
                projectile.velocity.Y += 1f;
            }
            else
            {
                projectile.velocity *= 0;
                base.projectile.hostile = true;
                int num = Dust.NewDust(new Vector2(base.projectile.position.X - 16, base.projectile.position.Y + 8), base.projectile.width * 3, base.projectile.height, mod.DustType("Poison"), 0f, -10f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2(base.projectile.position.X - 16, base.projectile.position.Y + 8), base.projectile.width * 3, base.projectile.height, mod.DustType("Poison"), 0f, -10f, 100, default(Color), 1.2f);
                Main.dust[num2].velocity *= 1.1f;
                Main.dust[num2].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;

                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
                if(Main.rand.Next(240) == 2)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 8f, 0, 0, mod.ProjectileType("PoisonGasBubble"), 140, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            if(projectile.wet)
            {
                projectile.timeLeft = 0;
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!c)
            {
                projectile.velocity *= 0;
                base.projectile.timeLeft = 600;
                c = true;
            }
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(20, projectile.timeLeft * 2, true);
            target.AddBuff(70, projectile.timeLeft / 2, true);
        }
        // Token: 0x06003201 RID: 12801 RVA: 0x001B11D8 File Offset: 0x001AF3D8
        public override void Kill(int timeLeft)
		{
        }
	}
}
