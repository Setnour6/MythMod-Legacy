using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Furnitures
{
    public class GraniteLiftDoor : ModItem
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
            base.item.createTile = base.mod.TileType("电梯门");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 4000;
            base.item.placeStyle = 6;
        }
    }
}
