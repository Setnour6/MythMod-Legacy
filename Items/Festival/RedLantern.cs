using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival//制作是mod名字
{
    public class RedLantern : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("红灯笼");
            Tooltip.SetDefault("充满年味");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.width = 32;//宽
            base.item.height = 24;
            base.item.rare = 2;//品质
            base.item.scale = 1f;//大小
            base.item.createTile = base.mod.TileType("大红灯笼");
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
