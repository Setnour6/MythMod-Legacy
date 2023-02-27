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

            item.width = 34;//宽
            item.height = 16;//高
            item.rare = 3;//品质
            item.scale = 1f;//大小
            item.value = 50;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
