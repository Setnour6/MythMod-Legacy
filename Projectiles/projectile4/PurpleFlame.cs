using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class PurpleFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("紫冥鬼火");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
            projectile.hostile = false;
            projectile.friendly = true;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 900;
            projectile.extraUpdates = 3;
        }
        public float scal = 0f;
        public float scalMax = 1f;
        public float scalx = 1f;
        public override void AI()
		{
            if (projectile.timeLeft == 895)
            {
                int[] M = new int[1001];
                int Cou = 0;
                for(int i = 0;i < 1000; i++)
                {
                    M[i] = -1;
                    if (Main.projectile[i].type == projectile.type && Main.projectile[i].timeLeft > 840)
                    {
                        if((Main.projectile[i].Center - projectile.Center).Length() < 10)
                        {
                            M[i] = i;
                            Cou += 1;
                        }
                    }
                }
                if (Cou > 3)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if(M[i] != -1)
                        {
                            Main.projectile[M[i]].Kill();
                        }
                    }
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("PurpleFlameLage"), projectile.damage, projectile.knockBack, 255, 0f, 0f);
                }
            }
            projectile.velocity *= 0;
            float x = (float)Main.rand.NextFloat(-10, 11) * 0.75f;
            float y = (float)Main.rand.NextFloat(-10, 1) * 1.75f;
            if (projectile.timeLeft < 180)
            {
                scalx *= 0.96f;
            }
            if(Main.rand.Next(180) == 1)
            {
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8), 8, 8, 21, 0, Main.rand.NextFloat(-4.5f, -0.5f), 0, default(Color), 1f);
                Main.dust[r2].noGravity = true;
            }
            /*if (Main.rand.Next(180) == 1)
            {
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8), 8, 8, mod.DustType("PurpleFlame"), Main.rand.NextFloat(-0.5f, -0.5f), Main.rand.NextFloat(-2.5f, -0.5f), 0, default(Color), 1f);
                Main.dust[r2].noGravity = true;
            }*/
            Lighting.AddLight(base.projectile.Center + new Vector2(x, y), (float)(255 - base.projectile.alpha) * 0.4f / 255f * scalx, (float)(255 - base.projectile.alpha) * 0.2f / 255f * scalx, (float)(255 - base.projectile.alpha) * 0.7f / 255f * scalx);
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if(projectile.timeLeft >= 899)
            {
                scalMax = 1f * projectile.ai[0];
            }

            if(projectile.timeLeft < 180)
            {
                scal *= 0.96f;
            }
            else
            {
                if(scal < scalMax)
                {
                    scal += 0.05f;
                }
            }
            Vector2[] vz = new Vector2[16];
            for (int k = 0; k < 7; k++)
            {
                float x = (float)Main.rand.NextFloat(-10, 11) * 0.45f * scal;
                float y = (float)Main.rand.NextFloat(-10, 1) * 1.4f * scal;
                if(vz[k].Length() > 24f * scal)
                {
                    vz[k] *= 0.92f;
                }
                else
                {
                    vz[k] += new Vector2(x, y);
                }
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center-Main.screenPosition + vz[k] + new Vector2(0, 4), null, new Color(0.05f,0.05f,0.05f,0), 0f, new Vector2(6, 9), scal, SpriteEffects.None, 0f);
            }
            for (int k = 8; k < 16; k++)
            {
                float x = (float)Main.rand.NextFloat(-10, 11) * 1.4f * scal;
                float y = (float)Main.rand.NextFloat(-10, 1) * 0.42f * scal;
                if (vz[k].Length() > 24f * scal)
                {
                    vz[k] *= 0.92f;
                }
                else
                {
                    vz[k] += new Vector2(x, y);
                }
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition + vz[k] + new Vector2(0, 4), null, new Color(0.05f, 0.05f, 0.05f, 0), 0f, new Vector2(6, 9), scal, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
