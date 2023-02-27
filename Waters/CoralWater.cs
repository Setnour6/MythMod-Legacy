using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Waters
{
	public class CoralWater : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
			return Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneDeepocean;
		}
		public override int ChooseWaterfallStyle()
		{
			return base.Mod.GetWaterfallStyleSlot("CoralWaterflow");
		}
		public override int GetSplashDust()
		{
			return Mod.Find<ModDust>("Wave").Type;
		}
		public override int GetDropletGore()
		{
			return 713;
		}

		public override Color BiomeHairColor()
		{
			return Color.Blue;
		}
    }
}
