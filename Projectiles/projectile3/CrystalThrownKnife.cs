using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class CrystalThrownKnife : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("晶体投刃");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate =1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.thrown = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 240), base.projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            return false;
        }
        public override void AI()
        {
            if(projectile.velocity.Length() < 15f)
            {
                projectile.rotation += 0.15f;
            }
            else
            {
                projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X)) + (float)Math.PI * 0.25f;
            }
            projectile.velocity *= 0.98f;
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            if (timeLeft != 0)
            {
                for (int a = 0; a < 12; a++)
                {
                    Vector2 vector = base.projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.15f) * 0.1f;
                }
            }
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块1"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块2"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块3"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块4"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
