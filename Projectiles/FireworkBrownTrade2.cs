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
using Terraria.ID;
namespace MythMod.Projectiles
{
    //135596
    public class FireworkBrownTrade2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球棕色尾迹2");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 700;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.scale = 0.5f;
            this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private float b;
        private float z;
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
                b = Main.rand.Next(-50, 50);
                initialization = false;
            }
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 480+ (float)b)
            {
                projectile.scale *= 0.992f;
            }
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.3f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0f / 255f *projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D t = Main.projectileTexture[projectile.type];
             int frameHeight = t.Height / Main.projFrames[projectile.type];
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                Color color = (Color.Wheat * 0.2f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame, t.Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            if (projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球棕light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft - 300) / (10000f * z * z), projectile.scale * (projectile.timeLeft - 500) / (10000f * z * z), projectile.scale * (projectile.timeLeft - 500) / (10000f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (800 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return true;

		}
    }
}