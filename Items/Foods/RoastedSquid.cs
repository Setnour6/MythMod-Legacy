using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class RoastedSquid : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("烤鲜鱿");
            // base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
			base.Item.width = 50;
            base.Item.height = 52;
            base.Item.rare = 5;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}
        public override void AddRecipes()
        {

        }
    }
}
