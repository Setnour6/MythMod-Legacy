using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000DCE RID: 3534
	public class 橄榄石晶体 : ModTile
	{
		// Token: 0x06004868 RID: 18536 RVA: 0x0034883C File Offset: 0x00346A3C
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            Main.tileLavaDeath[(int)base.Type] = false;
            this.minPick = 264;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                18
            };
            TileObjectData.newTile.CoordinateWidth = 80;
            TileObjectData.addTile((int)base.Type);
			this.dustType = mod.DustType("橄榄石");
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(74, 123, 0), modTranslation);
			this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
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
            for (int z = Main.rand.Next(15); z < 50; z++)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("Olivine"));
            }
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 6));
            Main.tile[i, j].frameX = (short)(num * 80);
            Main.tile[i, j + 2].frameX = (short)(num * 80);
            Main.tile[i, j + 3].frameX = (short)(num * 80);
            Main.tile[i, j + 1].frameX = (short)(num * 80);
        }
    }
}
