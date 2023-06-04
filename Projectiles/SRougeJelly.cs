using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200054D RID: 1357
    public class SRougeJelly : ModProjectile
	{
		// Token: 0x06001DBA RID: 7610 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("胭脂果冻");
            Main.projFrames[Projectile.type] = 7;
        }
        private float num16 = 0;
        // Token: 0x06001DBB RID: 7611 RVA: 0x0017EE28 File Offset: 0x0017D028
        public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 80;
			base.Projectile.timeLeft = 200;
			base.Projectile.penetrate = 1;
			base.Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            num16 += 0.15f;
            if(num16 > 7)
            {
                num16 = 0;
            }
            base.Projectile.frame = (int)num16;
            Lighting.AddLight(base.Projectile.Center, 0.6f, 0f, 0f);
            Projectile projectile = base.Projectile;
            projectile.velocity.X = projectile.velocity.X * 0.99f;
            Projectile projectile2 = base.Projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.99f;
            Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            if (base.Projectile.frameCounter > 7)
            {
                num16 += 0.15f;
                base.Projectile.frame = (int)num16;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 6)
            {
                base.Projectile.frame = 0;
                num16 = 0;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num17 = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num17 * base.Projectile.frame;
            Vector2 origin = new Vector2(14f, 14f);
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/超级胭脂果冻Glow"), base.Projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num17)), new Color(255, 255, 255, 0), base.Projectile.rotation, origin, base.Projectile.scale, SpriteEffects.None, 0f);
        }
        // Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
        public override void Kill(int timeLeft)
		{
            for (int j = 0; j < 12; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(4f, 9f)).RotatedByRandom(Math.PI * 2d);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X ,v.Y, base.Mod.Find<ModProjectile>("GlowingTouch").Type, (int)((double)base.Projectile.damage * 0.75), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                v = new Vector2(0, Main.rand.NextFloat(2f, 6f)).RotatedByRandom(Math.PI * 2d);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("LiRougeJelly").Type, (int)((double)base.Projectile.damage * 0.9), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
	}
}
