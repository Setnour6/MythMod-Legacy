using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class BOCBreak : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之脑残片");
			ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
			Main.projFrames[Projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 50;
			base.Projectile.height = 42;
			base.Projectile.netImportant = true;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 270;
			base.Projectile.tileCollide = false;
			base.Projectile.usesLocalNPCImmunity = true;
		}
		public override void AI()
		{
			float num2 = base.Projectile.Center.X;
			float num3 = base.Projectile.Center.Y;
			float num4 = 400f;
			bool flag = false;
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 20);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4 && Projectile.timeLeft > 120)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag)
			{
				float num8 = 20f;
				Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 10f + num9) / 11f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 10f + num10) / 11f;
			}
            if (Projectile.timeLeft < 120)
			{
                Projectile.tileCollide = false;
				flag = false;
				base.Projectile.velocity += new Vector2(0, 0.25f);
            }
            if (!flag)
			{
            }
			if (base.Projectile.frame > 4)
			{
				base.Projectile.frame = 0;
			}
			if(base.Projectile.timeLeft % 10 == 0)
			{
				base.Projectile.frame++;
			}
		}
        private int y = 0;
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if(target.type != NPCID.TargetDummy)
            {
                if(y % 5 == 0)
                {
                    Projectile.NewProjectile(target.Center.X, target.position.Y + target.height / 20f, 0, 0, 305, 1000, 0, Main.myPlayer, 0, 1);
                }
                y += 1;
            }
        }
	}
}
