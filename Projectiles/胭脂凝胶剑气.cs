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
    public class 胭脂凝胶剑气 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("胭脂凝胶剑气");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
			base.projectile.width = 54;
			base.projectile.height = 54;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 480;
			base.projectile.localNPCHitCooldown = 6;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 55;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            base.projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.03f;
            base.projectile.velocity.X *= 0.99f;
            base.projectile.velocity.Y *= 0.99f;
            Lighting.AddLight(base.projectile.Center, (float)projectile.timeLeft / 1200f, 0f, 0f);
            Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), (float)projectile.timeLeft / 480f);
		}
		// Token: 0x06002223 RID: 8739 RVA: 0x001B7D7C File Offset: 0x001B5F7C
		public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 45; i++)
            {
                int num1 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 183, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 6f, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 6f, 150, Color.Red, 0.4f);
                Main.dust[num1].noGravity = true;
            }
            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
	}
}