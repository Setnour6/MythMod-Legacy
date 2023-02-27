using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Furnitures.Routers
{
    public class MarbleWoodRouter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("大理石路由器");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "右键使用手机,靠近获得联网,可以网购");
        }
        public override void SetDefaults()
        {
            base.Item.width = 48;
            base.Item.height = 64;
            base.Item.rare = 2;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("MarbleWoodRouter").Type;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 400;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "LazarBattery", 1);
            modRecipe.AddIngredient(3066, 10);
            modRecipe.AddTile(18);
            modRecipe.Register();
        }
    }
}
