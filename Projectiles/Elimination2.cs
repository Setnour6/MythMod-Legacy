using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020007D0 RID: 2000
    public class Elimination2 : ModProjectile
	{
		// Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("代码杀射线");
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 10;
			base.projectile.extraUpdates = 100;
			base.projectile.timeLeft = 300;
		}

		// Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
		public override void AI()
		{
			base.projectile.localAI[1] += 1f;
			if (base.projectile.localAI[1] >= 21f && base.projectile.owner == Main.myPlayer)
			{
				base.projectile.localAI[1] = 0f;
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.X * 0.35f, base.projectile.velocity.Y * 0.35f, base.mod.ProjectileType("TerraOrb"), (int)((double)base.projectile.damage * 0.699999988079071), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
			}
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 9f)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = base.projectile.position;
					vector -= base.projectile.velocity * ((float)i * 0.25f);
					base.projectile.alpha = 255;
					int num = Dust.NewDust(vector, 1, 1, 183, 0f, 0f, 0, default(Color), 1.5f);
					Main.dust[num].position = vector;
					Main.dust[num].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num].velocity *= 0.8f;
                    Main.dust[num].noGravity = true;
                    int num1 = Dust.NewDust(vector, 1, 1, 182, 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[num1].position = vector;
                    Main.dust[num1].scale = (float)Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num1].velocity *= 0.15f;
                    Main.dust[num1].noGravity = true;
				}
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.lifeMax = 0;
            target.life = 0;
            target.NPCLoot();
        }
	}
}
