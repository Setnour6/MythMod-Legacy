﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class PlayerP : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("XXX");
			// base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "测试员护符");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "用来打终天灭世眼的");
		}
		public override void SetDefaults()
		{
			base.Item.width = 46;
			base.Item.height = 28;
			base.Item.value = 0;
			base.Item.accessory = true;
			
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
			player.lifeRegen += 4000000;
			player.GetDamage(DamageClass.Melee) += 0.4f;
			player.GetDamage(DamageClass.Ranged) += 0.4f;
			player.GetDamage(DamageClass.Magic) += 0.4f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.4f;
			player.endurance += 0.4f;
			player.accRunSpeed = 14f;
			player.rocketBoots = 17;
			player.moveSpeed += 0.47f;
			player.iceSkate = true;
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += 99999;
			player.GetCritChance(DamageClass.Generic) += 25;
			player.GetCritChance(DamageClass.Ranged) += 25;
			player.GetCritChance(DamageClass.Magic) += 25;
			player.GetDamage(DamageClass.Summon) += 0.4f;
			player.GetKnockback(DamageClass.Summon).Base += 10f;
			player.GetDamage(DamageClass.Throwing) += 0.4f;
			player.GetCritChance(DamageClass.Throwing) += 25;
			player.statDefense += 500;
			player.statLifeMax2 += 10000000;
			player.statManaMax2 += 1000;
		}
	}
}
