using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class MossRay : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("苔泥射线");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "苔泥射线");
		}
		public override void SetDefaults()
		{
			base.item.damage = 11;
			base.item.magic = true;
			base.item.mana = 6;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.value = 2000;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("泥浆射线");
			base.item.shootSpeed = 6f;
		}
	}
}
