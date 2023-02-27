using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	// Token: 0x02000CAF RID: 3247
	public class 玄武岩浴缸 : ModTile
	{
		// Token: 0x0600413F RID: 16703 RVA: 0x0032ACC8 File Offset: 0x00328EC8
		public override void SetStaticDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩浴缸");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.AnimationFrameHeight = 54;
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩浴缸");
		}

		// Token: 0x06004140 RID: 16704 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}

		// Token: 0x06004141 RID: 16705 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}

		// Token: 0x06004142 RID: 16706 RVA: 0x0032ADB8 File Offset: 0x00328FB8
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("BasaltBathtub").Type, 1, false, 0, false, false);
		}
	}
}
