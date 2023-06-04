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
            // Tooltip.SetDefault("这似乎是某些东西的碎片");
            // DisplayName.SetDefault("MysteriesPearlBroken");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘碎片");
        }
        public override void SetDefaults()
        {
            Item.width = 28;//宽
            Item.height = 22;//高
            Item.rare = 9;//品质
            Item.scale = 1f;//大小
            Item.value = 8000;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
