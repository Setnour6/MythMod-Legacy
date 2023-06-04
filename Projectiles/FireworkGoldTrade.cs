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
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles
{
    //135596
    public class FireworkGoldTrade : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("烟花火球金色尾迹");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 1000;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.scale = 0.5f;
            this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 90;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
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
            if (Projectile.timeLeft < 700 && Projectile.timeLeft >= 685)
            {
                if (Y < 1)
                {
                    Projectile.scale *= (float)Y / (Projectile.timeLeft / 685);
                }
                else
                {
                    Projectile.scale *= (float)Y * Projectile.timeLeft / 685;
                }
            }
            if (Projectile.timeLeft < 685 && Projectile.timeLeft >= 480 + (float)b)
            {
                Projectile.scale *= (float)Y;
            }
            if (Projectile.timeLeft < 480+ (float)b)
            {
                Projectile.scale *= 0.994f;
            }
            Projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.3f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f *Projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D t = TextureAssets.Projectile[Projectile.type].Value;
             int frameHeight = t.Height / Main.projFrames[Projectile.type];
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                Color color = (Color.Wheat * 0.2f) * ((float)(Projectile.oldPos.Length - k * k / 90) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * Projectile.frame, t.Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
    }
}