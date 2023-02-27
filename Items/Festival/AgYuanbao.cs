using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class AgYuanbao : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("银元宝摆件");
            Tooltip.SetDefault("充满年味");
        }
        public override void SetDefaults()
        {
            base.item.width = 16;
            base.item.height = 12;
            base.item.rare = 2;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("元宝");
            base.item.placeStyle = 1;
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 999;
        }
    }
}
