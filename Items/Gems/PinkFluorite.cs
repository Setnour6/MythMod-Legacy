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
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            base.Item.useAnimation = 15;
			base.Item.useTime = 10;
            base.Item.autoReuse = true;
			base.Item.consumable = true;
            Item.width = 32;//宽
            Item.height = 26;//高
            Item.rare = 2;//品质
            Item.scale = 1f;//大小
            Item.value = 6000;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
