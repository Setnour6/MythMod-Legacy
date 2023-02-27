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
            base.DisplayName.SetDefault("绿松石法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "绿松石法杖");
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public override void SetDefaults()
		{
			base.item.damage = 28;
			base.item.magic = true;
			base.item.mana = 7;
			base.item.width = 30;
			base.item.height = 30;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 0, 45, 0);
			base.item.rare = 1;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("绿松石法杖Pro");
			base.item.shootSpeed = 10.2f;
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1257, 10);
            modRecipe.AddIngredient(null, "Turquoise", 8);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
