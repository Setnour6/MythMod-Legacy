using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
	public class RedPack : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("红包");
            Main.projFrames[Projectile.type] = 4; /*【帧数为6】对应的贴图也要画6帧哦*/
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 24;
			base.Projectile.friendly = false;
            Projectile.hostile = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
		}
        private float num2 = 0;
        private float num3 = 0;
        private float num4 = 0;
        private float num5 = 0;
        // Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
        public override void AI()
        {
            if(num2 == 0)
            {
                num2 = Main.rand.Next(-100, 100) / 1000f;
                num3 = Main.rand.Next(-100, 100);
                num4 = Main.rand.Next(-10000, 10000) / 3000f;
                num5 = Main.rand.Next(8000, 13000) / 1000f;
            }
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 3)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 3)
            {
                base.Projectile.frame = 0;
            }
            Projectile.rotation += num2;
            if(Projectile.velocity.Y < 3f)
            {
                Projectile.velocity.Y += 0.05f;
            }
            num3 += 1;
            Projectile.velocity.X = (float)Math.Sin(num3 / num5) * num4;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 218, 0, 0, 0, default(Color), 1);
            }
            base.Projectile.Kill();
            Projectile.timeLeft = 0;
            return false;
        }
        // Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
        public override void Kill(int timeLeft)
		{

        }

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
	}
}
