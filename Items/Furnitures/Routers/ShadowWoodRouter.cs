using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Furnitures.Routers
{
    public class ShadowWoodRouter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("暗影木路由器");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "右键使用手机,靠近获得联网,可以网购");
        }
        public override void SetDefaults()
        {
            base.item.width = 48;
            base.item.height = 64;
            base.item.rare = 2;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("ShadowWoodRouter");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 400;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "LazarBattery", 1);
            modRecipe.AddIngredient(911, 10);
            modRecipe.SetResult(this, 1);
            modRecipe.AddTile(18);
            modRecipe.AddRecipe();
        }
    }
}
