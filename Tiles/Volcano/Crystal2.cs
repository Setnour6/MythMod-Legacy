using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
    public class Crystal2 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = false;
			Main.tileShine2[(int)base.Type] = false;
			Main.tileValue[(int)base.Type] = 0;
			this.dustType = 198;
			this.minPick = 340;
			this.soundType = 27;
			this.soundStyle = 2;
            this.drop = base.mod.ItemType("Crystal");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(0, 0, 0, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
