using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class ShinyPearl : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "闪烁珍珠");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "点亮深海\n未完成");
		}
		public override void SetDefaults()
		{
			base.item.width = 46;
			base.item.height = 28;
			base.item.value = 0;
			base.item.accessory = true;
            base.item.rare = 9;

        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
        }
	}
}
