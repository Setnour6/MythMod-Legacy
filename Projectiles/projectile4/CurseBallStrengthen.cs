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
    public class CurseBallStrengthen : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("咒火球");
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
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1800;
            Projectile.penetrate = 1;
            Projectile.scale = 0;
        }
        private bool Down = false;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 0, 0, 0));
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(!Down)
            {
                Projectile.scale += 0.02f;
            }
            else
            {
                Projectile.velocity.Y += 0.01f;
            }
            if(Projectile.scale > 0.8f)
            {
                if(Main.rand.Next(300) == 1)
                {
                    Down = true;
                }
            }
            if (Projectile.scale > 1.5f)
            {
                if (Main.rand.Next(100) == 1)
                {
                    Down = true;
                }
            }
            if (Projectile.scale > 2f)
            {
                Down = true;
            }
            if(!Down)
            {
                int num2 = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 8, 8, 75, 0f, 0f, 0, default(Color), 1.2f * Projectile.scale);
                Main.dust[num2].velocity *= 0.0f;
            }
            else
            {
                int num2 = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 8, 8, 75, 0f, 0f, 0, default(Color), 2.4f * Projectile.scale);
                Main.dust[num2].noGravity = true;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            return true;
        }
    }
}