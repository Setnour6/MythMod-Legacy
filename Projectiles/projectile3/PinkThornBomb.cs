using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class PinkThornBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("粉刺球炸弹");
            Main.projFrames[base.projectile.type] = 5;
        }
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 38;
			base.projectile.height = 38;
            base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 3;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.ranged = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        private bool HitBoom = false;
        private bool stick = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;
            if (stick && md.active)
            {
                projectile.velocity = md.velocity;
            }
            if (stick && !md.active)
            {
                stick = false;
            }
            if (projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if(x)
            {
                num += m;
                if(m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (projectile.velocity.Y < 15f && !x && !stick)
            {
                projectile.velocity.Y += 0.2f;
            }
            if (projectile.timeLeft <= 20)
            {
                if (projectile.timeLeft % 5 == 2)
                {
                    if (projectile.frame < 4)
                    {
                        projectile.frame += 1;
                    }
                    else
                    {
                        projectile.Kill();
                    }
                }
                S += 0.05f;
                projectile.scale += 0.05f;
            }
            Dust.NewDust(new Vector2((float)projectile.Center.X, (float)projectile.Center.Y) + new Vector2(0, -10).RotatedBy(projectile.rotation), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
        }
        private float S = 0;
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int i = 0; i < S * 8; i++)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/PinkThornBomb"), base.projectile.Center - Main.screenPosition, new Rectangle(0, projectile.frame * 60, 38, 60), new Color(S, S, S, 0), base.projectile.rotation, new Vector2(19f, 19f), projectile.scale, SpriteEffects.None, 0f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = projectile.position - target.position;
            projectile.friendly = false;
            md = target;
            if(!HitBoom)
            {
                projectile.timeLeft = 20;
            }
        }
        private NPC md = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                if(projectile.velocity.Length() > 0.5f)
                {
                    if (base.projectile.velocity.X != oldVelocity.X)
                    {
                        base.projectile.velocity.X = -oldVelocity.X;
                    }
                    if (base.projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.projectile.velocity.Y = -oldVelocity.Y;
                    }
                }
                else
                {
                    base.projectile.velocity.Y *= 0;
                    base.projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            MythPlayer mplayer = Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Shake = 3;
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 36, 1f, 0f);
            /*for (int j = 0; j < 15; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(1.2f, 7f)).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                int zi = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Pinkline"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }*/
            int num10 = 0;
            for (int i = 0; i < 90; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("PinkFog"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y) + v * 20f, base.projectile.width, base.projectile.height, mod.DustType("PinkFog"), 0f, 0f, 100, Color.White, (float)(12f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
                Main.dust[num5].rotation = Main.rand.NextFloat(0, (float)(MathHelper.TwoPi));
            }
            for (int t = 0; t < 16; t++)
            {
                Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0, 12f)).RotatedByRandom(Math.PI * 2d);
                int y = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v2.X, v2.Y, mod.ProjectileType("FlowerpetalLig"), projectile.damage / 12, 0.5f, Main.myPlayer, 10f, 25f);
                Main.projectile[y].scale = Main.rand.NextFloat(0.9f, 1.1f);
                Main.projectile[y].frame = Main.rand.Next(0, 8);
                Main.projectile[y].penetrate = 3;
            }
        }
	}
}
