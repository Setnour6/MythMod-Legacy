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
    public class 小星渊凝胶剑气 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("小星渊凝胶剑气");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
			base.Projectile.width = 22;
			base.Projectile.height = 46;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 120;
			base.Projectile.localNPCHitCooldown = 6;
            base.Projectile.extraUpdates = 1;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.alpha = 55;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            base.Projectile.alpha = (int)(55 + (float)(120 - (float)Projectile.timeLeft) * 5 / 3);
            base.Projectile.rotation -= (float)Math.Sqrt((float)Projectile.velocity.X * (float)Projectile.velocity.X + (float)Projectile.velocity.Y * (float)Projectile.velocity.Y) * 0.1f;
            base.Projectile.velocity.X *= 0.97f;
            base.Projectile.velocity.Y *= 0.97f;
            Lighting.AddLight(base.Projectile.Center, (float)Projectile.timeLeft / 600f, 0f, 0f);
            Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), (float)Projectile.timeLeft / 150f);
            Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("GoldGlitter").Type, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), (float)Projectile.timeLeft / 90f);
		}
		// Token: 0x06002223 RID: 8739 RVA: 0x001B7D7C File Offset: 0x001B5F7C
		public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 45; i++)
            {
                int num1 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 183, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 6f, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 6f, 150, Color.Red, 0.5f);
                Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("GoldGlitter").Type, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 0.4f);
                Main.dust[num1].noGravity = true;
            }
            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
        // Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/小星渊凝胶剑气_Glow"), base.Projectile.Center - Main.screenPosition, null, Color.Yellow * ((float)Projectile.timeLeft / 120f), base.Projectile.rotation, new Vector2(11f, 23f), 1f, SpriteEffects.None, 0f);
        }
	}
}