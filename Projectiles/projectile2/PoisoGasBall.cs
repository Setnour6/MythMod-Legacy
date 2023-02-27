using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class PoisoGasBall : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("毒气弹");
			Main.projFrames[base.Projectile.type] = 1;
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(20, Projectile.timeLeft * 2, true);
            target.AddBuff(70, Projectile.timeLeft / 2, true);
        }
        // Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
        public override void SetDefaults()
		{
			base.Projectile.width = 34;
			base.Projectile.height = 34;
			base.Projectile.hostile = true;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        // Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
        public bool p = true;
        public float q = 0;
        public float num10 = 0;
        public override void AI()
		{
            if(p)
            {
                num10 = Projectile.damage * 1.01f;
                q = Main.rand.Next(-250, 250) / 2000f;
                p = false;
            }
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation += q;
            if(Projectile.timeLeft <= 540 && Projectile.timeLeft > 300)
            {
                if(Main.rand.Next((Projectile.timeLeft - 290)) < 10)
                {
                    int num = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num].noGravity = true;
                    int num2 = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 88, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num2].noGravity = true;
                }
            }
            if (Projectile.timeLeft <= 300)
            {
                int num = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 88, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num2].noGravity = true;
            }
            if(Projectile.velocity.Length() < 8f)
            {
                Projectile.velocity *= 1.001f;
            }
            if (Projectile.velocity.Length() < 9f)
            {
                Projectile.velocity *= 1.001f;
            }
            if (Projectile.velocity.Length() < 10f)
            {
                Projectile.velocity *= 1.001f;
            }
            if (Projectile.velocity.Length() < 12f)
            {
                Projectile.velocity *= 1.001f;
            }
            if (Projectile.velocity.Length() < 14f)
            {
                Projectile.velocity *= 1.001f;
            }
            if (Projectile.velocity.Length() < 17f)
            {
                Projectile.velocity *= 1.001f;
            }
            if(Projectile.timeLeft % 5 == 0)
            {
                num10 *= 1.02f;
            }
            Projectile.velocity.Y += 0.05f;
            Projectile.damage = (int)num10;
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
            float num = 0;
            if (Projectile.timeLeft > 540)
            {
                num = 0;
            }
            if (Projectile.timeLeft <= 540 && Projectile.timeLeft > 300)
            {
                num = (540 - Projectile.timeLeft) / 480f;
            }
            if (Projectile.timeLeft <= 300)
            {
                num = 0.5f;
            }
            return new Color?(new Color(num, num, num, 0));
        }

        public override bool PreDraw(ref Color lightColor)
		{
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), new Color(255,255,255,255), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k / 2] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                if(k == 1)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow").Width, frameHeight), color, Projectile.rotation, drawOrigin, 1.1f, SpriteEffects.None, 0f);
                }
                if(k < 10)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/projectile2/毒气弹Glow").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale * (51 - k) / 40f, SpriteEffects.None, 0f);
                }
            }
            
            return true;
		}
		public override void Kill(int timeLeft)
		{
            for(int g = 0; g < 30;g++)
            {
                Vector2 v = new Vector2(0, 30).RotatedBy(Math.PI / 15f * g);
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("PoisonGas").Type, 120, 0f, Main.myPlayer, 120f, 0f);
            }
        }
	}
}
