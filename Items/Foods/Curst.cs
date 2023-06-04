using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Foods
{
    public class Curst : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            Item.width = 56;
            Item.height = 38;
            Item.rare = 2;
            Item.scale = 1f;
            Item.value = 100;
            Item.maxStack = 999;
        }
        public override void AddRecipes()
        {
        }
    }
}
