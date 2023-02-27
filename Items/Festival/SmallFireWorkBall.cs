using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class SmallFireWorkBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("6寸礼花弹");
            Tooltip.SetDefault("美丽的烟花，爆出千变万化的造型");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = 24;
            item.scale = 1f;
            item.value = 2000;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
