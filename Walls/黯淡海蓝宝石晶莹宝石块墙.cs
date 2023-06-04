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
    public class 黯淡海蓝宝石晶莹宝石块墙 : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.DustType = 156;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("黯淡海蓝宝石晶莹宝石块墙").Type;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("黯淡海蓝宝石晶莹宝石块墙");
			base.AddMapEntry(new Color(0, 115, 118), modTranslation);
		}
    }
}
