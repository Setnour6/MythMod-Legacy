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
    public class CurseBallSplit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("咒火球");
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
            projectile.tileCollide = true;
            projectile.timeLeft = 100000;
            projectile.penetrate = 1;
            projectile.scale = 1;
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
            projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.timeLeft == 99999)
            {
                projectile.timeLeft = Main.rand.Next(284, 323);
            }
            if(projectile.timeLeft % 36 == 1)
            {
                Vector2 v = projectile.velocity.RotatedBy(Math.PI / 2d);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 96, (int)((double)base.projectile.damage * 0.5f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                v = v.RotatedBy(Math.PI);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 96, (int)((double)base.projectile.damage * 0.5f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            if (K >= 40)
            {
                K *= 0.96f;
            }
            if (K <= 6)
            {
                K *= 1.05f;
            }
            if(projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            Vector2 vector = base.projectile.Center - new Vector2(4, 4);
            for(int i = 0;i < 4; i++)
            {
                int num2 = Dust.NewDust(vector, 8, 8, 75, 0f, 0f, 0, default(Color), 2.4f);
                //Main.dust[num2].velocity *= 0.0f;
                Main.dust[num2].noGravity = true;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            return true;
        }
    }
}