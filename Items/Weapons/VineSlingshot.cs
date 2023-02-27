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
			item.damage = 9;
			item.crit = 8;
			item.ranged = true;
			item.width = 42;
			item.height = 30;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.autoReuse = false;
			item.value = Item.sellPrice(0, 0, 0, 50);
			item.rare = 2;
			item.UseSound = SoundID.Item5;
            item.shoot = 51;
			item.shootSpeed = 12f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
	}
}
