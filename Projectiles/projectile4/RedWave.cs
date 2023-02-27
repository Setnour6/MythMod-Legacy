using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile4
{
    public class RedWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RedWave");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b = 1;
        private float K = 10;
        private Vector2 Startposition = Vector2.Zero;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(b, b, b, 0));
        }
        public override void AI()
        {
            if(projectile.timeLeft >= 600)
            {
                Startposition = projectile.Center;
            }
            projectile.velocity *= 0.98f;
            b *= 0.98f;
            if(b <= 0.001f)
            {
                projectile.active = false;
            }
            if (b <= 0.1f)
            {
                projectile.hostile = false;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            Player player = Main.player[Main.myPlayer];
            for (int r = 0;r < 60;r++)
            {
                Vector2 vh = Startposition + (projectile.Center - Startposition).RotatedBy((r - 30) / 120d * Math.PI);
                Main.spriteBatch.Draw(texture2D, vh - Main.screenPosition, null, new Color(b, b, b, 0), 0, new Vector2(13, 13), 1, SpriteEffects.None, 0f);
                if(!Main.gamePaused && projectile.hostile)
                {
                    if((player.Center - vh).Length() < 20)
                    {
                        Projectile.NewProjectile(vh.X, vh.Y, 0, 0, mod.ProjectileType("Hit"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            return false;
        }
    }
}