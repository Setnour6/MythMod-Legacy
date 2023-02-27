using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Fishes
{
    public class Saury : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "秋刀鱼");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "秋刀鱼");
		}
		public override void SetDefaults()
		{
			base.Item.width = 26;
			base.Item.height = 26;
			base.Item.maxStack = 999;
			base.Item.value = Item.sellPrice(0, 0, 5, 0);
			base.Item.rare = 6;
		}
        public override void AddRecipes()
        {
        }
    }
}


