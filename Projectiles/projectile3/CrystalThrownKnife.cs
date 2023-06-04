using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class CrystalThrownKnife : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("晶体投刃");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate =1;
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
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 240), base.Projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            return false;
        }
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
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            if (timeLeft != 0)
            {
                for (int a = 0; a < 12; a++)
                {
                    Vector2 vector = base.Projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Crystal").Type, v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.15f) * 0.1f;
                }
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.Mod.Find<ModProjectile>("水晶碎块1").Type, base.Projectile.damage / 3, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.Mod.Find<ModProjectile>("水晶碎块2").Type, base.Projectile.damage / 3, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.Mod.Find<ModProjectile>("水晶碎块3").Type, base.Projectile.damage / 3, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.Mod.Find<ModProjectile>("水晶碎块4").Type, base.Projectile.damage / 3, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
	}
}
