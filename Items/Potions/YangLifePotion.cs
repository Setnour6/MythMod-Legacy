using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Potions
{
	// Token: 0x0200015B RID: 347
    public class YangLifePotion : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("阳血药剂");
            base.Tooltip.SetDefault("可以在白天回复阳寿命");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 20;
			base.Item.height = 26;
            base.Item.rare = 3;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 10000;
        }

		// Token: 0x060005E5 RID: 1509 RVA: 0x000043CB File Offset: 0x000025CB
		// Token: 0x060005E6 RID: 1510 RVA: 0x000417F8 File Offset: 0x0003F9F8
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = base.Item.useTime;
                if(Main.dayTime)
                {
                    base.Item.consumable = true;
                    modPlayer.YangLife += 5;
                }
                else
                {
                    base.Item.consumable = false;
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(5, 10); //需要一个材料
            recipe.AddIngredient(27, 10); //需要一个材料
            recipe.AddIngredient(38, 3); //需要一个材料
            recipe.AddIngredient(209, 3); //需要一个材料
            recipe.AddIngredient(210, 3); //需要一个材料
            recipe.AddIngredient(126, 1); //需要一个材料
            recipe.requiredTile[0] = 13;
            recipe.Register();
            Recipe recipe2 = CreateRecipe(2);
            recipe2.AddIngredient(29, 1); //需要一个材料
            recipe2.AddIngredient(126, 1); //需要一个材料
            recipe2.requiredTile[0] = 13;
            recipe2.Register();
        }
	}
}
