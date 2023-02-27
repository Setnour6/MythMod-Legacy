using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class SightEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("窥视之眼");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "窥视之眼");
            Tooltip.SetDefault("暴击增加5%,并提升夜视能力");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "暴击增加5%,并提升夜视能力");
		}
		public override void SetDefaults()
		{
			base.item.width = 34;
			base.item.height = 36;
			base.item.value = 3000;
			base.item.accessory = true;
            item.rare = 3;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.rangedCrit += 5;
            player.meleeCrit += 5;
            player.magicCrit += 5;
            player.nightVision = true;
        }
	}
}
