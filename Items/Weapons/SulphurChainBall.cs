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
			base.Item.damage = 352;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.width = 68;
			base.Item.height = 68;
			base.Item.useTime = 20;
			base.Item.useAnimation = 20;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.noUseGraphic = true;
			base.Item.knockBack = 8f;
			base.Item.value = Item.buyPrice(0, 9, 0, 0);
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
			base.Item.channel = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("硫磺玄武岩链球").Type;
			base.Item.shootSpeed = 12f;
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Basalt", 30);
            modRecipe.AddIngredient(null, "Sulfur", 48);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
