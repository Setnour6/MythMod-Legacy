using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Festival//制作是mod名字
{
    public class KongmingLamp : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("孔明灯");
            Tooltip.SetDefault("孔明灯");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.width = 22;//宽
            base.item.height = 32;//高
            base.item.rare = 10;//品质
            item.noUseGraphic = true;//不用使用物件贴图 直接抛出抛掷物
            item.shoot = mod.ProjectileType("KongmingLamp");//发出抛掷物“yoyo”
            item.shootSpeed = 0.005f;
            base.item.scale = 1f;//大小
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 60;
            base.item.useTime = 60;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 20000;
        }
    }
}
