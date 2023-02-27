using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Gems
{
    public class PinkFluorite : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("来自地狱的结晶");
            DisplayName.SetDefault("SaltCrystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "粉萤石");
        }
        public override void SetDefaults()
        {
            //base.item.createTile = base.mod.TileType("硫磺矿");
            base.item.useStyle = 1;
			base.item.useTurn = true;
            base.item.useAnimation = 15;
			base.item.useTime = 10;
            base.item.autoReuse = true;
			base.item.consumable = true;
            item.width = 32;//宽
            item.height = 26;//高
            item.rare = 2;//品质
            item.scale = 1f;//大小
            item.value = 6000;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
