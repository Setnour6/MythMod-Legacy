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
    public class 鹿角珊瑚 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("鹿角珊瑚");
        }
        private bool num100 = true;
        private Vector2 v = new Vector2(0, 0);
        private Vector2 v2 = new Vector2(0, 0);
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = (int)1.5f;
            projectile.timeLeft = 40;
            projectile.alpha = 0;
            projectile.penetrate = 2;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void AI()
        {
            if (num100)
            {
                v = projectile.velocity.RotatedBy(Math.PI * 0.07f * (4 - projectile.ai[0])) * 0.95f;
                v2 = projectile.velocity.RotatedBy(Math.PI * -0.07f * (4 - projectile.ai[0])) * 0.95f;
                if (base.projectile.ai[0] != 0)
                {
                    projectile.timeLeft = (int)(projectile.ai[0] * 17f + 10);
                }
                num100 = false;
            }
            base.projectile.velocity *= 0.995f;
            base.projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            NPC target = null;
            float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 400f;
            bool flag = false;
            if (projectile.timeLeft == 24)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("鹿角珊瑚"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, projectile.ai[0] - 1, 0f);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v2.X, v2.Y, base.mod.ProjectileType("鹿角珊瑚"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, projectile.ai[0] - 1, 0f);
                projectile.velocity *= 0.1f;
            }
        }
        //14141414141414
        //14141414141414
        //14141414141414
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
            int frameHeight = 20;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            if(projectile.timeLeft < 80)
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * (((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length) / 80f * (float)projectile.timeLeft);
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/紫灰色"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/红色").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/紫灰色"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/红色").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}