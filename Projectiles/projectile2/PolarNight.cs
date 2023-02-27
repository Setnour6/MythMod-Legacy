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

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000579 RID: 1401
    public class PolarNight : ModProjectile
	{
		// Token: 0x06001E9E RID: 7838 RVA: 0x0000C77A File Offset: 0x0000A97A
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("极夜封霜");
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
		// Token: 0x06001EA1 RID: 7841 RVA: 0x00189878 File Offset: 0x00187A78
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            for(int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, 344, (int)damage, 1, Main.myPlayer, 0f, 0f);
            }
            if(Main.rand.Next(5) == 1)
            {
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                {
                    target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, 60);
                    target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 62);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, 60);
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 62);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, 60);
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 62);
                        }
                    }
                }
            }
		}
	}
}
