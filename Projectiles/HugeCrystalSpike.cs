using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
    public class HugeCrystalSpike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("水晶锥");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 48;
			base.Projectile.height = 48;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 3600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
		}
		public override void AI()
		{
			float num = base.Projectile.Center.X;
			float num2 = base.Projectile.Center.Y;
			bool flag = false;

			if (flag)
			{
				float num7 = 35f;
				Vector2 vector = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num8 = num - vector.X;
				float num9 = num2 - vector.Y;
				float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num8) / 21f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num9) / 21f;
				return;
			}
		}
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 200), base.Projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int a = 0; a < 50; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Crystal").Type, v.X, v.Y, 0, default(Color), 1.4f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok1").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok2").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok3").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok4").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok1").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok2").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok3").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), base.Mod.Find<ModProjectile>("CrystalSpikeBrok4").Type, base.Projectile.damage / 7, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
        }
	}
}
