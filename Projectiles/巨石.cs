using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 巨石 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巨石");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
			base.projectile.width = 66;
			base.projectile.height = 60;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 180;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 0;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			 base.projectile.velocity.Y += 0.15f;
		}
		// Token: 0x06002223 RID: 8739 RVA: 0x001B7D7C File Offset: 0x001B5F7C
		public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.velocity = projectile.velocity * 0.9f;
        }
        // Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/巨石_Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(33f, 30f), 1f, SpriteEffects.None, 0f);
        }
	}
}