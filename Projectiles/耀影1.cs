using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 耀影1 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("耀光");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.aiStyle = 27;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 3;
			base.Projectile.timeLeft = 300;
			base.Projectile.usesLocalNPCImmunity = true;
			base.Projectile.localNPCHitCooldown = 6;
            base.Projectile.extraUpdates = 1;
            base.Projectile.ignoreWater = true;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.3f / 255f, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 1f / 255f);
			if (base.Projectile.localAI[1] > 4f)
			{
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 55, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, default(Color), 2.2f);
				Main.dust[num].velocity *= 0.1f;
				Main.dust[num].noGravity = true;
			}
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x0000D817 File Offset: 0x0000BA17

		// Token: 0x06002222 RID: 8738 RVA: 0x00186290 File Offset: 0x00184490
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition, null, base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, Utils.Size(texture2D) / 2f, base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		// Token: 0x06002223 RID: 8739 RVA: 0x001B7D7C File Offset: 0x001B5F7C
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 7; i++)
			{
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 55, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 150, default(Color), 2.2f);
				Main.dust[num].noGravity = true;
			}
			//Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("光效"), base.projectile.damage, 0, Main.myPlayer, 0f, 0f);
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A

	}
}