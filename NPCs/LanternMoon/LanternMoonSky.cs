using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;


namespace MythMod.NPCs.LanternMoon
{
	public class LanternMoonSky : CustomSky
	{
		public override void Update(GameTime gameTime)
		{
			if (this.isActive && this.intensity < 1f)
			{
				this.intensity += 0.01f;
				return;
			}
			if (!this.isActive && this.intensity > 0f)
			{
				this.intensity -= 0.01f;
			}
		}
		private float GetIntensity()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.LanternMoon)
			{
				float num = 0f;
				return (1f - Utils.SmoothStep(3000f, 6000f, num)) * 0.5f;
			}
			return 0.5f;
		}
		public override Color OnTileColor(Color inColor)
		{
			float num = this.GetIntensity();
			return new Color(Vector4.Lerp(new Vector4(0.5f, 0.8f, 1f, 1f), inColor.ToVector4(), 1f - num));
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Mod mod = ModLoader.GetMod("MythMod");
            if (mplayer.LanternMoon)
			{
				float num = this.GetIntensity();
				spriteBatch.Draw(mod.GetTexture("UIImages/PIXELEFFECT"), new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), null, new Color(252,120,120,0));
			}
		}
		public override float GetCloudAlpha()
		{
			return 0f;
		}
		public override void Activate(Vector2 position, params object[] args)
		{
			this.isActive = true;
		}
		public override void Deactivate(params object[] args)
		{
			this.isActive = false;
		}
		public override void Reset()
		{
			this.isActive = false;
		}
		public override bool IsActive()
		{
			return this.isActive || this.intensity > 0f;
		}
		private bool isActive;
		private float intensity;
		private int DoGIndex = -1;
	}
}
