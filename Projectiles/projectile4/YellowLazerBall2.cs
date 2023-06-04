using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile4
{
    public class YellowLazerBall2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("黄激光球");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = false;
        }
        private float Stre = 0.01f;
        private float BStre = 0.01f;
        private bool Bmax = false;
        private bool Smax = false;
        private Vector2 v = new Vector2(15, 0);
        public override void AI()
        {
            for(int h = 0;h < 200;h++)
            {
                if(Main.npc[h].type == Mod.Find<ModNPC>("LanternGhostKing").Type)
                {
                    Projectile.velocity = Main.npc[h].velocity;
                }
            }
            if (BStre == 0.01f)
            {
                v = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            }
            if(Bmax)
            {
                if (Smax)
                {
                    if (Stre > 0f)
                    {
                        Stre -= 0.04f;
                        BStre -= 0.04f;
                    }
                    else
                    {
                        Stre = 0;
                        /*for(int i = 0;i < 10;i++)
                        {
                            int u = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X  * (10 + i) / 10f, v.Y * (10 + i) / 10f, mod.ProjectileType("GoldLanternLine2"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
                            Main.projectile[u].hostile = true; 
                        }*/
                        /*int u = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, 83, projectile.damage, 0f, Main.myPlayer, 0f, 0f;
                        Main.projectile[u].hostile = true;*/
                        Projectile.Kill();
                    }
                }
                else
                {
                    if (Stre < 1f)
                    {
                        Stre += 0.11f;
                    }
                    else
                    {
                        Stre = 1; ;
                        Smax = true;
                    }
                }
            }
            else
            {
                if (BStre < 1f)
                {
                    BStre += 0.03f;
                }
                else
                {
                    BStre = 1; ;
                    Bmax = true;
                }
            }
            if(Dx == 0.01f)
            {
                K = Main.rand.NextFloat(Main.rand.NextFloat(Main.rand.NextFloat(-0.2f, 0f), 0f), Main.rand.NextFloat(0f, Main.rand.NextFloat(0f, 0.2f)));
                dK = Main.rand.NextFloat(-0.005f, 0.005f);
            }
            Dx += 0.01f;
            K += dK;
        }
        private float Dx = 0.01f;
        private float Dy = 0;
        private float K = 0;
        private float dK = 0;
        public override bool PreDraw(ref Color lightColor)
        {
            if(Stre <= 1)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/YellowLazerBall2"), base.Projectile.Center - Main.screenPosition, null, new Color(BStre, BStre, BStre, 0), base.Projectile.rotation, new Vector2(13f, 13f), BStre, SpriteEffects.None, 0f);
                float Rot = (float)Math.Atan2(v.Y, v.X);
                for (float o = 0;o < 6;o+= 0.1f)
                {
                    Vector2 vp = new Vector2(o * 100, o * o * K * 10000).RotatedBy(Rot);
                    Vector2 vp0 = new Vector2((o - 0.1f) * 100, (o - 0.1f) * (o -0.1f) * K * 10000).RotatedBy(Rot);
                    float L = (vp - vp0).Length();
                    float Rot2 = (float)Math.Atan(20000 * o * K);
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/YellowLazer"), base.Projectile.Center - Main.screenPosition + v * 0.3f + vp, new Rectangle(0, 0, (int)(L), 16), new Color(Stre, Stre, Stre, 0), Rot + Rot2, new Vector2(8, 8), 1, SpriteEffects.None, 0f);
                }
            }
            return false;
        }
    }
}
