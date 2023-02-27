using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Festivals
{
	public class LargeLantern3 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileSolidTop[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.AnchorBottom = new AnchorData(0, 0, 0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData((Terraria.Enums.AnchorType)1, (int)2, (int)0);
			TileObjectData.addAlternate(1);
			TileObjectData.newTile.AnchorRight = new AnchorData((Terraria.Enums.AnchorType)1, 2, 0);
			TileObjectData.addTile((int)base.Type);
			this.dustType = 115;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            modTranslation.AddTranslation(GameCulture.Chinese, "");
            base.AddMapEntry(new Color(255, 0, 0), modTranslation);
			this.mineResist = 3f;
			base.SetDefaults();
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.tile[i, j].frameY > 40)
            {
                Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(0.8f, 0.2f, 0f));
            }
        }
        public override void HitWire(int i, int j)
        {
            int num = i;
            int num2 = j;
            for (int k = num; k < num + 3; k++)
            {
                for (int l = num2 - 1; l < num2 + 3; l++)
                {
                    if (Main.tile[k, l] == null)
                    {
                        Main.tile[k, l] = new Tile();
                    }
                    if (Main.tile[k, l].active() && Main.tile[k, l].type == base.Type)
                    {
                        if (Main.tile[k, l].frameY < 54)
                        {
                            Tile tile = Main.tile[k, l];
                            tile.frameY += 54;
                        }
                        else
                        {
                            Tile tile2 = Main.tile[k, l];
                            tile2.frameY -= 54;
                        }
                    }
                }
            }
            if (Wiring.running)
            {
                Wiring.SkipWire(num, num2);
                Wiring.SkipWire(num, num2 + 1);
                Wiring.SkipWire(num, num2 + 2);
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("LargeLantern3"));
        }
    }
}
