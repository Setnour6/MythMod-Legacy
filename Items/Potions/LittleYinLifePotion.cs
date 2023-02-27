using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Potions
{
    public class LittleYinLifePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("小阴魂药剂");
            base.Tooltip.SetDefault("可以在夜间回复阴寿命");
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
                    base.Item.consumable = false;
                    return false;
                }
                else
                {
                    base.Item.consumable = true;
                    modPlayer.YinLife += 2;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(75, 2);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
	}
}
