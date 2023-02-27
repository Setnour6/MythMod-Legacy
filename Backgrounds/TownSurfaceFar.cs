using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.Backgrounds
{
	public class TownSurfaceFar : ModSurfaceBgStyle
	{
		public override bool ChooseBgStyle()
		{
            return !Main.gameMenu && ((MythPlayer)Main.player[Main.myPlayer].GetModPlayer(mod, "MythPlayer")).ZoneTown;
        }

		// Use this to keep far Backgrounds like the mountains.
		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseFarTexture()
		{
            Player player = Main.player[Main.myPlayer];
            return mod.GetBackgroundSlot("Backgrounds/TownFar");
        }

		static int SurfaceFrameCounter = 0;
		static int SurfaceFrame = 0;
		public override int ChooseMiddleTexture()
		{
            Player player = Main.player[Main.myPlayer];
            return mod.GetBackgroundSlot("Backgrounds/TownMiddle");
        }
        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mod.GetTexture("Backgrounds/TownClose"), new Vector2(0, 0), null, Color.White, 0, new Vector2(512, 600), 1f, SpriteEffects.None, 0);
            return true;
        }
        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
            Player player = Main.player[Main.myPlayer];
            b = 900;
            return mod.GetBackgroundSlot("Backgrounds/TownClose");
        }
	}
}