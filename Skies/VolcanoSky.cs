using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Skies
{
	public class VolcanoSky : CustomSky
	{
		public override void Deactivate(params object[] args)
		{
			this.skyActive = false;
		}
		public override void Reset()
		{
			this.skyActive = false;
		}
		public override bool IsActive()
		{
			return this.skyActive || this.opacity > 0f;
		}
		public override void Activate(Vector2 position, params object[] args)
		{
			this.skyActive = true;
		}
        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
			{
				spriteBatch.Draw(mod.GetTexture("Skies/VolcanoSky"), new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.bgColor * this.opacity);
				if (Main.netMode != 2)
				{
					for (int i = 0; i < Main.star.Length; i++)
					{
						Star star = Main.star[i];
						if (star != null)
						{
							Texture2D texture2D = Main.starTexture[star.type];
							Vector2 origin = new Vector2((float)texture2D.Width * 0.5f, (float)texture2D.Height * 0.5f);
							int num = (int)((double)(-(double)Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
							float num2 = star.position.X * ((float)Main.screenWidth / 800f);
							float num3 = star.position.Y * ((float)Main.screenHeight / 600f);
							Vector2 position = new Vector2(num2 + origin.X, num3 + origin.Y + (float)num);
							spriteBatch.Draw(texture2D, position, new Rectangle?(new Rectangle(0, 0, texture2D.Width, texture2D.Height)), Color.White * star.twinkle * 0.952f * this.opacity, star.rotation, origin, star.scale * star.twinkle, SpriteEffects.None, 0f);
						}
					}
				}
			}
		}
        public override void Update(GameTime gameTime)
		{
			if (this.skyActive && this.opacity < 1f)
			{
				this.opacity += 0.02f;
				return;
			}
			if (!this.skyActive && this.opacity > 0f)
			{
				this.opacity -= 0.02f;
			}
		}
		public override float GetCloudAlpha()
		{
			return (1f - this.opacity) * 0.97f + 0.03f;
		}
		private bool skyActive;
		private float opacity;
	}
}
