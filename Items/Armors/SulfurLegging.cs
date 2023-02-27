using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Armors
{
	[AutoloadEquip(new EquipType[]
	{
        (Terraria.ModLoader.EquipType)2
	})]
	public class SulfurLegging : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺护胫");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "增加30%移速,增加10%闪避");
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 50);
            modRecipe.AddIngredient(null, "Sulfur", 128);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 36, 0, 0);
			base.item.rare = 11;
			base.item.defense = 25;
		}
        public override void UpdateEquip(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Misspossibility += 10;
            player.moveSpeed += 0.3f;
        }
    }
}
