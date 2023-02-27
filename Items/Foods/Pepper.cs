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
			base.item.width = 20;
            base.item.height = 34;
            base.item.rare = 5;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            item.value = 10;
        }
        public override void AddRecipes()
        {
        }
	}
}
