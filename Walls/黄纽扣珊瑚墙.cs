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
    public class 黄纽扣珊瑚墙 : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.dustType = 59;
            this.drop = base.mod.ItemType("黄纽扣珊瑚墙");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("黄纽扣珊瑚墙");
			base.AddMapEntry(new Color(150, 55, 0), modTranslation);
		}
	}
}
