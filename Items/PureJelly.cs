using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class PureJelly : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("空明凝胶");
            Tooltip.SetDefault("只少量的存在于极个别体型巨大的地球史莱姆体内\n这是世界上最纯净的凝胶\n神话");
            ItemID.Sets.AnimatesAsSoul[Item.type] = false;
            ItemID.Sets.ItemIconPulse[Item.type] = false; 
            ItemID.Sets.ItemNoGravity[Item.type] = false;
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 999;
            Item.value = 10000;
            Item.rare = 3;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(3368, 1);
            modRecipe.AddIngredient(null, "PureJelly", 20);
            modRecipe.requiredTile[0] = 16;
            modRecipe.Register();
        }
    }
}