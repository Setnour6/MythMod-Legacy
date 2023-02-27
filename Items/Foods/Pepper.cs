using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Pepper : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("辣椒");
            base.Tooltip.SetDefault("调味料");
		}
		public override void SetDefaults()
		{
			base.Item.width = 20;
            base.Item.height = 34;
            base.Item.rare = 5;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 10;
        }
        public override void AddRecipes()
        {
        }
	}
}
