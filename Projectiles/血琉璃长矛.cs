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
	// Token: 0x02000579 RID: 1401
    public class 血琉璃长矛 : ModProjectile
	{
		// Token: 0x06001E9E RID: 7838 RVA: 0x0000C77A File Offset: 0x0000A97A
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("血琉璃长矛");
		}

		// Token: 0x06001E9F RID: 7839 RVA: 0x00178250 File Offset: 0x00176450
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.aiStyle = 19;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.timeLeft = 19;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.hostile = false;
			base.Projectile.tileCollide = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.penetrate = -1;
			base.Projectile.ownerHitCheck = true;
			base.Projectile.hide = true;
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x00189544 File Offset: 0x00187744
		public override void AI()
		{
			Main.player[base.Projectile.owner].direction = base.Projectile.direction;
			Main.player[base.Projectile.owner].heldProj = base.Projectile.whoAmI;
			Main.player[base.Projectile.owner].itemTime = Main.player[base.Projectile.owner].itemAnimation;
			base.Projectile.position.X = Main.player[base.Projectile.owner].position.X + (float)(Main.player[base.Projectile.owner].width / 2) - (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = Main.player[base.Projectile.owner].position.Y + (float)(Main.player[base.Projectile.owner].height / 2) - (float)(base.Projectile.height / 2);
			base.Projectile.position += base.Projectile.velocity * base.Projectile.ai[0];
			if (Main.rand.Next(4) == 0)
			{
			}
			if (base.Projectile.ai[0] == 0f)
			{
				base.Projectile.ai[0] = 3f;
				base.Projectile.netUpdate = true;
			}
            if (Main.player[base.Projectile.owner].itemAnimation < Main.player[base.Projectile.owner].itemAnimationMax / 3)
            {
                base.Projectile.ai[0] -= 2.4f;
                if (base.Projectile.localAI[0] == 0f && Main.myPlayer == base.Projectile.owner)
                {
                    base.Projectile.localAI[0] = 1f;
                }
                base.Projectile.ai[0] -= 2.4f;
                if (base.Projectile.localAI[0] == 0f && Main.myPlayer == base.Projectile.owner)
                {
                    base.Projectile.localAI[0] = 1f;
                    Projectile.NewProjectile(base.Projectile.Center.X + base.Projectile.velocity.X * base.Projectile.ai[0], base.Projectile.Center.Y + base.Projectile.velocity.Y * base.Projectile.ai[0], base.Projectile.velocity.X * 1.4f, base.Projectile.velocity.Y * 1.4f, base.Mod.Find<ModProjectile>("血琉璃长矛4").Type, (int)((double)base.Projectile.damage * 0.8), base.Projectile.knockBack * 0.85f, base.Projectile.owner, 0f, 0f);
                }
            }
            else
			{
				base.Projectile.ai[0] += 0.95f;
			}
			if (Main.player[base.Projectile.owner].itemAnimation == 0)
			{
				base.Projectile.Kill();
			}
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 2.355f;
			if (base.Projectile.spriteDirection == -1)
			{
				base.Projectile.rotation -= 1.57f;
			}
		}
        // Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/血琉璃长矛_Glow"), base.Projectile.Center - Main.screenPosition, null, Color.White, base.Projectile.rotation, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
        }
		// Token: 0x06001EA1 RID: 7841 RVA: 0x00189878 File Offset: 0x00187A78
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
