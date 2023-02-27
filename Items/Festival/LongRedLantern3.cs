using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class LongRedLantern3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("侧挂灯笼");
            Tooltip.SetDefault("充满年味");
        }
        public override void SetDefaults()
        {
            base.item.width = 32;
            base.item.height = 24;
            base.item.rare = 2;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("LargeLantern3");
            base.item.placeStyle = 0;
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 10000;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
