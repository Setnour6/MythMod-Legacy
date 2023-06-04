﻿using Terraria.ID;
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
            // DisplayName.SetDefault("红灯笼");
            // Tooltip.SetDefault("充满年味");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.width = 32;//宽
            base.Item.height = 24;
            base.Item.rare = 2;//品质
            base.Item.scale = 1f;//大小
            base.Item.createTile = base.Mod.Find<ModTile>("大红灯笼").Type;
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
