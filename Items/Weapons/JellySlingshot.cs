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
			base.Item.damage = 18;
			base.Item.crit = 8;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 42;
			base.Item.height = 30;
			base.Item.useTime = 14;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = false;
			base.Item.value = Item.sellPrice(0, 0, 0, 50);
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item5;
            Item.shoot = Mod.Find<ModProjectile>("JellyBall").Type;
			base.Item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
	}
}
