using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using MythMod.Dusts;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
    public class MarbleFragment : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[(int)base.Type] = true;
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileLavaDeath[(int)base.Type] = true;
            Main.tileWaterDeath[(int)base.Type] = false;
            this.MinPick = 190;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 192;
            TileObjectData.addTile((int)base.Type);
            LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("碎片堆");
            base.AddMapEntry(new Color(146, 151, 176), modTranslation);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
            this.AdjTiles = new int[]
            {
                4
            };
            modTranslation.AddTranslation(GameCulture.Chinese, "碎片堆");
        }
        public override bool CreateDust(int i, int j, ref int type)
        {
            Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 51, 0f, 0f, 1, default(Color), 1f);
            return false;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 2));
            Main.tile[i, j].TileFrameX = (short)(num * 64);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, Mod.Find<ModItem>("MarbleFragment").Type);
        }
        public override void RightClick(int i, int j)//右击
        {
            Player player = Main.LocalPlayer;
            bool flag = true;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == Mod.Find<ModItem>("EvilFragment").Type && player.inventory[num66].stack > 0)
                {
                    player.inventory[num66].stack--;
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("EvilBotle").Type) == 0)
                    {
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, Mod.Find<ModNPC>("EvilBotle").Type, 0, 0, 0, 0, 255);
                    }
                }
            }
        }
        public override void MouseOver(int i, int j)
        {
            CrystalEffectMain.Fragment = 2;
        }
    }
}
