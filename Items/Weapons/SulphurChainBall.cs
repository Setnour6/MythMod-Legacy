using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x0200069E RID: 1694
	public class SulphurChainBall : ModItem
	{
		// Token: 0x06001CC0 RID: 7360 RVA: 0x000087A1 File Offset: 0x000069A1
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("硫磺玄武岩链球");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺玄武岩链球");
            base.Tooltip.SetDefault("这个东西太重了,可能难以操控");
        }

		// Token: 0x06001CC1 RID: 7361 RVA: 0x000D4A44 File Offset: 0x000D2C44
		public override void SetDefaults()
		{
			base.item.damage = 352;
			base.item.melee = true;
			base.item.width = 68;
			base.item.height = 68;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.noUseGraphic = true;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 9, 0, 0);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.channel = true;
			base.item.shoot = base.mod.ProjectileType("硫磺玄武岩链球");
			base.item.shootSpeed = 12f;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 30);
            modRecipe.AddIngredient(null, "Sulfur", 48);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
