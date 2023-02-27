using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class DiamondYuanbao : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("钻石元宝");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 80;
			base.projectile.height = 44;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = 0;
            if(projectile.velocity.Y < 15f)
            {
                projectile.velocity.Y += 0.2f;
            }
            for(int u = 0; u < 200; u++)
            {
                if((Main.npc[u].Center - projectile.Center).Length() < 40 && Main.npc[u].active)
                {
                    Main.npc[u].velocity = projectile.velocity;
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
            Gore.NewGore(base.projectile.position, base.projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻石元宝碎块1"), 1f);
            Gore.NewGore(base.projectile.position, base.projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻石元宝碎块2"), 1f);
            Gore.NewGore(base.projectile.position, base.projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻石元宝碎块2"), 1f);
            Gore.NewGore(base.projectile.position, base.projectile.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/钻石元宝碎块3"), 1f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 37, 1f, 0f);
            //target.velocity = projectile.velocity * (float)Math.Sqrt(target.knockBackResist + (target.knockBackResist > 0.1f ? 0 : 0.1f));
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
