using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile4
{
    public class RedLazerBall3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("红激光球");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 360000000;
            Projectile.tileCollide = false;
        }
        private float Stre = 0.01f;
        private float BStre = 0.01f;
        private bool Bmax = false;
        private bool Smax = false;
        private float theta = 0.01f;
        private Vector2 v2 = new Vector2(15, 0);
        private Vector2 v3 = new Vector2(480, 0);
        private Vector2 v = new Vector2(15, 0);
        public override void AI()
        {
            if(Projectile.timeLeft >= 360000000)
            {
                theta = Projectile.ai[0];
            }
            theta += 0.01f;
            Projectile.position = Main.screenPosition + new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f) + v3.RotatedBy(theta);
            v2 = Projectile.Center - new Vector2(Main.mouseX, Main.mouseY) + new Vector2(0, 60).RotatedBy(Projectile.ai[0]) - Main.screenPosition;
            v = -v2 / v2.Length() * 15f;
            if (Bmax)
            {
                if (Smax)
                {
                    if (Stre > 0f)
                    {
                        Stre -= 0.02f;
                        BStre -= 0.02f;
                    }
                    else
                    {
                        Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                        if(NPC.CountNPCS(134) > 0)
                        {
                            Bmax = false;
                            Smax = false;
                            BStre = 0.01f;
                            Stre = 0.01f;
                        }
                        else
                        {
                            Stre = 0;
                            Projectile.Kill();
                        }
                    }
                }
                else
                {
                    if (Stre < 1f)
                    {
                        Stre += 0.055f;
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
                    BStre += 0.006f;
                }
                else
                {
                    BStre = 1; ;
                    Bmax = true;
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if(Stre <= 1)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/RedLazerBall"), base.Projectile.Center - Main.screenPosition, null, new Color(BStre, BStre, BStre, 0), base.Projectile.rotation, new Vector2(13f, 13f), BStre, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/RedLazer"), base.Projectile.Center - Main.screenPosition + v * 0.3f, new Rectangle(0, 0, 3000, 16), new Color(Stre, Stre, Stre, 0), (float)Math.Atan2(v.Y, v.X), new Vector2(8, 8), 1, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
