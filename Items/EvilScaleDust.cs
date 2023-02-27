using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items
{
    public class EvilScaleDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.SetDefault("魔鳞粉");
        }
        public override void SetDefaults()
        {

            Item.width = 34;//宽
            Item.height = 16;//高
            Item.rare = 3;//品质
            Item.scale = 1f;//大小
            Item.value = 50;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
