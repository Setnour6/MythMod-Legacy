using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
	public class SnowPiece : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("雪花");
            Main.projFrames[projectile.type] = 9; /*【帧数为6】对应的贴图也要画6帧哦*/
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 52;
			base.projectile.height = 58;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
			base.projectile.magic = true;
		}
        public float num2 = 0;
        // Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
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
            if (base.projectile.frame > 8)
            {
                base.projectile.frame = 0;
            }
            projectile.rotation += num2;
            projectile.velocity.Y += 0.15f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            base.projectile.velocity = oldVelocity;
            for (int i = 0; i < 70; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 59, projectile.velocity.X * i / 70f, projectile.velocity.Y * i / 70f, 100, default(Color), 2f);
                Main.dust[num].velocity = projectile.velocity * i / 70f;
                Main.dust[num].noGravity = true;
            }
            projectile.timeLeft = 0;
            return false;
        }
        // Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
        public override void Kill(int timeLeft)
		{
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
