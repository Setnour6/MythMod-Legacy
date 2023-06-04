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
    public class DepressLotus : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("DepressLotus");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
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
            Projectile.scale = Projectile.velocity.Length() * 0.14f;
            Projectile.velocity *= 0.99f;
            if(Projectile.timeLeft == 99999)
            {
                Projectile.timeLeft = Main.rand.Next(284, 323);
            }
            if(Main.rand.Next(25) == 1)
            {
                float p = Main.rand.NextFloat(0, 2f) * (float)Math.PI;
                float Leng = Main.rand.NextFloat(0, 1.2f);
                for (int j = 0; j < 7; j++)
                {
                    Vector2 v = new Vector2(0, Projectile.velocity.Length() * 0.6f).RotatedBy((float)j / 3.5f * Math.PI + p) * Leng;
                    int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("DepressLotus2").Type, (int)((double)base.Projectile.damage * 0.15f * Projectile.scale), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
            if(Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            Vector2 vector = base.Projectile.Center - new Vector2(4, 4);
            int num = Dust.NewDust(vector, 2, 2, 191, 0f, 0f, 0, default(Color), (float)Projectile.scale * 1.5f);
            Main.dust[num].velocity *= 0.0f;
            Main.dust[num].noGravity = true;
            Main.dust[num].scale *= 1.2f;
            Main.dust[num].alpha = 200;
            int num2 = Dust.NewDust(vector, 2, 2, 75, 0f, 0f, 0, default(Color), (float)Projectile.scale * 0.8f);
            Main.dust[num2].velocity *= 0.0f;
            Main.dust[num2].noGravity = true;
        }
        public override void Kill(int timeLeft)
        {
            float p = Main.rand.NextFloat(0, 2f) * (float)Math.PI;
            for (int i = 0; i <= 7; i++)
            {
                Vector2 v = new Vector2(0, 6f).RotatedBy((float)i / 3.5f * Math.PI + p) * Projectile.scale;
                int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("DepressLotus2").Type, (int)((double)base.Projectile.damage * 0.4f * Projectile.scale), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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