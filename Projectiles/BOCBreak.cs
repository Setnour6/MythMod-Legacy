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
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
			Main.projFrames[projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 50;
			base.projectile.height = 42;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 270;
			base.projectile.tileCollide = false;
			base.projectile.usesLocalNPCImmunity = true;
		}
		public override void AI()
		{
			float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 400f;
			bool flag = false;
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 20);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4 && projectile.timeLeft > 120)
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
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag)
			{
				float num8 = 20f;
				Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 10f + num9) / 11f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 10f + num10) / 11f;
			}
            if (projectile.timeLeft < 120)
			{
                projectile.tileCollide = false;
				flag = false;
				base.projectile.velocity += new Vector2(0, 0.25f);
            }
            if (!flag)
			{
            }
			if (base.projectile.frame > 4)
			{
				base.projectile.frame = 0;
			}
			if(base.projectile.timeLeft % 10 == 0)
			{
				base.projectile.frame++;
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
