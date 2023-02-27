using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class FireworkGoldSand : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球金沙");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 600;
            Projectile.alpha = 105;
            Projectile.penetrate = -1;
            Projectile.scale = 1;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                X = (float)Math.Sqrt((double)Projectile.velocity.X * (double)Projectile.velocity.X + (double)Projectile.velocity.Y * (double)Projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Sin(-(double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            Projectile.velocity *= 0.995f;
            NPC target = null;
            if (Projectile.timeLeft < 595)
            {
                Vector2 vector = base.Projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), (float)Projectile.scale * 0.4f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            if (Projectile.timeLeft < 600 && Projectile.timeLeft >= 585)
            {
                if (Y < 1)
                {
                    Projectile.scale *= (float)Y / (Projectile.timeLeft / 585);
                }
                else
                {
                    Projectile.scale *= (float)Y * Projectile.timeLeft / 585;
                }
            }
            if(Projectile.timeLeft < 480)
            {
                if(Main.rand.Next(15) == 1)
                {
                    Projectile.timeLeft = 0;
                }
            }
            if (Projectile.timeLeft < 580 && Projectile.timeLeft >= 100+ (float)b)
            {
                Projectile.scale *= (float)Y;
            }
            if (Projectile.timeLeft < 100+ (float)b)
            {
                Projectile.scale *= 0.95f;
            }
            Projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 100; k++)
            {
                Vector2 v = new Vector2(0, 150).RotatedByRandom(Math.PI * 2f);
                v = v * Main.rand.Next(0, 200) / 40000f * Projectile.scale;
                int num6 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, 55, v.X, v.Y, 0, Color.White, 0.9f);
                Main.dust[num6].noGravity = false;
                Main.dust[num6].scale *= 0.8f;
                Main.dust[num6].velocity *= 0.975f;
                int num7 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, 87, v.X, v.Y, 0, Color.White, 0.9f);
                Main.dust[num7].noGravity = false;
                Main.dust[num7].scale *= 0.8f;
                Main.dust[num7].velocity *= 0.975f;
            }
            SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.6f), new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y));
        }
    }
}