using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Corals
{
    public class Barnacle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("藤壶");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.item.width = 48;
            base.item.height = 14;
            base.item.rare = 0;
            base.item.scale = 1f;
            base.item.createTile = 0;
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
        }
        public override void UpdateInventory(Player player)
        {
            base.item.createTile = base.mod.TileType("稀疏藤壶" + (Main.rand.Next(3) + 1).ToString());
            base.UpdateInventory(player);
        }
    }
}
