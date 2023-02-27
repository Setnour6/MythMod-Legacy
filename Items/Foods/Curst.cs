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
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.item.useStyle = 1;
			base.item.useTurn = true;
            item.width = 56;
            item.height = 38;
            item.rare = 2;
            item.scale = 1f;
            item.value = 100;
            item.maxStack = 999;
        }
        public override void AddRecipes()
        {
        }
    }
}
