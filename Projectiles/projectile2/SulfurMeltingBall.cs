using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class SulfurMeltingBall : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("硫磺熔团");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 26;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        // Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
        public bool p = true;
        public float q = 0;
        public float num10 = 0;
        public override void AI()
		{
            if(p)
            {
                num10 = projectile.damage * 1.01f;
                q = Main.rand.Next(-250, 250) / 2000f;
                p = false;
            }
			base.projectile.spriteDirection = 1;
			base.projectile.rotation += q;
            if(projectile.timeLeft <= 540 && projectile.timeLeft > 300)
            {
                if(Main.rand.Next((projectile.timeLeft - 290)) < 10)
                {
                    int num = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num].noGravity = true;
                    int num2 = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 88, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num2].noGravity = true;
                }
            }
            if (projectile.timeLeft <= 300)
            {
                int num = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 88, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num2].noGravity = true;
            }
            if(projectile.velocity.Length() < 8f)
            {
                projectile.velocity *= 1.001f;
            }
            if (projectile.velocity.Length() < 9f)
            {
                projectile.velocity *= 1.001f;
            }
            if (projectile.velocity.Length() < 10f)
            {
                projectile.velocity *= 1.001f;
            }
            if (projectile.velocity.Length() < 12f)
            {
                projectile.velocity *= 1.001f;
            }
            if (projectile.velocity.Length() < 14f)
            {
                projectile.velocity *= 1.001f;
            }
            if (projectile.velocity.Length() < 17f)
            {
                projectile.velocity *= 1.001f;
            }
            if(projectile.timeLeft % 5 == 0)
            {
                num10 *= 1.02f;
            }
            projectile.damage = (int)num10;
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
            float num = 0;
            if (projectile.timeLeft > 540)
            {
                num = 0;
            }
            if (projectile.timeLeft <= 540 && projectile.timeLeft > 300)
            {
                num = (540 - projectile.timeLeft) / 480f;
            }
            if (projectile.timeLeft <= 300)
            {
                num = 0.5f;
            }
            return new Color?(new Color(num, num, num, 0));
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), new Color(255,255,255,255), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k / 2] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                if(k == 1)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow").Width, frameHeight), color, projectile.rotation, drawOrigin, 1.1f, SpriteEffects.None, 0f);
                    if(projectile.timeLeft <= 240)
                    {
                        spriteBatch.Draw(base.mod.GetTexture("Projectiles/SulfurFlame"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/SulfurFlame").Width, 210), color * ((240 - projectile.timeLeft) / 110f), 0, drawOrigin + new Vector2(92,92), 0.3f + (240 - projectile.timeLeft) / 600f, SpriteEffects.None, 0f);
                    }
                }
                if(k < 10)
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/projectile2/硫磺熔团Glow").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale * (51 - k) / 40f, SpriteEffects.None, 0f);
                }
            }
            
            return true;
		}
		public override void Kill(int timeLeft)
		{
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, ((600 - timeLeft) / 600f + 0.4f) * 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("SulfurFlame"), (int)((double)base.projectile.damage * 0.3f), base.projectile.knockBack, base.projectile.owner, ((600 - timeLeft) / 600f + 0.4f) / 20f, 0f);
            }
            for (int j = 0; j < 50; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(1500, 8000) / 500f * ((600 - timeLeft) / 600f + 0.4f)).RotatedByRandom(Math.PI * 2);
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 86, v.X, v.Y, 100, default(Color), 1.4f * ((600 - timeLeft) / 600f + 0.4f));
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 88, v.X, v.Y, 100, default(Color), 1.4f * ((600 - timeLeft) / 600f + 0.4f));
                Main.dust[num2].noGravity = true;
            }
            for (int j = 0; j < 50; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(1500, 8000) / 500f).RotatedByRandom(Math.PI * 2) * ((600 - timeLeft) / 600f + 0.4f);
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 86, v.X, v.Y, 100, default(Color), 2f * ((600 - timeLeft) / 600f + 0.4f));
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 88, v.X, v.Y, 100, default(Color), 2f * ((600 - timeLeft) / 600f + 0.4f));
                Main.dust[num2].noGravity = true;
            }
            for (int i = 0; i <= 25; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("SulfurDust"), (int)((double)base.projectile.damage * 0.5f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(990, 1500) / 1000f * ((600 - timeLeft) / 600f + 0.4f);
            }
        }
	}
}
