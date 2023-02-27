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
            base.DisplayName.SetDefault("石榴石弹弓");
            base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
			base.item.damage = 16;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 38;
			base.item.height = 36;
			base.item.useTime = 22;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = false;
			base.item.value = Item.sellPrice(0, 0, 10, 0);
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = base.mod.ProjectileType("HotPinkGemBead");
			base.item.shootSpeed = 11.5f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Garnet"), 8);
            recipe.AddIngredient(57, 6);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
	}
}
