using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	public class 月饼 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile((int)base.Type);
            this.drop = base.mod.ItemType("Mooncake");
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("月饼");
            base.AddMapEntry(new Color(200, 76, 25), modTranslation);
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			return true;
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.AddBuff(mod.BuffType("甜蜜I"), 20);
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			WorldGen.Check1x1(i, j, (int)base.Type);
			return true;
		}
        public override void PlaceInWorld(int i, int j, Item item)
		{
			Main.tile[i, j].frameX = 0;
			Main.tile[i, j].frameY = 0;
		}
	}
}
