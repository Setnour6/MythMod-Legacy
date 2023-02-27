using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200067D RID: 1661
    public class SpiritMark : ModProjectile
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灵魂标记");
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001D6574 File Offset: 0x001D4774
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, 0));
            }
        }
        // Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 188, 0, 0, 0, default(Color), 4f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 1.5f - new Vector2(4, 4), 0, 0, 188, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            float num = base.projectile.Center.X;
            float num2 = base.projectile.Center.Y;
            float num3 = 400f;
            bool flag = false;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[i].Center, 1, 1) && Main.npc[i].type != mod.NPCType("MagicBaby"))
                {
                    float num4 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
                    float num5 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
                    float num6 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num4) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num5);
                    if (num6 < num3)
                    {
                        num3 = num6;
                        num = num4;
                        num2 = num5;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num7 = 20f;
                Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num8 = num - vector.X;
                float num9 = num2 - vector.Y;
                float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
                num10 = num7 / num10;
                num8 *= num10;
                num9 *= num10;
                base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num8) / 21f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num9) / 21f;
                return;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(target.type != mod.NPCType("MagicBaby"))
            {
                Player pl = Main.player[Main.myPlayer];
                target.AddBuff(mod.BuffType("BIAOJI"), 3600);
                NPC.NewNPC((int)pl.Center.X, (int)pl.Center.Y, mod.NPCType("MagicBaby"), 0, projectile.ai[0], 0, 0, 0, 255);
            }
        }
        // Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
        }
        public int projTime = 15;

		// Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
	}
}
