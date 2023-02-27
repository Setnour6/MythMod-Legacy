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
            base.Item.width = 48;
            base.Item.height = 14;
            base.Item.rare = 0;
            base.Item.scale = 1f;
            base.Item.createTile = 0;
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
        }
        public override void UpdateInventory(Player player)
        {
            base.Item.createTile = base.Mod.Find<ModTile>("稀疏藤壶" + (Main.rand.Next(3) + 1).ToString()).Type;
            base.UpdateInventory(player);
        }
    }
}
