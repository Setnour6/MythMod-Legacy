﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.砖块
{
    public class 绿松石晶莹宝石块 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
			this.dustType = 89;
            this.drop = base.mod.ItemType("TurquoiseBrick");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("绿松石晶莹宝石块");
			base.AddMapEntry(new Color(22, 204, 179), modTranslation);
			this.mineResist = 5f;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "绿松石晶莹宝石块");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0;
            g = 0.72f;
            b = 0.76f;
            return;
        }
    }
}
