using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class AgYuanbao : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("银元宝");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 80;
			base.Projectile.height = 44;
			base.Projectile.hostile = false;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = 0;
            if(Projectile.velocity.Y < 15f)
            {
                Projectile.velocity.Y += 0.2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
            Gore.NewGore(base.Projectile.position, base.Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块1"), 1f);
            Gore.NewGore(base.Projectile.position, base.Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
            Gore.NewGore(base.Projectile.position, base.Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
            Gore.NewGore(base.Projectile.position, base.Projectile.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块3"), 1f);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            target.velocity = Projectile.velocity * (float)Math.Sqrt(target.knockBackResist) * 0.75f;
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
