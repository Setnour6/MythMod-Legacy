using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Armors
{
	[AutoloadEquip(new EquipType[]
	{
        0
	})]
	public class OKHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "OK的头盔");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "开发人员装备");
		}
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = Item.buyPrice(0, 0, 0, 0);
			base.item.rare = 7;
			base.item.defense = 23;
		}
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == base.mod.ItemType("OK的胸甲") && legs.type == base.mod.ItemType("OK的腿甲");
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void UpdateArmorSet(Player player)
        {
        }
    }
}
