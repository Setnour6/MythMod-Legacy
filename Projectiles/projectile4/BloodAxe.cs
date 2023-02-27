using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile4
{
    public class BloodAxe : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("冰寒血锋");
        }
		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 720;
			projectile.localNPCHitCooldown = 0;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 0;
		}
        private float Omega = 0.8f;
		public override void AI()
		{
            projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            Omega = (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.3f + 0.8f * projectile.timeLeft / 4000f;
            projectile.rotation -= Omega;
            if (Main.rand.Next((int)((720 - projectile.timeLeft) / 60) + 1) == 0 && projectile.timeLeft < 700)
            {
                int num90 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - new Vector2(4, 4) + new Vector2(-15, -15).RotatedBy(projectile.rotation), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f,2.5f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(-1.5f, -1.5f).RotatedBy(projectile.rotation) * Omega;
            }
            if(projectile.timeLeft < 710)
            {
                projectile.tileCollide = true;
            }
        }
		public override void Kill(int timeLeft)
		{
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - new Vector2(4, 4), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(projectile.timeLeft > 180)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((float)projectile.timeLeft / 180f, (float)projectile.timeLeft / 180f, (float)projectile.timeLeft / 180f, 0f));
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - new Vector2(4, 4), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            float p = (255 - projectile.alpha) / 255f;
            //Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, new Color((1 - p) / 255f, (1 - p) / 255f, (1 - p) / 255f, (1 - p) / 255f), projectile.rotation, new Vector2(22, 22), projectile.scale, effects, 0f);
            for (int i = 0; i < 15; i++)
            {
                //Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i), projectile.rotation + Omega * i * 0.1f, new Vector2(22, 22), projectile.scale, effects, 0f);
            }
            return true;
        }
    }
}