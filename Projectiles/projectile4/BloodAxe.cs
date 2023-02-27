using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
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
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 720;
			Projectile.localNPCHitCooldown = 0;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 0;
		}
        private float Omega = 0.8f;
		public override void AI()
		{
            Projectile.alpha = (int)(55 + (float)(400 - (float)Projectile.timeLeft) / 2);
            Omega = (float)Math.Sqrt((float)Projectile.velocity.X * (float)Projectile.velocity.X + (float)Projectile.velocity.Y * (float)Projectile.velocity.Y) * 0.3f + 0.8f * Projectile.timeLeft / 4000f;
            Projectile.rotation -= Omega;
            if (Main.rand.Next((int)((720 - Projectile.timeLeft) / 60) + 1) == 0 && Projectile.timeLeft < 700)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4) + new Vector2(-15, -15).RotatedBy(Projectile.rotation), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f,2.5f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(-1.5f, -1.5f).RotatedBy(Projectile.rotation) * Omega;
            }
            if(Projectile.timeLeft < 710)
            {
                Projectile.tileCollide = true;
            }
        }
		public override void Kill(int timeLeft)
		{
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(Projectile.timeLeft > 180)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((float)Projectile.timeLeft / 180f, (float)Projectile.timeLeft / 180f, (float)Projectile.timeLeft / 180f, 0f));
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4), 4, 4, 183, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            float p = (255 - Projectile.alpha) / 255f;
            //Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, new Color((1 - p) / 255f, (1 - p) / 255f, (1 - p) / 255f, (1 - p) / 255f), projectile.rotation, new Vector2(22, 22), projectile.scale, effects, 0f);
            for (int i = 0; i < 15; i++)
            {
                //Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i, null, new Color(1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i, 1 - 1 / 15f * (float)i), projectile.rotation + Omega * i * 0.1f, new Vector2(22, 22), projectile.scale, effects, 0f);
            }
            return true;
        }
    }
}