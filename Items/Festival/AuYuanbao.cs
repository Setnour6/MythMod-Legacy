using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class AuYuanbao : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("金元宝摆件");
            // Tooltip.SetDefault("充满年味");
        }
        public override void SetDefaults()
        {
            base.Item.width = 16;
            base.Item.height = 12;
            base.Item.rare = 2;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("元宝").Type;
            base.Item.placeStyle = 2;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 9999;
        }
    }
}
