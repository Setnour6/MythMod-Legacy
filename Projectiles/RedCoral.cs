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
    public class RedCoral : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("红珊瑚");
        }
        private bool num100 = true;
        private Vector2 v = new Vector2(0, 0);
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = (int)1.5f;
            projectile.timeLeft = 450;
            projectile.alpha = 0;
            projectile.penetrate = 2;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 30;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void AI()
        {
            int num12 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 60, 0f, 0f, 0, default(Color), 1.5f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            if (num100)
            {
                float num7 = Main.rand.Next(-2000, 2000) / 40000f;
                v = projectile.velocity.RotatedBy(Math.PI * num7) * Main.rand.Next(9000, 11000) / 10000f;
                if (base.projectile.ai[0] != 0)
                {
                    float num6 = Main.rand.Next(0, 20000) / 10000f;
                    projectile.velocity = projectile.velocity.RotatedBy(Math.PI * num6);
                    projectile.timeLeft = (int)(200 / projectile.ai[0]);
                }
                num100 = false;
            }
            if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 5f)
            {
                base.projectile.velocity *= 1.2f;
            }
            if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 6f)
            {
                base.projectile.velocity *= 0.96f;
            }
            projectile.velocity = projectile.velocity * 0.95f + v * 0.2f;
            projectile.velocity = projectile.velocity.RotatedBy(Main.rand.Next(-200, 200) / 1000f);
            base.projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            NPC target = null;
            float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 400f;
            bool flag = false;
            if(Main.rand.Next(0, (int)(20 * (base.projectile.ai[0] + 1) * (base.projectile.ai[0] + 1))) == 5 && base.projectile.ai[0] < 5 && projectile.timeLeft <= 420 && !WeakeningFlag)
            {
                int num5 = Main.rand.Next(2, 4);
                for(int i = 0; i < num5; i++)
                {
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("RedCoral"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, base.projectile.ai[0] + 1, 0f);
                }
                projectile.velocity = new Vector2(0, 0);
                projectile.timeLeft = 30;
            }
            if (WeakeningFlag)
            {
                projectile.velocity *= 0.95f;
            }
        }
        public bool WeakeningFlag = false;
        //14141414141414
        //14141414141414
        //14141414141414
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            projectile.timeLeft = 30;
            WeakeningFlag = true;
            return false;
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
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/红色"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/红色").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/红色"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/红色").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}