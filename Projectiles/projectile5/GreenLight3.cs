using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile5
{
    public class GreenLight3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("青苍射线");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
        }
        private Vector2 v0;
        private int Fra = 0;
        private int FraX = 112;
        private int FraY = 0;
        private float Sca = 0;
        private int ChaseNPC = -1;
        public override void AI()
        {
            if (Projectile.timeLeft == 100)
            {
                v0 = Projectile.Center;
                for(int i  =0;i < 200;i++)
                {
                    if(Main.npc[i].type == Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                    {
                        ChaseNPC = i;
                        Projectile.position = (Main.npc[i].Center - new Vector2(16, -16));
                        break;
                    }
                }
                int pl = Player.FindClosest(Projectile.Center, 1, 1);
                Vector2 v = Main.player[pl].Center - Projectile.Center;
                Projectile.rotation = (float)Math.Atan2(v.Y, v.X) + (float)Math.PI / 2f + Projectile.ai[0] * (float)Math.PI / 6f;
            }
            Projectile.rotation += 0.06f * Projectile.ai[0];
            if (ChaseNPC != -1)
            {
                Projectile.velocity = Main.npc[ChaseNPC].velocity;
            }
            if (Projectile.timeLeft > 540)
            {
                Sca += 1 / 60f;
            }
            if (Projectile.timeLeft % 30 == 0)
            {
                Vector2 b = new Vector2(0, 4).RotatedBy(Projectile.rotation);
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, -b.X + Projectile.velocity.X, -b.Y + Projectile.velocity.Y, Mod.Find<ModProjectile>("GreenLeafBall").Type, 50, 0f, Main.myPlayer, 0f, 0);
            }
            if (Projectile.timeLeft % 5 == 0 && Projectile.timeLeft > 60)
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
            if (Projectile.timeLeft % 5 == 0 && Projectile.timeLeft < 60)
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
            if (Projectile.timeLeft < 480)
            {
                n *= 0.99f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
        float n = 0.2f;
        public override bool PreDraw(ref Color lightColor)
        {
            float Leng = 4000f;
            float[] samples = new float[2];
            Vector2 unit = new Vector2(0, -1).RotatedBy(Projectile.rotation);
            Collision.LaserScan(Projectile.Center, unit, 3f, 4000f, samples);
            float maxDis = (samples[0] + samples[1]) * 0.5f;
            Leng = maxDis;
            for(int k = 0;k < Leng - 24;k+=16)
            {
                if(k >= Leng - 40)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile5/GreenLightEnd"), base.Projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(Projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), Projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    if(!Main.gamePaused)
                    {
                        for(int g =0;g < 4; g++)
                        {
                            Vector2 v = new Vector2(0, Main.rand.NextFloat(0.1f,4.3f)).RotatedByRandom(MathHelper.TwoPi);
                            int num = Dust.NewDust(Projectile.Center + new Vector2(0, -k - 8).RotatedBy(Projectile.rotation) - new Vector2(8, 8), 8, 8, Mod.Find<ModDust>("Poison").Type, v.X, v.Y, 0, default(Color), 4f * (128 - FraX) / 128f);
                            Main.dust[num].noGravity = true;
                        }
                    }
                }
                else
                {
                    if (k == 0)
                    {
                        spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile5/GreenLightShoot"), base.Projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(Projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), Projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile5/GreenLight"), base.Projectile.Center - Main.screenPosition + new Vector2(0, - k - 8).RotatedBy(Projectile.rotation), new Rectangle(FraX, 0, 16, 48), new Color(1f, 1f, 1f, 0), Projectile.rotation - (float)(Math.PI / 2f), new Vector2(8f, 24f), 1, SpriteEffects.None, 0f);
                    }
                }
            }
            return false;
        }
    }
}
