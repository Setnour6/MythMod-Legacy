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
    public class RedTreeWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.DustType = 163;
            /*this.drop = base.mod.ItemType("RedTreeLeavesWall");*/
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("");
			base.AddMapEntry(new Color(27, 30, 9), modTranslation);
		}
    }
}
