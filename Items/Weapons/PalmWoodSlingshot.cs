using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x0200052F RID: 1327
    public class PalmWoodSlingshot : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("棕榈木弹弓");
            // base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
			base.Item.damage = 7;
			base.Item.crit = 6;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 42;
			base.Item.height = 30;
			base.Item.useTime = 16;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = false;
			base.Item.value = Item.sellPrice(0, 0, 0, 50);
			base.Item.rare = 1;
			base.Item.UseSound = SoundID.Item5;
                 Item.shoot = 51;
			base.Item.shootSpeed = 8f;
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00003B08 File Offset: 0x00001D08
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {//合成表1
            Recipe recipe = CreateRecipe(1);//制作一个材料
            recipe.AddIngredient(ItemID.PalmWood, 7); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.AddIngredient(ItemID.Cobweb, 14); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.requiredTile[0] = 18;	//要在工作台旁制作，18是工作台的放置物id
            recipe.Register();
        }
	}
}
