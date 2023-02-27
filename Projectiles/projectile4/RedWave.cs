using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
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
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
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
            if(Projectile.timeLeft >= 600)
            {
                Startposition = Projectile.Center;
            }
            Projectile.velocity *= 0.98f;
            b *= 0.98f;
            if(b <= 0.001f)
            {
                Projectile.active = false;
            }
            if (b <= 0.1f)
            {
                Projectile.hostile = false;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            Player player = Main.player[Main.myPlayer];
            for (int r = 0;r < 60;r++)
            {
                Vector2 vh = Startposition + (Projectile.Center - Startposition).RotatedBy((r - 30) / 120d * Math.PI);
                Main.spriteBatch.Draw(texture2D, vh - Main.screenPosition, null, new Color(b, b, b, 0), 0, new Vector2(13, 13), 1, SpriteEffects.None, 0f);
                if(!Main.gamePaused && Projectile.hostile)
                {
                    if((player.Center - vh).Length() < 20)
                    {
                        Projectile.NewProjectile(vh.X, vh.Y, 0, 0, Mod.Find<ModProjectile>("Hit").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            return false;
        }
    }
}