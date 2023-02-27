using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MythMod.UI.Stones;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MythMod.Tiles.Ocean
{
    // Token: 0x02000DCE RID: 3534
    public class 海洋封印台 : ModTile
    {
        // Token: 0x06004868 RID: 18536 RVA: 0x0034883C File Offset: 0x00346A3C
        public override void SetDefaults()
        {
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            this.minPick = 260;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                18
            };
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorTop = default(AnchorData);
            TileObjectData.addTile((int)base.Type);
            this.dustType = 224;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(7, 76, 67), modTranslation);
            this.mineResist = 3f;
            base.SetDefaults();
            modTranslation.AddTranslation(GameCulture.Chinese, "");
        }

        // Token: 0x06004869 RID: 18537 RVA: 0x000138D5 File Offset: 0x00011AD5
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        // Token: 0x0600486A RID: 18538 RVA: 0x003488D0 File Offset: 0x00346AD0
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.LocalPlayer;
            Vector2 v = player.Center - new Vector2(i * 16, j * 16);
            if (v.Length() >= 300 && Stones.Open)
            {
                Stones.Open = false;
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("SealTableOfOcean"));
        }
        public override void RightClick(int i, int j)//右击
        {
            if(Stones.Open != true)
            {
                Stones.Open = true;
            }
            else
            {
                Stones.Open = false;
            }
            Tile tile2 = Main.tile[i, j + 1];
            if ((!tile2.nactive() || !Main.tileSolid[(int)tile2.type] || Main.tileSolidTop[(int)tile2.type]) && tile2.liquid < 255)
            {
                if (tile2.liquid > 250)
                {
                    tile2.liquid = byte.MaxValue;
                }
                else
                {
                    Liquid.AddWater(i, j);
                }
            }
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = 16;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.movieTime > 0)
            {
                Main.spriteBatch.Draw(mod.GetTexture("Tiles/Ocean/海洋封印台Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), new Color(mplayer.movieTime / 120f, mplayer.movieTime / 120f, mplayer.movieTime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (NPC.CountNPCS(mod.NPCType("OceanCrystal")) > 0)
            {
                Main.spriteBatch.Draw(mod.GetTexture("Tiles/Ocean/海洋封印台Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), new Color(255, 255, 255, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
