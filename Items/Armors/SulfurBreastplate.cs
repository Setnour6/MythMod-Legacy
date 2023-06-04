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
            // base.DisplayName.SetDefault("");
            // base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺板甲");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "伤害和暴击各增加17%,增加8%闪避");
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Basalt", 80);
            modRecipe.AddIngredient(null, "Sulfur", 152);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
        public override void SetDefaults()
		{
			base.Item.width = 18;
			base.Item.height = 18;
			base.Item.value = Item.buyPrice(0, 36, 0, 0);
			base.Item.rare = 11;
			base.Item.defense = 30;
		}
        public override void UpdateEquip(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Misspossibility += 8;
            player.GetCritChance(DamageClass.Generic) += 17;
            player.GetCritChance(DamageClass.Ranged) += 17;
            player.GetCritChance(DamageClass.Magic) += 17;
            player.GetDamage(DamageClass.Summon) *= 1.17f;
            player.GetDamage(DamageClass.Melee) *= 1.17f;
            player.GetDamage(DamageClass.Throwing) *= 1.17f;
            player.GetDamage(DamageClass.Magic) *= 1.17f;
            player.GetDamage(DamageClass.Ranged) *= 1.17f;
        }
        public override void UpdateArmorSet(Player player)
        {
        }
    }
}
