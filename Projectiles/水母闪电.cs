using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Projectiles
{
	// Token: 0x020007D0 RID: 2000
    public class 水母闪电 : ModProjectile
	{
		// Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
		private float num4;
		private bool num5 = true;
		private float num7 = 0;
		private float num2 = 0;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("水母闪电");
			Main.projFrames[base.projectile.type] = 4;
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
		public override void SetDefaults()
		{
			base.projectile.width = 50;
			base.projectile.height = 200;
			base.projectile.friendly = false;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 30;
			base.projectile.alpha = 0;
			base.projectile.tileCollide = false;
		}
		// Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
		public override void AI()
		{
			if(num6)
			{
				num7 = Main.rand.Next(4);
				num6 = false;
				vector3 = base.projectile.Center;
			}
			base.projectile.frame = (int)num7;
			if (projectile.timeLeft < 12 && projectile.timeLeft > 18)
            {
                projectile.hostile = false;
            }
			else
			{
				projectile.hostile = true;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
		public override Color? GetAlpha(Color lightColor)
		{
			if(base.projectile.timeLeft >= 24)
			{
				num2 += 0.0014f;
			}
			if(base.projectile.timeLeft >= 18 && base.projectile.timeLeft < 24)
			{
				num2 -= 0.0022f;
			}
			if(base.projectile.timeLeft >= 6 && base.projectile.timeLeft < 18)
			{
				num2 += 0.006f;
			}
			if(base.projectile.timeLeft < 6)
			{
				num2 -= 0.01f;
			}
			return new Color?(new Color(num2 * 5f, num2 * 0.15f * 5f, 0, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float maxDistance = 10000f;
            float step = 200f;
            Vector2 unit = projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation();
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
            for (float i = 0; i < maxDistance; i += step)
            {
				Texture2D texture;
				if(i == 0)
				{
					texture = base.mod.GetTexture("Projectiles/代码杀射线发射端");
				}
				else
				{
					texture = Main.projectileTexture[projectile.type];
				}
				if(i > 2)
				{
					spriteBatch.Draw(Main.projectileTexture[projectile.type], vector3 + unit * (i + 190) - Main.screenPosition,  new Rectangle?(new Rectangle(0, y, texture.Width, num)),  base.projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f, SpriteEffects.None, 0f);
				}
            }
			return false;
        }
		public override void CutTiles()
        {
            Vector2 unit = projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance, (projectile.width + 16) * projectile.scale,  new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 unit = projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), base.projectile.Center, base.projectile.Center + unit * Distance, 14, ref point);
        }
	}
}
