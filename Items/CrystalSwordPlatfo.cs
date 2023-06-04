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
namespace MythMod.Items
{
    public class CrystalSwordPlatfo : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("CrystalSword Trophy");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰洲石剑纪念章");
		}
		public override void SetDefaults()
		{
			base.Item.width = 30;
			base.Item.height = 30;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 50000;
			base.Item.rare = 1;
			base.Item.createTile = base.Mod.Find<ModTile>("BossTrophy").Type;
			base.Item.placeStyle = 6;
		}
	}
}
