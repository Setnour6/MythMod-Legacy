using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile5
{
    public class GreenLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("青苍射线");
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
        }
        private Vector2 v0;
        private int Fra = 0;
        private int FraX = 112;
        private int FraY = 0;
        private float Sca = 0;
        private int ChaseNPC = -1;
        public override void AI()
        {
            if (projectile.timeLeft == 600)
            {
                v0 = projectile.Center;
                for(int i  =0;i < 200;i++)
                {
                    if(Main.npc[i].type == mod.NPCType("AncientTangerineTreeEye"))
                    {
                        ChaseNPC = i;
                        projectile.position = (Main.npc[i].Center - new Vector2(16, -16));
                        break;
                    }
                }
                int pl = Player.FindClosest(projectile.Center, 1, 1);
                Vector2 v = Main.player[pl].Center - projectile.Center;
                projectile.rotation = (float)Math.Atan2(v.Y, v.X) - 1.2f + (float)Math.PI / 2f;
            }
            projectile.rotation += 0.004f;
            if (ChaseNPC != -1)
            {
                projectile.velocity = Main.npc[ChaseNPC].velocity;
            }
            if (projectile.timeLeft > 540)
            {
                Sca += 1 / 60f;
            }
            if(projectile.timeLeft % 5 == 0 && projectile.timeLeft > 60)
            {
                if(FraX > 0)
                {
                    FraX -= 16;
                }
                else
                {
                    FraX = 0;
                }
            }
            if (projectile.timeLeft % 5 == 0 && projectile.timeLeft < 60)
            {
                if (FraX < 128)
                {
                    FraX += 16;
                }
                else
                {
                    FraX = 128;
                }
            }
            if (projectile.timeLeft < 480)
            {
                n *= 0.99f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        float n = 0.2f;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float Leng = 4000f;
            float[] samples = new float[2];
            Vector2 unit = new Vector2(0, -1).RotatedBy(projectile.rotation);
            Collision.LaserScan(projectile.Center, unit, 3f, 4000f, samples);
            float maxDis = (samples[0] + samples[1]) * 0.5f;
            Leng = maxDis;
            for(int k = 0;k < Leng - 24;k+=16)
            {
                if(k >= Leng - 40)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile5/GreenLightEnd"), base.projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    if(!Main.gamePaused)
                    {
                        for(int g =0;g < 4; g++)
                        {
                            Vector2 v = new Vector2(0, Main.rand.NextFloat(0.1f,4.3f)).RotatedByRandom(MathHelper.TwoPi);
                            int num = Dust.NewDust(projectile.Center + new Vector2(0, -k - 8).RotatedBy(projectile.rotation) - new Vector2(8, 8), 8, 8, mod.DustType("Poison"), v.X, v.Y, 0, default(Color), 4f * (128 - FraX) / 128f);
                            Main.dust[num].noGravity = true;
                        }
                    }
                }
                else
                {
                    if (k == 0)
                    {
                        spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile5/GreenLightShoot"), base.projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile5/GreenLight"), base.projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    }
                }
            }
            return false;
        }
    }
}
