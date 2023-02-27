using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	// Token: 0x02000CB4 RID: 3252
	public class 玄武岩椅子 : ModTile
	{
		// Token: 0x0600415E RID: 16734 RVA: 0x0032B55C File Offset: 0x0032975C
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.Direction = (Terraria.Enums.TileObjectDirection)1;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = (Terraria.Enums.TileObjectDirection)2;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩椅子");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				15
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩椅子");
		}

		// Token: 0x0600415F RID: 16735 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}

		// Token: 0x06004160 RID: 16736 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}

		// Token: 0x06004161 RID: 16737 RVA: 0x0032B680 File Offset: 0x00329880
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("BasaltChair"), 1, false, 0, false, false);
		}
	}
}
