using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class GeoduckSashimi : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("北极贝刺身");
            // base.Tooltip.SetDefault("放在身边获得增益,美味等级I");
		}
		public override void SetDefaults()
		{
			base.Item.width = 72;
            base.Item.height = 40;
            base.Item.rare = 1;
            base.Item.value = Item.sellPrice(0, 0, 5, 0);
            base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("北极贝刺身").Type;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("GeoduckSashimi").Type, 1);
            recipe.AddIngredient(null, "Geoduck", 3);
            recipe.requiredTile[0] = 220;
            recipe.Register();
        }
	}
}
