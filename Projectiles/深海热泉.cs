﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020007D0 RID: 2000
    public class 深海热泉 : ModProjectile
	{
		// Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("深海热泉");
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
		public override void SetDefaults()
		{
			base.projectile.width = 3;
			base.projectile.height = 3;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 4;
			base.projectile.extraUpdates = 420;
			base.projectile.timeLeft = 12000;
		}

		// Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
        public override void AI()
        {
            if (base.projectile.timeLeft <= 10960)
            {
                base.projectile.localAI[0] += 1f;
                if (base.projectile.localAI[0] > 25f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 vector = base.projectile.position;
                        vector -= base.projectile.velocity * ((float)i * 0.25f);
                        base.projectile.alpha = 255;
                        int num = Dust.NewDust(vector, 5, 5, 240, 0f, 0f, 0, default(Color), 2.2f);
                        Main.dust[num].position = vector;
                        Main.dust[num].scale = (float)Main.rand.Next(100, 160) * 0.013f;
                        Main.dust[num].velocity *= 0.95f;
                        Main.dust[num].noGravity = true;
                        int num1 = Dust.NewDust(vector, 5, 5, 55, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num1].position = vector;
                        Main.dust[num1].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                        Main.dust[num1].velocity *= 0.15f;
                        Main.dust[num1].noGravity = true;
                        base.projectile.localAI[0] = 0f;
                    }
                }
            }
        }
        //7
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 45; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 240, base.projectile.velocity.X * 0.999f, base.projectile.velocity.Y * 0.999f, 150, new Color(Main.DiscoR, 100, 255), 2.5f);
                Main.dust[num].noGravity = true;
                int num1 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 259, base.projectile.velocity.X * 0.985f, base.projectile.velocity.Y * 0.985f, 150, default(Color), 1.2f);
                Main.dust[num1].noGravity = true;
                int num2 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 262, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7, 150, default(Color), 2.5f);
                Main.dust[num2].noGravity = true;
            }
        }
        //8
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 45; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 240, base.projectile.velocity.X * 0.999f, base.projectile.velocity.Y * 0.999f, 150, new Color(Main.DiscoR, 100, 255), 2.5f);
                Main.dust[num].noGravity = true;
                int num1 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 259, base.projectile.velocity.X * 0.985f, base.projectile.velocity.Y * 0.985f, 150, default(Color), 1.2f);
                Main.dust[num1].noGravity = true;
                int num2 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 262, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7, 150, default(Color), 2.5f);
                Main.dust[num2].noGravity = true;
            }
        }
	}
}
