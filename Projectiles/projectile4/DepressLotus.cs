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
    public class DepressLotus : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DepressLotus");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
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
            projectile.scale = projectile.velocity.Length() * 0.14f;
            projectile.velocity *= 0.99f;
            if(projectile.timeLeft == 99999)
            {
                projectile.timeLeft = Main.rand.Next(284, 323);
            }
            if(Main.rand.Next(25) == 1)
            {
                float p = Main.rand.NextFloat(0, 2f) * (float)Math.PI;
                float Leng = Main.rand.NextFloat(0, 1.2f);
                for (int j = 0; j < 7; j++)
                {
                    Vector2 v = new Vector2(0, projectile.velocity.Length() * 0.6f).RotatedBy((float)j / 3.5f * Math.PI + p) * Leng;
                    int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("DepressLotus2"), (int)((double)base.projectile.damage * 0.15f * projectile.scale), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    Main.projectile[num5].scale = Main.rand.Next(1150, 1152) / 3750f;
                }
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
            int num = Dust.NewDust(vector, 2, 2, 191, 0f, 0f, 0, default(Color), (float)projectile.scale * 1.5f);
            Main.dust[num].velocity *= 0.0f;
            Main.dust[num].noGravity = true;
            Main.dust[num].scale *= 1.2f;
            Main.dust[num].alpha = 200;
            int num2 = Dust.NewDust(vector, 2, 2, 75, 0f, 0f, 0, default(Color), (float)projectile.scale * 0.8f);
            Main.dust[num2].velocity *= 0.0f;
            Main.dust[num2].noGravity = true;
        }
        public override void Kill(int timeLeft)
        {
            float p = Main.rand.NextFloat(0, 2f) * (float)Math.PI;
            for (int i = 0; i <= 7; i++)
            {
                Vector2 v = new Vector2(0, 6f).RotatedBy((float)i / 3.5f * Math.PI + p) * projectile.scale;
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("DepressLotus2"), (int)((double)base.projectile.damage * 0.4f * projectile.scale), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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