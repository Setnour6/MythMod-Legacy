using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.Walls
{
	// Token: 0x02000EC7 RID: 3783
    public class 海蓝砖墙 : ModWall
	{
		// Token: 0x060046D6 RID: 18134 RVA: 0x0027F638 File Offset: 0x0027D838
		public override void SetStaticDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.DustType = 59;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("海蓝砖墙").Type;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("海蓝砖墙");
			base.AddMapEntry(new Color(0, 0, 100), modTranslation);
		}
	}
}
