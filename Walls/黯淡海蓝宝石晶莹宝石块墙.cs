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
		public override void SetDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.dustType = 156;
            this.drop = base.mod.ItemType("黯淡海蓝宝石晶莹宝石块墙");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("黯淡海蓝宝石晶莹宝石块墙");
			base.AddMapEntry(new Color(0, 115, 118), modTranslation);
		}
    }
}
