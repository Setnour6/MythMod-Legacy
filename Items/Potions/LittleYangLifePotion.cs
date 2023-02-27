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
            base.DisplayName.SetDefault("小阳血药剂");
            base.Tooltip.SetDefault("可以在白天回复阳寿命");
		}
		public override void SetDefaults()
		{
			base.item.width = 16;
			base.item.height = 24;
            base.item.rare = 2;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            item.value = 2000;
        }
        public override bool UseItem(Player player)
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = base.item.useTime;
                if(Main.dayTime)
                {
                    base.item.consumable = true;
                    modPlayer.YangLife += 2;
                }
                else
                {
                    base.item.consumable = false;
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(5, 5);
            recipe.AddIngredient(27, 5);
            recipe.AddIngredient(38, 2);
            recipe.AddIngredient(209, 2);
            recipe.AddIngredient(210, 2);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(mod.ItemType("LittleYangLifePotion"), 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(63, 1);
            recipe2.AddIngredient(28, 1);
            recipe2.requiredTile[0] = 13;
            recipe2.SetResult(mod.ItemType("LittleYangLifePotion"), 1);
            recipe2.AddRecipe();
        }
	}
}
