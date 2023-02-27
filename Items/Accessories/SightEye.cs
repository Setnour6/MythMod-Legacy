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
			base.Item.width = 34;
			base.Item.height = 36;
			base.Item.value = 3000;
			base.Item.accessory = true;
            Item.rare = 3;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.nightVision = true;
        }
	}
}
