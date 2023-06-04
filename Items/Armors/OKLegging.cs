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
	public class OKLegging : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("");
            // base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "OK的腿甲");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "开发人员装备");
        }
		public override void SetDefaults()
		{
			base.Item.width = 18;
			base.Item.height = 18;
			base.Item.value = Item.buyPrice(0, 18, 0, 0);
			base.Item.rare = 7;
			base.Item.defense = 17;
		}
		public override void UpdateEquip(Player player)
		{
		}
	}
}
