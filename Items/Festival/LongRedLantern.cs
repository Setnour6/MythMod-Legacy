using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival
{
    public class LongRedLantern : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("长筒灯笼");
            // Tooltip.SetDefault("充满年味");
        }
        public override void SetDefaults()
        {
            base.Item.width = 32;
            base.Item.height = 24;
            base.Item.rare = 2;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("LongLantern").Type;
            base.Item.placeStyle = 0;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 10000;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
