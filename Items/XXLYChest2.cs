using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;


namespace MythMod.Items
{
	// Token: 0x0200067A RID: 1658
    public class XXLYChest2 : ModItem
	{
		// Token: 0x06001CC8 RID: 7368 RVA: 0x00009CA8 File Offset: 0x00007EA8
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("XXLY宝藏箱2");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x000B6510 File Offset: 0x000B4710
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 22;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 500;
            base.item.createTile = base.mod.TileType("XXLYChest2");
		}
        // Token: 0x06001CCA RID: 7370 RVA: 0x000B65BC File Offset: 0x000B47BC
    }
}
