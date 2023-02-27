using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.Walls
{
    public class 朽木墙 : ModWall
    {
		public override void SetDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.dustType = 240;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(37, 25, 16), modTranslation);
		}
	}
}
