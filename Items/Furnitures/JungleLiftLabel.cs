using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Furnitures
{
    public class JungleLiftLabel : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.item.width = 48;
            base.item.height = 64;
            base.item.rare = 2;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("丛林蜥蜴电梯楼层显示标");
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
            modRecipe.AddIngredient(null, "LiftLabel", 1);
            modRecipe.AddIngredient(1101, 2);
            modRecipe.SetResult(this, 1);
            modRecipe.AddTile(303);
            modRecipe.AddRecipe();
        }
    }
}
