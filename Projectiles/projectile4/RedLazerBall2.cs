using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile4
{
    public class RedLazerBall2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("红激光球");
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
                        Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, 100, 70, 0f, Main.myPlayer, 0f, 0f);
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
