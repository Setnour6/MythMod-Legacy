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
    public class CrystalWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.dustType = 163;
            this.drop = base.mod.ItemType("CrystalWall");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("CrystalWall");
			base.AddMapEntry(new Color(88, 88, 88), modTranslation);
		}
    }
}
