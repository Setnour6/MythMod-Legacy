using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.BloodyTusk
{
	// Token: 0x02000512 RID: 1298
    public class TuskArrow : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("TuskArrow");
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 3600;
            base.projectile.ranged = true;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        private bool stick = false;
        private int u = 0;
        private NPC m = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        private int r = 0;
        private float r2 = 0;
        Vector2 pc2 = Vector2.Zero;
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + (float)Math.PI * 0.5f;//让你的特效正常化
            Player player = Main.player[Main.myPlayer];
            base.projectile.spriteDirection = 1;
            if (stick && m.active)
            {
                r += 1;
                float yz = m.Hitbox.Width * m.Hitbox.Width + m.Hitbox.Height * m.Hitbox.Height;
                yz = (float)(Math.Sqrt(yz)) / 3f;
                projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, mod.ProjectileType("TuskDamage"), projectile.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                }
                projectile.velocity = v;
            }
            if (stick && !m.active)
            {
                projectile.active = false;
            }
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = projectile.velocity;
            projectile.friendly = false;
            m = target;
            if (!target.boss)
            {
                target.defense /= 2;
            }
        }
    }
}
