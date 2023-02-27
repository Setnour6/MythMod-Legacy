using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x0200052F RID: 1327
    public class PurpleGemSlingshot : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("紫晶弹弓");
            base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
			base.item.damage = 12;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 38;
			base.item.height = 36;
			base.item.useTime = 27;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = false;
			base.item.value = Item.sellPrice(0, 0, 10, 0);
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = base.mod.ProjectileType("PurpleGemBead");
			base.item.shootSpeed = 9.5f;
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00003B08 File Offset: 0x00001D08
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {//合成表1
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(181, 8); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.AddIngredient(20, 6); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.SetResult(this, 1);//制作一个材料
            recipe.requiredTile[0] = 16;	//要在工作台旁制作，18是工作台的放置物id
            recipe.AddRecipe();
        }
	}
}
