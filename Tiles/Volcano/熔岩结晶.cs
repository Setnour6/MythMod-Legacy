using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000DCE RID: 3534
	public class 熔岩结晶 : ModTile
	{
		// Token: 0x06004868 RID: 18536 RVA: 0x0034883C File Offset: 0x00346A3C
		public override void SetDefaults()
		{
            Main.tileLighted[(int)base.Type] = true;
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            Main.tileLavaDeath[(int)base.Type] = true;
            Main.tileWaterDeath[(int)base.Type] = false;
            this.minPick = 300;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                20,
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 72;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Origin = new Point16(1, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
            TileObjectData.addTile((int)base.Type);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("熔岩结晶");
            base.AddMapEntry(new Color(191, 142, 111), modTranslation);
            this.adjTiles = new int[]
            {
                4
            };
            modTranslation.AddTranslation(GameCulture.Chinese, "熔岩结晶");
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        // Token: 0x0600486A RID: 18538 RVA: 0x003488D0 File Offset: 0x00346AD0
        public override void NearbyEffects(int i, int j, bool closer)
		{
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            for(int z = Main.rand.Next(46, 48);z < 50;z++)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("LavaCrystal"));
            }
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 6));
            Main.tile[i, j].frameX = (short)(num * 72);
            Main.tile[i, j + 1].frameX = (short)(num * 72);
            Main.tile[i, j + 2].frameX = (short)(num * 72);
            Main.tile[i, j + 3].frameX = (short)(num * 72);
            Main.tile[i, j + 4].frameX = (short)(num * 72);
        }
    }
}
