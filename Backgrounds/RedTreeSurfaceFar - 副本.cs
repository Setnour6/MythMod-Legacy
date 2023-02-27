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
	public class RedTreeSurfaceBgStyle : ModSurfaceBackgroundStyle
	{
		public override bool ChooseBgStyle()/* tModPorter Note: Removed. Create a ModBiome (or ModSceneEffect) class and override SurfaceBackgroundStyle property to return this object through Mod/ModContent.Find, then move this code into IsBiomeActive (or IsSceneEffectActive) */
		{
			return !Main.gameMenu && ((MythPlayer)Main.player[Main.myPlayer].GetModPlayer(Mod, "MythPlayer")).ZoneRedTree;
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
            if (player.wet)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceFar");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceFar");
            }
        }

		static int SurfaceFrameCounter = 0;
		static int SurfaceFrame = 0;
		public override int ChooseMiddleTexture()
		{
            Player player = Main.player[Main.myPlayer];
            if (player.wet)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceMiddle");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceMiddle");
            }
        }

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
		{
            Player player = Main.player[Main.myPlayer];
            b = 600f;
            if (player.wet)
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceClose");
            }
            else
            {
                return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/RedTreeSurfaceClose");
            }
        }
	}
}