using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class EvilBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("魔焰法瓶");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            projectile.thrown = true;
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
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;
            if(projectile.timeLeft <= 250 && !x)
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
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
        }
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
                        base.projectile.velocity.X = -oldVelocity.X * 0.6f;
                    }
                    if (base.projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.projectile.velocity.Y = -oldVelocity.Y * 0.6f;
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
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 120; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("DarkF2"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("DarkF2"), 0f, 0f, 100, Color.White, (float)(16f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
            }
            /*for (int i = 0; i < 80; i++)
            {
                Vector2 v = new Vector2(0, 4f).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("littleEvilfire0"), projectile.damage, 0f, Main.myPlayer, 0, 0f);
            }*/
            for (int i = 0; i < 200; i++)
            {
                if((Main.npc[i].Center - projectile.Center).Length() < 50 && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                {
                    if(Main.rand.Next(100) > 25)
                    { 
                        Main.npc[i].StrikeNPC(projectile.damage, 0, 1, false);
                    }
                    else
                    {

                        Main.npc[i].StrikeNPC(projectile.damage, 0, 1, true);
                    }
                    Main.npc[i].AddBuff(153, 900);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                Vector2 v = (new Vector2(4, 4f).RotatedBy(projectile.rotation - Math.PI / 2d)).RotatedBy(Main.rand.NextFloat(-0.1f, 0.1f));
                int u = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("EvilSword3"), projectile.damage / 5, 0f, Main.myPlayer, 0, 0f);
                Main.projectile[u].timeLeft = 180;
            }
            for (int i = 0; i < 100; i++)
            {
                float S = Main.rand.NextFloat(0f, 40f);
                Vector2 v = (new Vector2(S, S).RotatedBy(projectile.rotation - Math.PI / 2d)).RotatedBy(Main.rand.NextFloat(-0.1f, 0.1f));
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("DarkF2"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(153, 900);
        }
	}
}
