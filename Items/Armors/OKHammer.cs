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
			base.Item.width = 18;
			base.Item.height = 18;
			base.Item.value = Item.buyPrice(0, 0, 0, 0);
			base.Item.rare = 7;
			base.Item.defense = 23;
		}
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == base.Mod.Find<ModItem>("OK的胸甲").Type && legs.type == base.Mod.Find<ModItem>("OK的腿甲").Type;
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
