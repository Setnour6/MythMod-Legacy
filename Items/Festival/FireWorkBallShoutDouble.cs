using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class FireWorkBallShoutDouble : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("双发礼花弹发射筒");
            Tooltip.SetDefault("可以燃放礼花弹");
        }
        public override void SetDefaults()
        {
            base.Item.width = 28;
            base.Item.height = 44;
            base.Item.rare = 3;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("双发礼花弹发射筒").Type;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 3000;
        }
    }
}
