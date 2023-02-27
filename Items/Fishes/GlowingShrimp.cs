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
    public class GlowingShrimp : ModItem
	{
		// Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("123");
			base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "发光磷虾");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "发光磷虾");
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
		public override void SetDefaults()
		{
			base.Item.width = 26;
			base.Item.height = 26;
			base.Item.maxStack = 999;
			base.Item.value = Item.sellPrice(0, 2, 50, 0);
			base.Item.rare = 6;
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("GlowingShrimpJam").Type, 1);//����һ发光磷虾
            recipe.AddIngredient(Mod.Find<ModItem>("GlowingShrimp").Type, 1); //��Ҫһ发光磷虾
            recipe.AddIngredient(31, 1); //��Ҫһ发光磷虾
            recipe.requiredTile[0] = 16;
            recipe.Register();
            Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("GlowingShrimpJam").Type, 1);//����һ发光磷虾
            recipe2.AddIngredient(Mod.Find<ModItem>("GlowingShrimp").Type, 1); //��Ҫһ发光磷虾
            recipe2.AddIngredient(31, 1); //��Ҫһ发光磷虾
            recipe2.requiredTile[0] = 134;
            recipe2.Register();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(13f, 13f);
			spriteBatch.Draw(base.Mod.GetTexture("Items/Fishes/发光磷虾Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
    }
}


