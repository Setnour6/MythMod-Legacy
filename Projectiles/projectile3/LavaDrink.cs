using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class LavaDrink : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔岩畅饮");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 36;
			base.projectile.height = 36;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
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
            int num = Dust.NewDust(projectile.Center - new Vector2(6,6) + new Vector2(0,-8).RotatedBy(projectile.rotation), 12, 12, mod.DustType("Flame2"), 0f, 0f, 0, default(Color), 3f);
            Main.dust[num].noGravity = false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            for (int i = 0; i < 42; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame2"), 0f, 0f, 0, default(Color), 4f);
                Main.dust[num].noGravity = true;
            }
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - projectile.position).Length() < 150)
                {
                    Main.npc[i].StrikeNPC((int)(projectile.damage / 6f * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1);
                    Main.npc[i].AddBuff(24, 600);
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(24, 600); 
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/LavaDrinkGlow"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.4f, 0.2f, 0), base.projectile.rotation, new Vector2(19f, 15f), 1f, SpriteEffects.None, 0f);
        }
    }
}
