using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200054D RID: 1357
    public class SRougeJelly : ModProjectile
	{
		// Token: 0x06001DBA RID: 7610 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("胭脂果冻");
            Main.projFrames[projectile.type] = 7;
        }
        private float num16 = 0;
        // Token: 0x06001DBB RID: 7611 RVA: 0x0017EE28 File Offset: 0x0017D028
        public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.alpha = 80;
			base.projectile.timeLeft = 200;
			base.projectile.penetrate = 1;
			base.projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            num16 += 0.15f;
            if(num16 > 7)
            {
                num16 = 0;
            }
            base.projectile.frame = (int)num16;
            Lighting.AddLight(base.projectile.Center, 0.6f, 0f, 0f);
            Projectile projectile = base.projectile;
            projectile.velocity.X = projectile.velocity.X * 0.99f;
            Projectile projectile2 = base.projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.99f;
            Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            if (base.projectile.frameCounter > 7)
            {
                num16 += 0.15f;
                base.projectile.frame = (int)num16;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 6)
            {
                base.projectile.frame = 0;
                num16 = 0;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num17 = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num17 * base.projectile.frame;
            Vector2 origin = new Vector2(14f, 14f);
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/超级胭脂果冻Glow"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num17)), new Color(255, 255, 255, 0), base.projectile.rotation, origin, base.projectile.scale, SpriteEffects.None, 0f);
        }
        // Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
        public override void Kill(int timeLeft)
		{
            for (int j = 0; j < 12; j++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(4f, 9f)).RotatedByRandom(Math.PI * 2d);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X ,v.Y, base.mod.ProjectileType("GlowingTouch"), (int)((double)base.projectile.damage * 0.75), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                v = new Vector2(0, Main.rand.NextFloat(2f, 6f)).RotatedByRandom(Math.PI * 2d);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("LiRougeJelly"), (int)((double)base.projectile.damage * 0.9), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
	}
}
