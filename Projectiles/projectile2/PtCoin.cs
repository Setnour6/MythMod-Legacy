using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
	public class PtCoin : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铂金钱");
            Main.projFrames[projectile.type] = 4; /*【帧数为6】对应的贴图也要画6帧哦*/
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 24;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
		}
        public float num2 = 0;
        public override void AI()
        {
            if(num2 == 0)
            {
                num2 = Main.rand.Next(-100, 100) / 1000f;
            }
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 3)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 3)
            {
                base.projectile.frame = 0;
            }
            projectile.rotation += num2;
            projectile.velocity.Y += 0.15f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 49, 0, 0, 0, default(Color), 1);
            }
            base.projectile.Kill();
            projectile.timeLeft = 0;
            return false;
        }
        // Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
        public override void Kill(int timeLeft)
		{
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 37, 0.5f, 0f);
        }

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
