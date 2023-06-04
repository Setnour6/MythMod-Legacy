using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class LavaDrink : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("熔岩畅饮");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 36;
			base.Projectile.height = 36;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            base.Projectile.DamageType = DamageClass.Throwing;
            base.Projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if(Projectile.velocity.Length() < 15f)
            {
                Projectile.rotation += 0.15f;
            }
            else
            {
                Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X)) + (float)Math.PI * 0.25f;
            }
            Projectile.velocity *= 0.98f;
            if (Projectile.velocity.Y < 15f && !x)
            {
                Projectile.velocity.Y += 0.2f;
            }
            int num = Dust.NewDust(Projectile.Center - new Vector2(6,6) + new Vector2(0,-8).RotatedBy(Projectile.rotation), 12, 12, Mod.Find<ModDust>("Flame2").Type, 0f, 0f, 0, default(Color), 3f);
            Main.dust[num].noGravity = false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int i = 0; i < 42; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame2").Type, 0f, 0f, 0, default(Color), 4f);
                Main.dust[num].noGravity = true;
            }
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("火山溅射").Type, base.Projectile.damage / 2, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - Projectile.position).Length() < 150)
                {
                    Main.npc[i].StrikeNPC((int)(Projectile.damage / 6f * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1);
                    Main.npc[i].AddBuff(24, 600);
                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            target.AddBuff(24, 600); 
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/LavaDrinkGlow"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.4f, 0.2f, 0), base.Projectile.rotation, new Vector2(19f, 15f), 1f, SpriteEffects.None, 0f);
        }
    }
}
