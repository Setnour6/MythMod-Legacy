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
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            ItemID.Sets.ItemIconPulse[item.type] = false; 
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 10000;
            item.rare = 3;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "PureJelly", 20);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(3368, 1);
            modRecipe.AddRecipe();
        }
    }
}