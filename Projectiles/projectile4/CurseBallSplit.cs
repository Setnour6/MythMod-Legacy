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
    public class CurseBallSplit : ModProjectile
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
            Projectile.timeLeft = 100000;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.timeLeft == 99999)
            {
                Projectile.timeLeft = Main.rand.Next(284, 323);
            }
            if(Projectile.timeLeft % 36 == 1)
            {
                Vector2 v = Projectile.velocity.RotatedBy(Math.PI / 2d);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 96, (int)((double)base.Projectile.damage * 0.5f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                v = v.RotatedBy(Math.PI);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 96, (int)((double)base.Projectile.damage * 0.5f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            if (K >= 40)
            {
                K *= 0.96f;
            }
            if (K <= 6)
            {
                K *= 1.05f;
            }
            if(Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            Vector2 vector = base.Projectile.Center - new Vector2(4, 4);
            for(int i = 0;i < 4; i++)
            {
                int num2 = Dust.NewDust(vector, 8, 8, 75, 0f, 0f, 0, default(Color), 2.4f);
                //Main.dust[num2].velocity *= 0.0f;
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