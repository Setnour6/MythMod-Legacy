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
	public class MythSurfaceBgStyle : ModSurfaceBgStyle
	{
		public override bool ChooseBgStyle()
		{
			return !Main.gameMenu && ((MythPlayer)Main.player[Main.myPlayer].GetModPlayer(mod, "MythPlayer")).ZoneVolcano;
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
			return mod.GetBackgroundSlot("Backgrounds/VolcanoSurfaceFar");
		}

		static int SurfaceFrameCounter = 0;
		static int SurfaceFrame = 0;
		public override int ChooseMiddleTexture()
		{
			return mod.GetBackgroundSlot("Backgrounds/VolcanoSurfaceMiddle");
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
            b = 900f;
			return mod.GetBackgroundSlot("Backgrounds/VolcanoSurfaceClose");
		}
        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
        {
            Main.spriteBatch.Draw(mod.GetTexture("Backgrounds/VolcanoSurfaceCloseLava"), Main.screenPosition, null, new Color(255,255,255,0), 0, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            return base.PreDrawCloseBackground(spriteBatch);
        }
    }
}