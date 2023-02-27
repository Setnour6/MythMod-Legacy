using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class FireWorkBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("10寸礼花弹");
            Tooltip.SetDefault("美丽的烟花，爆出千变万化的造型");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = 24;
            Item.scale = 1f;
            Item.value = 2000;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
