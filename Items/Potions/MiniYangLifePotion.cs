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
    public class MiniYangLifePotion : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("迷你阳血药剂");
            base.Tooltip.SetDefault("可以在白天回复阳寿命");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 8;
			base.Item.height = 24;
            base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            Item.value = 500;
            base.Item.maxStack = 200;
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
                    modPlayer.YangLife += 1;
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
            recipe.AddIngredient(5, 3); //需要一个材料
            recipe.AddIngredient(27, 3); //需要一个材料
            recipe.AddIngredient(38, 1); //需要一个材料
            recipe.AddIngredient(209, 1); //需要一个材料
            recipe.AddIngredient(210, 1); //需要一个材料
            recipe.AddIngredient(126, 1); //需要一个材料
            recipe.requiredTile[0] = 13;
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(313, 1); //需要一个材料
            recipe2.AddIngredient(28, 1); //需要一个材料
            recipe2.requiredTile[0] = 13;
            recipe2.Register();
        }
	}
}
