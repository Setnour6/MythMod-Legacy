using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Gems
{
    public class MysteriesBroken : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("这似乎是某些东西的碎片");
            DisplayName.SetDefault("MysteriesPearlBroken");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘碎片");
        }
        public override void SetDefaults()
        {
            item.width = 28;//宽
            item.height = 22;//高
            item.rare = 9;//品质
            item.scale = 1f;//大小
            item.value = 8000;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
