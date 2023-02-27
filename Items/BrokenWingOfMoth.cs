using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items
{
    public class BrokenWingOfMoth : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.SetDefault("碎蛾翼");
        }
        public override void SetDefaults()
        {

            item.width = 26;//宽
            item.height = 32;//高
            item.rare = 3;//品质
            item.scale = 1f;//大小
            item.value = 50;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
