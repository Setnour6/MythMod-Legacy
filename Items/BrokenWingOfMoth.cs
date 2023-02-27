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

            Item.width = 26;//宽
            Item.height = 32;//高
            Item.rare = 3;//品质
            Item.scale = 1f;//大小
            Item.value = 50;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
