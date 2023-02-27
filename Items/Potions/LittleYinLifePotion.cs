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
                    base.item.consumable = false;
                    return false;
                }
                else
                {
                    base.item.consumable = true;
                    modPlayer.YinLife += 2;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(75, 2);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
