﻿using Microsoft.Xna.Framework;
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
namespace MythMod.Projectiles
{
    //135596
    public class FireworkGreen2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球绿2");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 7;
            Projectile.height = 7;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 300;
            Projectile.alpha = 105;
            Projectile.penetrate = -1;
            Projectile.scale = 0.7f;
            this.CooldownSlot = 1;
        }
        //55555
        private bool initialization = true;
        private float z;
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        public override void AI()
        {
            if (initialization)
            {
                if (Projectile.velocity.Length() >= 1)
                {
                    z = Projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                initialization = false;
            }
            Projectile.velocity *= 0.995f;
            NPC target = null;
            if (Projectile.timeLeft < 300)
            {
                Vector2 vector = base.Projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), 0.8f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            float b = Main.rand.Next(-50, 100);
            if (Projectile.timeLeft < 100 + (float)b)
            {
                Projectile.scale *= 0.95f;
            }
            Projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 1f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.2f / 255f *Projectile.scale);
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
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/烟花火球绿light"), base.Projectile.Center - Main.screenPosition, null, new Color(Projectile.scale * (Projectile.timeLeft) / (7200f * z * z), Projectile.scale * (Projectile.timeLeft) / (7200f * z * z), Projectile.scale * (Projectile.timeLeft) / (7200f * z * z), 0), base.Projectile.rotation, new Vector2(56f, 56f), 1 + (500 - Projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            return false;
		}
    }
}