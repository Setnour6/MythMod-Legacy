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
            // base.DisplayName.SetDefault("缠绕藤蔓");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "缠绕藤蔓");
		}
		public override void SetDefaults()
		{
			base.Item.width = 40;
			base.Item.height = 40;
			base.Item.value = Item.sellPrice(0, 4, 0, 0);
			base.Item.rare = 1;
			base.Item.noUseGraphic = true;
			base.Item.useStyle = 5;
			base.Item.shootSpeed = 15f;
			base.Item.shoot = base.Mod.Find<ModProjectile>("VinePro").Type;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.noMelee = false;
            base.Item.damage = 23;
            base.Item.knockBack = 4f;//击退
            base.Item.crit = 12;//暴击
		}
	}
}
