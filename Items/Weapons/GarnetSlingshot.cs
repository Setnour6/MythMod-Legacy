using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x0200052F RID: 1327
    public class GarnetSlingshot : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("石榴石弹弓");
            // base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
			base.Item.damage = 16;
			base.Item.crit = 6;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 38;
			base.Item.height = 36;
			base.Item.useTime = 22;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = false;
			base.Item.value = Item.sellPrice(0, 0, 10, 0);
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item5;
                 Item.shoot = base.Mod.Find<ModProjectile>("HotPinkGemBead").Type;
			base.Item.shootSpeed = 11.5f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("Garnet").Type, 8);
            recipe.AddIngredient(57, 6);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
	}
}
