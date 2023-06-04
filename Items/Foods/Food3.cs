using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Food3 : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("三阶美食手册");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.width = 28;
            base.Item.height = 30;
            base.Item.rare = 2;
            base.Item.value = Item.sellPrice(0, 0, 5, 0);
            base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
        }
        public override void AddRecipes()
        {
        }
	}
}
