using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Fishes
{
	// Token: 0x02000719 RID: 1817
    public class Squid : ModItem
	{
		// Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("123");
			base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "鱿鱼");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "鱿鱼");
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
		public override void SetDefaults()
		{
			base.item.width = 26;
			base.item.height = 26;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 0, 15, 0);
			base.item.rare = 6;
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Squid"), 1); //��Ҫһ发光磷虾
            recipe.AddIngredient(31, 1); //��Ҫһ发光磷虾
            recipe.requiredTile[0] = 405;
            recipe.SetResult(mod.ItemType("freshSquid"), 1); //����һ发光磷虾
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("Squid"), 1); //��Ҫһ发光磷虾
            recipe2.AddIngredient(31, 1); //��Ҫһ发光磷虾
            recipe2.requiredTile[0] = 215;
            recipe2.SetResult(mod.ItemType("freshSquid"), 1); //����һ发光磷虾
            recipe2.AddRecipe();
        }
    }
}


