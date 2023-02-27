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
			base.projectile.width = 20;
			base.projectile.aiStyle = 19;
			base.projectile.melee = true;
			base.projectile.timeLeft = 19;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.penetrate = -1;
			base.projectile.ownerHitCheck = true;
			base.projectile.hide = true;
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x00189544 File Offset: 0x00187744
		public override void AI()
		{
			Main.player[base.projectile.owner].direction = base.projectile.direction;
			Main.player[base.projectile.owner].heldProj = base.projectile.whoAmI;
			Main.player[base.projectile.owner].itemTime = Main.player[base.projectile.owner].itemAnimation;
			base.projectile.position.X = Main.player[base.projectile.owner].position.X + (float)(Main.player[base.projectile.owner].width / 2) - (float)(base.projectile.width / 2);
			base.projectile.position.Y = Main.player[base.projectile.owner].position.Y + (float)(Main.player[base.projectile.owner].height / 2) - (float)(base.projectile.height / 2);
			base.projectile.position += base.projectile.velocity * base.projectile.ai[0];
			if (Main.rand.Next(4) == 0)
			{
			}
			if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = 3f;
				base.projectile.netUpdate = true;
			}
            if (Main.player[base.projectile.owner].itemAnimation < Main.player[base.projectile.owner].itemAnimationMax / 3)
            {
                base.projectile.ai[0] -= 2.4f;
                if (base.projectile.localAI[0] == 0f && Main.myPlayer == base.projectile.owner)
                {
                    base.projectile.localAI[0] = 1f;
                }
                base.projectile.ai[0] -= 2.4f;
                if (base.projectile.localAI[0] == 0f && Main.myPlayer == base.projectile.owner)
                {
                    base.projectile.localAI[0] = 1f;
                    Projectile.NewProjectile(base.projectile.Center.X + base.projectile.velocity.X * base.projectile.ai[0], base.projectile.Center.Y + base.projectile.velocity.Y * base.projectile.ai[0], base.projectile.velocity.X * 1.4f, base.projectile.velocity.Y * 1.4f, base.mod.ProjectileType("血琉璃长矛4"), (int)((double)base.projectile.damage * 0.8), base.projectile.knockBack * 0.85f, base.projectile.owner, 0f, 0f);
                }
            }
            else
			{
				base.projectile.ai[0] += 0.95f;
			}
			if (Main.player[base.projectile.owner].itemAnimation == 0)
			{
				base.projectile.Kill();
			}
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 2.355f;
			if (base.projectile.spriteDirection == -1)
			{
				base.projectile.rotation -= 1.57f;
			}
		}
        // Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/血琉璃长矛_Glow"), base.projectile.Center - Main.screenPosition, null, Color.White, base.projectile.rotation, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
        }
		// Token: 0x06001EA1 RID: 7841 RVA: 0x00189878 File Offset: 0x00187A78
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
