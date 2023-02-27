﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
	// Token: 0x0200058D RID: 1421
    public class MagicHalo : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("符咒光环");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 500;
            base.projectile.scale = 1;
            base.projectile.height = 500;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 120;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
        public override void AI()
        {
            if(NPC.CountNPCS(mod.NPCType("CursedLavaStone")) > 0)
            {
                projectile.timeLeft = 120;
            }
            else
            {
                projectile.timeLeft = 1;
            }
            for(int i = 0;i < 200;i++)
            {
                if (Main.npc[i].type == mod.NPCType("CursedLavaStone"))
                {
                    projectile.Center = Main.npc[i].Center;
                }
            }
            projectile.rotation += 0.02f;
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(90,90,90, 0));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
