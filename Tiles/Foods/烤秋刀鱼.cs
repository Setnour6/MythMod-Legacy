using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Foods
{
	public class 烤秋刀鱼 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
                16,
                16,
                16
			};
            TileObjectData.newTile.CoordinateWidth = 48;
            TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("烤秋刀鱼");
            base.AddMapEntry(new Color(242, 141, 0), modTranslation);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			modTranslation.AddTranslation(GameCulture.Chinese, "烤秋刀鱼");
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.AddBuff(mod.BuffType("海的味道I"), 20);
            player.AddBuff(mod.BuffType("热乎乎的美味I"), 20);
        }
        public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 137, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("烤秋刀鱼"));
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 3));
            Main.tile[i, j].frameX = (short)(num * 48);
            Main.tile[i, j + 1].frameX = (short)(num * 48);
            Main.tile[i, j + 2].frameX = (short)(num * 48);
            Main.tile[i, j + 3].frameX = (short)(num * 48);
        }
    }
}
