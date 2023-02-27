using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
    public class 咒火弹 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("咒火弹");
            Main.projFrames[projectile.type] = 4; /*【帧数为6】对应的贴图也要画6帧哦*/
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 25;
			base.projectile.friendly = false;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 3000;
            base.projectile.hostile = true;
			base.projectile.magic = true;
		}

		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
		public override void Kill(int timeLeft)
		{
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 160;
			base.projectile.height = 160;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(39, 1800, false);
		}
	}
}
