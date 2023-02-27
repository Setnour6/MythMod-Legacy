using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	// Token: 0x02000CC4 RID: 3268
	public class 玄武岩平台 : ModTile
	{
		// Token: 0x060041C4 RID: 16836 RVA: 0x0032D928 File Offset: 0x0032BB28
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileSolidTop[(int)base.Type] = true;
			Main.tileSolid[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileTable[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			this.soundType = 21;
			TileID.Sets.Platforms[(int)base.Type] = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 27;
			TileObjectData.newTile.StyleWrapLimit = 27;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			this.drop = base.mod.ItemType("BasaltPlatform");
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				19
			};
		}

		// Token: 0x060041C5 RID: 16837 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 6, 0f, 0f, 1, Color.White, 1f);
			return false;
		}

		// Token: 0x060041C6 RID: 16838 RVA: 0x00013D86 File Offset: 0x00011F86
		public override void PostSetDefaults()
		{
			Main.tileNoSunLight[(int)base.Type] = false;
		}

		// Token: 0x060041C7 RID: 16839 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
