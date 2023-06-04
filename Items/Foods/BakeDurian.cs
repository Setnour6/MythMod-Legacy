using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakeDurian : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("烤榴莲");
            // base.Tooltip.SetDefault("看样子很好吃,至于闻起来……");
		}
		public override void SetDefaults()
		{
			base.Item.width = 46;
            base.Item.height = 38;
            base.Item.rare = 5;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 1;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("烤榴莲").Type;
        }
        public override void AddRecipes()
        {
        }
	}
}
