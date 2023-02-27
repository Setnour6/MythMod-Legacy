using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.BloodyTusk
{
	// Token: 0x0200058D RID: 1421
    public class TuskPin : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("TuskPin");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 3600;
			base.projectile.alpha = 0;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
        // Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
        private bool stick = false;
        private int u = 0;
        private NPC m = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        private int r = 0;
        private float r2 = 0;
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(stick && m.active)
            {
                r += 1;
                float yz = m.Hitbox.Width * m.Hitbox.Width + m.Hitbox.Height * m.Hitbox.Height;
                yz = (float)(Math.Sqrt(yz)) / 3f;
                projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, mod.ProjectileType("TuskDamage"), projectile.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            if(stick && !m.active)
            {
                projectile.active = false;
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = projectile.position - target.position;
            projectile.friendly = false;
            m = target;
            if(!target.boss)
            {
                target.defense /= 2;
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
