using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 橄榄石长枪2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("橄榄石长枪");
		}
        private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
            base.projectile.width = 36;
            base.projectile.height = 36;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 5;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 480;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
		}
		public override void AI()
		{
            if (initialization)
            {
                X = Main.rand.Next(0,10);
				initialization = false;
            }
			Lighting.AddLight(base.projectile.Center, 0.25f, 0.65f, 0f);
			if (base.projectile.localAI[1] > 70f)
			{
				int num = Dust.NewDust(new Vector2((float)base.projectile.position.X + 18f,(float)base.projectile.position.Y + 15f), (int)(projectile.velocity.X * 0.4f), (int)(projectile.velocity.Y * 0.4f), mod.DustType("Olivine"), base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
				Main.dust[num].noGravity = true;
			}
            int num2 = Dust.NewDust(new Vector2((float)base.projectile.position.X + 18f,(float)base.projectile.position.Y + 15f), (int)(projectile.velocity.X * 0.3f), (int)(projectile.velocity.Y * 0.3f), mod.DustType("Olivine"), base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
            int num1 = Dust.NewDust(new Vector2((float)base.projectile.position.X + 18f,(float)base.projectile.position.Y + 15f), (int)(projectile.velocity.X * 0.5f), (int)(projectile.velocity.Y * 0.5f), mod.DustType("Olivine"), base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1f);
            Main.dust[num1].noGravity = true;
            Main.dust[num2].noGravity = true;
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, base.projectile.GetAlpha(lightColor), base.projectile.rotation, Utils.Size(texture2D) / 2f, base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 0));
            }
        }
    }
}
