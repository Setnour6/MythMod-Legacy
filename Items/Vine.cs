using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class Vine : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("缠绕藤蔓");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "缠绕藤蔓");
		}
		public override void SetDefaults()
		{
			base.item.width = 40;
			base.item.height = 40;
			base.item.value = Item.sellPrice(0, 4, 0, 0);
			base.item.rare = 1;
			base.item.noUseGraphic = true;
			base.item.useStyle = 5;
			base.item.shootSpeed = 15f;
			base.item.shoot = base.mod.ProjectileType("VinePro");
			base.item.UseSound = SoundID.Item1;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.noMelee = false;
            base.item.damage = 23;
            base.item.knockBack = 4f;//击退
            base.item.crit = 12;//暴击
		}
	}
}
