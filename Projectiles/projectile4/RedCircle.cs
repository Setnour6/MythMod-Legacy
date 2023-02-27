using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;


namespace MythMod.Projectiles.projectile4
{
    public class RedCircle : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("红环");
        }
        private float Stre = 0.01f;
        private bool Smax = false;
        private int T = 30;
        public override void SetDefaults()
        {
            Projectile.width = 250;
            Projectile.height = 250;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            if (Stre < 1f)
            {
                Stre += 0.03f;
            }
            else
            {
                Stre = 1;
                Smax = true;
            }
            if(Smax)
            {
                T -= 1;
            }
            if(T == 20)
            {
                int u = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, 102, 100, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[u].timeLeft = 1;
            }
            if(T <= 0)
            {
                Projectile.Kill();
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if(Stre < 1)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/RedCircle"), base.Projectile.Center - Main.screenPosition, null, new Color(Stre, Stre, Stre, 0), base.Projectile.rotation, new Vector2(125f, 125f), 0.3f / Stre, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
