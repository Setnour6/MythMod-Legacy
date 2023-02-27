using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class PlayerP : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "测试员护符");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "用来打终天灭世眼的");
		}
		public override void SetDefaults()
		{
			base.item.width = 46;
			base.item.height = 28;
			base.item.value = 0;
			base.item.accessory = true;
			
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
			player.lifeRegen += 4000000;
			player.meleeDamage += 0.4f;
			player.rangedDamage += 0.4f;
			player.magicDamage += 0.4f;
			player.meleeSpeed += 0.4f;
			player.endurance += 0.4f;
			player.accRunSpeed = 14f;
			player.rocketBoots = 17;
			player.moveSpeed += 0.47f;
			player.iceSkate = true;
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 99999;
			player.meleeCrit += 25;
			player.rangedCrit += 25;
			player.magicCrit += 25;
			player.minionDamage += 0.4f;
			player.minionKB += 10f;
			player.thrownDamage += 0.4f;
			player.thrownCrit += 25;
			player.statDefense += 500;
			player.statLifeMax2 += 10000000;
			player.statManaMax2 += 1000;
		}
	}
}
