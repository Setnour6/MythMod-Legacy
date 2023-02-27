using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class HoneyHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "甜蜜之心");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "弄湿之后提升回血速度\n神话");
		}
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = 0;
			base.item.accessory = true;
            base.item.rare = 7;
        }
        private int WetIndex = 0;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            if(player.wet)
            {
                WetIndex = 300;
            }
            else
            {
                if(WetIndex > 0)
                {
                    WetIndex -= 1;
                }
                else
                {
                    WetIndex = 0;
                }
            }
            if(WetIndex > 0)
            {
                player.lifeRegen += WetIndex / 30;
            }
		}
	}
}
