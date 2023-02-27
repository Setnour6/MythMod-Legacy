using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
    public class 骨片飞刀 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("骨片飞刀");
		}
        private float num = 0;
        // Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
        public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 52;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.ranged = true;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;//让你的特效正常化
            if(projectile.timeLeft <= 250)
            {
                num += 0.15f;
            }
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
