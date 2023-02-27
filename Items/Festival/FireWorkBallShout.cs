using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class FireWorkBallShout : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("礼花弹发射筒");
            Tooltip.SetDefault("可以燃放礼花弹");
        }
        public override void SetDefaults()
        {
            base.item.width = 28;
            base.item.height = 44;
            base.item.rare = 3;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("礼花弹发射筒");
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
