using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class JellySlingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("凝胶弹弓");
			base.Tooltip.SetDefault("神话");
		}
		public override void SetDefaults()
		{
			base.item.damage = 18;
			base.item.crit = 8;
			base.item.ranged = true;
			base.item.width = 42;
			base.item.height = 30;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = false;
			base.item.value = Item.sellPrice(0, 0, 0, 50);
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item5;
            item.shoot = mod.ProjectileType("JellyBall");
			base.item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
	}
}
