using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Furnitures//制作是mod名字
{
    public class AirLiftLabel : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.width = 48;//宽
            base.item.height = 64;//高
            base.item.rare = 2;//品质
            base.item.scale = 1f;//大小
            base.item.createTile = base.mod.TileType("天域电梯楼层显示标");
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
            modRecipe.AddIngredient(824, 2);
            modRecipe.SetResult(this, 1);
            modRecipe.AddTile(305);
            modRecipe.AddRecipe();
        }
    }
}
