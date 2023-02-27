using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Fishes
{
	// Token: 0x020000AF RID: 175
    public class WornIronSword : ModItem
	{
		// Token: 0x060002CE RID: 718 RVA: 0x0003529C File Offset: 0x0003349C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("锈铁剑");
			base.Tooltip.SetDefault("brush!");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "锈铁剑");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "都锈成这样了……");
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000352F4 File Offset: 0x000334F4
		public override void SetDefaults()
		{
			base.item.damage = 1;
			base.item.melee = true;
			base.item.width = 26;
			base.item.height = 26;
			base.item.useTime = 40;
			base.item.useAnimation = 40;
			base.item.useTurn = true;
			base.item.useStyle = 1;
			base.item.knockBack = 0.1f;
			base.item.value = 0;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
            base.item.rare = -1;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000353C8 File Offset: 0x000335C8

		// Token: 0x060002D1 RID: 721 RVA: 0x00035450 File Offset: 0x00033650
		//public override void AddRecipes()
		//{
			//ModRecipe modRecipe = new ModRecipe(base.mod);
			//modRecipe.AddIngredient(null, "沧流锭", 12);
		//	modRecipe.AddIngredient(null, "洋蓝石", 5);
          //  modRecipe.AddIngredient(null, "空灵泡", 5);
         //   modRecipe.AddIngredient(null, "海因子", 5);
          //  modRecipe.requiredTile[0] = 412;
			//modRecipe.SetResult(this, 1);
			//modRecipe.AddRecipe();
		//}
	}
}
