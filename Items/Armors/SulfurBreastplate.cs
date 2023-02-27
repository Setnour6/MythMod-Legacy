using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Armors
{
	[AutoloadEquip(new EquipType[]
	{
        (Terraria.ModLoader.EquipType)1
    })]
	public class SulfurBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺板甲");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "伤害和暴击各增加17%,增加8%闪避");
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 80);
            modRecipe.AddIngredient(null, "Sulfur", 152);
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
			base.item.defense = 30;
		}
        public override void UpdateEquip(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Misspossibility += 8;
            player.meleeCrit += 17;
            player.rangedCrit += 17;
            player.magicCrit += 17;
            player.minionDamage *= 1.17f;
            player.meleeDamage *= 1.17f;
            player.thrownDamage *= 1.17f;
            player.magicDamage *= 1.17f;
            player.rangedDamage *= 1.17f;
        }
        public override void UpdateArmorSet(Player player)
        {
        }
    }
}
