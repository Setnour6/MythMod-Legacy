using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class CrackSoundWave : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("爆裂音波");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 200;
            base.projectile.scale = 0f;
            base.projectile.height = 200;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 120;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
        public override void AI()
        {
            if(base.projectile.ai[0] <= 5)
            {
                base.projectile.ai[0] -= 0.05f;
            }
            else
            {
                base.projectile.scale += 0.015f;
                base.projectile.scale *= 1.02f;
                base.projectile.ai[0] = 10;
            }
            if (base.projectile.ai[0] <= 0)
            {
                base.projectile.scale += 0.015f;
                base.projectile.scale *= 1.02f;
            }
            if (base.projectile.friendly)
            {
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1) && Math.Abs((base.projectile.Center - Main.npc[j].Center).Length() - (100 * base.projectile.scale)) < 3f && base.projectile.ai[0] <= 5)
                    {
                        int num = Projectile.NewProjectile(Main.npc[j].Center.X, Main.npc[j].Center.Y, 0, 0, base.mod.ProjectileType("CrackSoundWave"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 10, 0f);
                        Main.projectile[num].timeLeft = 60;
                    }
                }
            }
            else
            {
                int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                if (Math.Abs((Main.player[num5].Center - base.projectile.Center).Length() - (100 * base.projectile.scale)) < 3f && base.projectile.ai[0] <= 5)
                {
                    int num3 = Projectile.NewProjectile(Main.player[num5].Center.X, Main.player[num5].Center.Y, 0, 0, base.mod.ProjectileType("CrackSoundWave"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 10, 0f);
                    Main.projectile[num3].hostile = true;
                    Main.projectile[num3].friendly = false;
                    Main.projectile[num3].timeLeft = 60;
                }
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, 0) * ((projectile.timeLeft) / 120f));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
