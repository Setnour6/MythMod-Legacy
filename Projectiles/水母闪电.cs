using Terraria.GameContent;
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
			Main.projFrames[base.Projectile.type] = 4;
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
		public override void SetDefaults()
		{
			base.Projectile.width = 50;
			base.Projectile.height = 200;
			base.Projectile.friendly = false;
			base.Projectile.hostile = false;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 30;
			base.Projectile.alpha = 0;
			base.Projectile.tileCollide = false;
		}
		// Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
		public override void AI()
		{
			if(num6)
			{
				num7 = Main.rand.Next(4);
				num6 = false;
				vector3 = base.Projectile.Center;
			}
			base.Projectile.frame = (int)num7;
			if (Projectile.timeLeft < 12 && Projectile.timeLeft > 18)
            {
                Projectile.hostile = false;
            }
			else
			{
				Projectile.hostile = true;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
		public override Color? GetAlpha(Color lightColor)
		{
			if(base.Projectile.timeLeft >= 24)
			{
				num2 += 0.0014f;
			}
			if(base.Projectile.timeLeft >= 18 && base.Projectile.timeLeft < 24)
			{
				num2 -= 0.0022f;
			}
			if(base.Projectile.timeLeft >= 6 && base.Projectile.timeLeft < 18)
			{
				num2 += 0.006f;
			}
			if(base.Projectile.timeLeft < 6)
			{
				num2 -= 0.01f;
			}
			return new Color?(new Color(num2 * 5f, num2 * 0.15f * 5f, 0, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
        {
            float maxDistance = 10000f;
            float step = 200f;
            Vector2 unit = Projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation();
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
            for (float i = 0; i < maxDistance; i += step)
            {
				Texture2D texture;
				if(i == 0)
				{
					texture = base.Mod.GetTexture("Projectiles/代码杀射线发射端");
				}
				else
				{
					texture = TextureAssets.Projectile[Projectile.type].Value;
				}
				if(i > 2)
				{
					spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, vector3 + unit * (i + 190) - Main.screenPosition,  new Rectangle?(new Rectangle(0, y, texture.Width, num)),  base.Projectile.GetAlpha(lightColor), r - (float)Math.PI / 2f, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
				}
            }
			return false;
        }
		public override void CutTiles()
        {
            Vector2 unit = Projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance, (Projectile.width + 16) * Projectile.scale,  new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), base.Projectile.Center, base.Projectile.Center + unit * Distance, 14, ref point);
        }
	}
}
