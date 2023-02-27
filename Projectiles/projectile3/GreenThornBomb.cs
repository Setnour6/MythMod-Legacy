using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class GreenThornBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("青刺球炸弹");
            Main.projFrames[base.Projectile.type] = 5;
        }
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 38;
			base.Projectile.height = 38;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 3;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.aiStyle = -1;
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
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f + num;
            if (stick && md.active)
            {
                Projectile.velocity = md.velocity;
            }
            if (stick && !md.active)
            {
                stick = false;
            }
            if (Projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if (x)
            {
                num += m;
                if (m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (Projectile.velocity.Y < 15f && !x && !stick)
            {
                Projectile.velocity.Y += 0.2f;
            }
            if (Projectile.timeLeft <= 20)
            {
                if (Projectile.timeLeft % 5 == 2)
                {
                    if (Projectile.frame < 4)
                    {
                        Projectile.frame += 1;
                    }
                    else
                    {
                        Projectile.Kill();
                    }
                }
                S += 0.05f;
                Projectile.scale += 0.05f;
            }
            Dust.NewDust(new Vector2((float)Projectile.Center.X, (float)Projectile.Center.Y) + new Vector2(0, -10).RotatedBy(Projectile.rotation), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
        }
        private float S = 0;
        public override void PostDraw(Color lightColor)
        {
            for(int i = 0;i < S * 8;i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/GreenThornBomb"), base.Projectile.Center - Main.screenPosition, new Rectangle(0, Projectile.frame * 60, 38, 60), new Color(S, S, S, 0), base.Projectile.rotation, new Vector2(19f, 19f), Projectile.scale, SpriteEffects.None, 0f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = Projectile.position - target.position;
            Projectile.friendly = false;
            md = target;
            if (!HitBoom)
            {
                Projectile.timeLeft = 20;
            }
        }
        private NPC md = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                if(Projectile.velocity.Length() > 0.5f)
                {
                    if (base.Projectile.velocity.X != oldVelocity.X)
                    {
                        base.Projectile.velocity.X = -oldVelocity.X;
                    }
                    if (base.Projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.Projectile.velocity.Y = -oldVelocity.Y;
                    }
                }
                else
                {
                    base.Projectile.velocity.Y *= 0;
                    base.Projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            MythPlayer mplayer = Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Shake = 3;
            SoundEngine.PlaySound(SoundID.Item36, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int j = 0; j < 15; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6.2f,7f)).RotatedByRandom(Math.PI * 2) * Main.rand.Next(1500, 2000) / 1000f;
                int zi = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Cyanline").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            int num10 = 0;
            for (int i = 0; i < 90; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2.4 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y) + v * 20f, base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, 0f, 0f, 100, Color.White, (float)(12f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
                Main.dust[num5].rotation = Main.rand.NextFloat(0, (float)(MathHelper.TwoPi));
            }
        }
	}
}
