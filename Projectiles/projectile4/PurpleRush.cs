using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class PurpleRush : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("影炸弹");
		}
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 0;
			projectile.penetrate = 11;
			projectile.timeLeft = 3600;
            projectile.extraUpdates = 2;
            projectile.tileCollide = true;
        }
        private float St = 0;
        private int BoomTime = 240;
        private float T = 0;
        private Vector2 vd = Vector2.Zero;
        private bool ON = false; 
        public override void AI()
		{
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if(projectile.timeLeft == 3599)
            {
                vd = new Vector2(0, 1).RotatedByRandom(Math.PI * 2);
            }
            if (projectile.timeLeft < 3599)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 86, 50f, 50f, 0, default(Color), (float)projectile.scale * 1.2f * (1 + projectile.ai[0] / 4f));
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 150;
            }
            if(BoomTime > 0)
            {
                T += 5f / (float)BoomTime + 0.1f;
            }
            /*if (projectile.velocity.Length() < 2.5f)
            {
                projectile.velocity += projectile.velocity / projectile.velocity.Length() * 0.04f;
            }
            */
            if(BoomTime > 0)
            {
                BoomTime -= 1;
            }
            else
            {
                if(!ON)
                {
                    ON = true;
                    projectile.velocity += vd * projectile.ai[0] * 8f;
                    projectile.damage = 20;
                }
                BoomTime = 0;
            }
            projectile.velocity *= 0.97f;
            if(projectile.velocity.Length() < 0.97f && ON)
            {
                projectile.Kill();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if(BoomTime > 0)
            {
                int B = 0;
                if (T % 2 > 1)
                {
                    B = 1;
                }
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile4/PurpleCircle"), projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.8f, 0.8f, 0) * B, 0f, new Vector2(26, 26), 1, SpriteEffects.None, 0f);
                int[] C = new int[8];
                for (int G = 0; G < 3; G++)
                {
                    if ((int)T % 8 == G)
                    {
                        C[G] = 1;
                    }
                    else
                    {
                        C[G] = 0;
                    }
                }
                for (int G = 0; G < projectile.ai[0]; G++)
                {
                    Vector2 v = vd * 8 * (G + 1.5f);
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile4/PurpleArrow"), projectile.Center - Main.screenPosition + v, null, new Color(0.8f, 0.8f, 0.8f, 0) * C[G], (float)Math.Atan2(vd.Y, vd.X), new Vector2(26, 26), 1, SpriteEffects.None, 0f);
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}
