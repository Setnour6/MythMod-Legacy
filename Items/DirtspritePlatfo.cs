using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;

namespace MythMod.Items
{
    public class DirtspritePlatfo : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dirtsprite Trophy");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "潜地恶鬼纪念章");
		}
		public override void SetDefaults()
		{
			base.item.width = 30;
			base.item.height = 30;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 50000;
			base.item.rare = 1;
			base.item.createTile = base.mod.TileType("BossTrophy");
			base.item.placeStyle = 7;
		}
	}
}
