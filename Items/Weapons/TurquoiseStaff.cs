using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x020005C2 RID: 1474
    public class TurquoiseStaff : ModItem
	{
		// Token: 0x060019F2 RID: 6642 RVA: 0x00008ED2 File Offset: 0x000070D2
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("绿松石法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "绿松石法杖");
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public override void SetDefaults()
		{
			base.Item.damage = 28;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 7;
			base.Item.width = 30;
			base.Item.height = 30;
			base.Item.useTime = 26;
			base.Item.useAnimation = 26;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 0, 45, 0);
			base.Item.rare = 1;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("绿松石法杖Pro").Type;
			base.Item.shootSpeed = 10.2f;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
		public override void AddRecipes()
		{
			Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
			modRecipe.AddIngredient(1257, 10);
            modRecipe.AddIngredient(null, "Turquoise", 8);
			modRecipe.AddTile(16);
			modRecipe.Register();
		}
	}
}
