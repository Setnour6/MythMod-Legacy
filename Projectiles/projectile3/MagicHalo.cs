using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			base.Projectile.width = 500;
            base.Projectile.scale = 1;
            base.Projectile.height = 500;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 120;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
		}
        public override void AI()
        {
            if(NPC.CountNPCS(Mod.Find<ModNPC>("CursedLavaStone").Type) > 0)
            {
                Projectile.timeLeft = 120;
            }
            else
            {
                Projectile.timeLeft = 1;
            }
            for(int i = 0;i < 200;i++)
            {
                if (Main.npc[i].type == Mod.Find<ModNPC>("CursedLavaStone").Type)
                {
                    Projectile.Center = Main.npc[i].Center;
                }
            }
            Projectile.rotation += 0.02f;
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(90,90,90, 0));
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
