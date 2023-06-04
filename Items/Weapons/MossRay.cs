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
            // base.DisplayName.SetDefault("苔泥射线");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "苔泥射线");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 11;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 6;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 26;
			base.Item.useAnimation = 26;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.value = 2000;
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("泥浆射线").Type;
			base.Item.shootSpeed = 6f;
		}
	}
}
