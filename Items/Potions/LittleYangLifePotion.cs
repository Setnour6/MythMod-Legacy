using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Potions
{
    public class LittleYangLifePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("小阳血药剂");
            // base.Tooltip.SetDefault("可以在白天回复阳寿命");
		}
		public override void SetDefaults()
		{
			base.Item.width = 16;
			base.Item.height = 24;
            base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 2000;
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = base.Item.useTime;
                if(Main.dayTime)
                {
                    base.Item.consumable = true;
                    modPlayer.YangLife += 2;
                }
                else
                {
                    base.Item.consumable = false;
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("LittleYangLifePotion").Type, 1);
            recipe.AddIngredient(5, 5);
            recipe.AddIngredient(27, 5);
            recipe.AddIngredient(38, 2);
            recipe.AddIngredient(209, 2);
            recipe.AddIngredient(210, 2);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
            Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("LittleYangLifePotion").Type, 1);
            recipe2.AddIngredient(63, 1);
            recipe2.AddIngredient(28, 1);
            recipe2.requiredTile[0] = 13;
            recipe2.Register();
        }
	}
}
