using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
    public class BossTrophy : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileLavaDeath[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile((int)base.Type);
            this.dustType = 7;
            this.disableSmartCursor = true;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("Trophy");
            base.AddMapEntry(new Color(120, 85, 60), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "纪念章");
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
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/BossTrophyGlow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), new Color(255, 255, 255, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int num = 0;
            switch (frameX / 54)
            {
                case 0:
                    num = base.mod.ItemType("StarJellyFishPlatf");
                    break;
                case 1:
                    num = base.mod.ItemType("CorruptMothPlatform");
                    break;
                case 2:
                    num = base.mod.ItemType("BloodyTuskPlatfo");
                    break;
                case 3:
                    num = base.mod.ItemType("SmallOrangeMonstorPlatform");
                    break;
                case 4:
                    num = base.mod.ItemType("LanternKingPlatform");
                    break;
                case 5:
                    num = base.mod.ItemType("OrangeMonstorPlatform");
                    break;
                case 6:
                    num = base.mod.ItemType("CrystalSwordPlatfo");
                    break;
                case 7:
                    num = base.mod.ItemType("DirtSpritePlatfo");
                    break;
            }
            if (num > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, num, 1, false, 0, false, false);
            }
        }
    }
}
