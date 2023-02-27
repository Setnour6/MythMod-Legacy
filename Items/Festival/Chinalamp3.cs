using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class Chinalamp3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灯");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.item.width = 16;
            base.item.height = 16;
            base.item.rare = 3;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("Chinalamp3");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 3000;
        }
    }
}
