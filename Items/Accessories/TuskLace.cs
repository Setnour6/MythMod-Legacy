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
			// DisplayName.SetDefault("獠牙吊坠");
			// Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Chinese, "獠牙吊坠");
            // Tooltip.SetDefault("伤害增加5%");
            Tooltip.AddTranslation(GameCulture.Chinese, "伤害增加5%");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 46;
			Item.value = 1000;
			Item.accessory = true;
            Item.rare = 3;

        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.arrowDamage *= 1.05f;
            player.GetDamage(DamageClass.Melee) *= 1.05f;
            player.bulletDamage *= 1.05f;
            player.GetDamage(DamageClass.Magic) *= 1.05f;
            player.GetDamage(DamageClass.Summon) *= 1.05f;
        }
	}
}
