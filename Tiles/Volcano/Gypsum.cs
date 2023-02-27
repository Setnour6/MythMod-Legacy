using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
    public class Gypsum : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = false;
            Main.tileValue[(int)base.Type] = 0;
            this.dustType = 6;
			this.minPick = 0;
			this.soundType = 21;
            this.soundStyle = 2;
            this.drop = base.mod.ItemType("Gypsum");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(242, 216, 138), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "石膏");
            SetModTree(new RedTree());
        }
    }
}
