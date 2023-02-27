using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class VineSlingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("藤蔓弹弓");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.crit = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 42;
			Item.height = 30;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2f;
			Item.autoReuse = false;
			Item.value = Item.sellPrice(0, 0, 0, 50);
			Item.rare = 2;
			Item.UseSound = SoundID.Item5;
            Item.shoot = 51;
			Item.shootSpeed = 12f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
	}
}
