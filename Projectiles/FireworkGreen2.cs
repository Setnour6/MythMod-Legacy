using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
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
            projectile.width = 7;
            projectile.height = 7;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 300;
            projectile.alpha = 105;
            projectile.penetrate = -1;
            projectile.scale = 0.7f;
            this.cooldownSlot = 1;
        }
        //55555
        private bool initialization = true;
        private float z;
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        public override void AI()
        {
            if (initialization)
            {
                if (projectile.velocity.Length() >= 1)
                {
                    z = projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                initialization = false;
            }
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 300)
            {
                Vector2 vector = base.projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), 0.8f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            float b = Main.rand.Next(-50, 100);
            if (projectile.timeLeft < 100 + (float)b)
            {
                projectile.scale *= 0.95f;
            }
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.2f / 255f *projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球绿light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft) / (7200f * z * z), projectile.scale * (projectile.timeLeft) / (7200f * z * z), projectile.scale * (projectile.timeLeft) / (7200f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (500 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            return false;
		}
    }
}