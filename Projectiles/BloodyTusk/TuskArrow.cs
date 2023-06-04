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
            // base.DisplayName.SetDefault("TuskArrow");
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.Projectile.width = 26;
			base.Projectile.height = 30;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 65;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 3600;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.aiStyle = 1;
            this.AIType = 1;
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
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + (float)Math.PI * 0.5f;//让你的特效正常化
            Player player = Main.player[Main.myPlayer];
            base.Projectile.spriteDirection = 1;
            if (stick && m.active)
            {
                r += 1;
                float yz = m.Hitbox.Width * m.Hitbox.Width + m.Hitbox.Height * m.Hitbox.Height;
                yz = (float)(Math.Sqrt(yz)) / 3f;
                Projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, Mod.Find<ModProjectile>("TuskDamage").Type, Projectile.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                }
                Projectile.velocity = v;
            }
            if (stick && !m.active)
            {
                Projectile.active = false;
            }
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            stick = true;
            v = Projectile.velocity;
            Projectile.friendly = false;
            m = target;
            if (!target.boss)
            {
                target.defense /= 2;
            }
        }
    }
}
