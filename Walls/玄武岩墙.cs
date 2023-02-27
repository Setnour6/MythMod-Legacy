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
    public class 玄武岩墙 : ModWall
	{
		// Token: 0x060046D6 RID: 18134 RVA: 0x0027F638 File Offset: 0x0027D838
		public override void SetDefaults()
		{
			Main.wallHouse[(int)base.Type] = true;
			this.dustType = 240;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(0, 0, 0), modTranslation);
		}
	}
}
