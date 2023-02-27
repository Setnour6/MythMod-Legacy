using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Foods
{
	public class 北极贝刺身 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16
            };
            TileObjectData.newTile.CoordinateWidth = 54;
            TileObjectData.addTile((int)base.Type);
			this.dustType = 31;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(242, 141, 0), modTranslation);
            this.mineResist = 3f;
            this.drop = mod.ItemType("北极贝刺身");
            base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            //player.AddBuff(mod.BuffType("冰爽II"), 2);
            player.AddBuff(mod.BuffType("海的味道II"), 20);
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
    }
}
