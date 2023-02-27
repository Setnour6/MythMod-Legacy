using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	// Token: 0x02000C71 RID: 3185
	public class 五仁月饼 : ModTile
	{
		// Token: 0x0600400B RID: 16395 RVA: 0x0032258C File Offset: 0x0032078C
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile((int)base.Type);
            this.ItemDrop = base.Mod.Find<ModItem>("NutMooncake").Type;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("月饼");
            base.AddMapEntry(new Color(200, 76, 25), modTranslation);
		}

		// Token: 0x0600400C RID: 16396 RVA: 0x00013910 File Offset: 0x00011B10
		public override bool CreateDust(int i, int j, ref int type)
		{
			return true;
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.AddBuff(Mod.Find<ModBuff>("甜蜜I").Type, 20);
        }
        // Token: 0x0600400D RID: 16397 RVA: 0x00013946 File Offset: 0x00011B46
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
		{
			WorldGen.Check1x1(i, j, (int)base.Type);
			return true;
		}
        // Token: 0x0600400E RID: 16398 RVA: 0x00013956 File Offset: 0x00011B56
        public override void PlaceInWorld(int i, int j, Item item)
		{
			Main.tile[i, j].TileFrameX = 0;
			Main.tile[i, j].TileFrameY = 0;
		}
	}
}
