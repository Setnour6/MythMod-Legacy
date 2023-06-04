using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class FireFlame : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("爆炸");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 210;
			base.Projectile.height = 210;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
            base.Projectile.tileCollide = false;
            base.Projectile.timeLeft = 50;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
            base.Projectile.scale = 0;

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 600);
        }
        private bool boom = false;
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            if(Main.rand.Next(20) == 1 && !boom)
            {
                boom = true;
            }
            if(boom && base.Projectile.scale <= 0.6f)
            {
                base.Projectile.scale += 0.05f;
            }
            else
            {
                base.Projectile.scale += (float)(1 - base.Projectile.scale) / 8f;
            }
            if (base.Projectile.timeLeft <= 32)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 4)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 188, v.X, v.Y, 201, default(Color), (32 - Projectile.timeLeft) / 4f);
                Main.dust[num5].velocity = v;
            }
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.Projectile.timeLeft > 30)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(base.Projectile.timeLeft / 30f, base.Projectile.timeLeft / 30f, base.Projectile.timeLeft / 30f, 0));
            }
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
