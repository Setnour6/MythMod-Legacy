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
            base.Item.width = 22;//宽
            base.Item.height = 32;//高
            base.Item.rare = 10;//品质
            Item.noUseGraphic = true;//不用使用物件贴图 直接抛出抛掷物
            Item.shoot = Mod.Find<ModProjectile>("KongmingLamp").Type;//发出抛掷物“yoyo”
            Item.shootSpeed = 0.005f;
            base.Item.scale = 1f;//大小
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 60;
            base.Item.useTime = 60;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 20000;
        }
    }
}
