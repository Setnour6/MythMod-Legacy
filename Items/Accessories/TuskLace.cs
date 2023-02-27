using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class TuskLace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("獠牙吊坠");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Chinese, "獠牙吊坠");
            Tooltip.SetDefault("伤害增加5%");
            Tooltip.AddTranslation(GameCulture.Chinese, "伤害增加5%");
		}

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 46;
			item.value = 1000;
			item.accessory = true;
            item.rare = 3;

        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.arrowDamage *= 1.05f;
            player.meleeDamage *= 1.05f;
            player.bulletDamage *= 1.05f;
            player.magicDamage *= 1.05f;
            player.minionDamage *= 1.05f;
        }
	}
}
