using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.Weapons.FestivalWeapons//教程是你的mod文件夹的名字
{
    public class PtCoinYoyo : ModItem//教程是你的文件的名字
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;//这是一个yoyo球
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;//这两个不用做变动
            DisplayName.AddTranslation(GameCulture.Chinese, "铂金币球");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.useStyle = 5;//使用方式
            item.width = 30;//长
            item.height = 28;//高
            item.noUseGraphic = true;//不用使用物件贴图 直接抛出抛掷物
            item.UseSound = SoundID.Item1;//使用时的声音
            item.melee = true;//近战 开
            item.channel = true;//通道开
            item.shoot = mod.ProjectileType("PtCoinYoyo");//发出抛掷物“yoyo”
            item.useAnimation = 5;//使用动画 调的越小发射频率越快
            item.useTime = 14;//使用时间 
            item.shootSpeed = 0f;//抛掷物的移速
            item.noMelee = true;//近战 开
            item.knockBack = 0.2f;//击退
            item.damage = 405;
            item.value = Item.sellPrice(0, 9, 99, 99);//价值
            item.rare = 6;//品质
        }
    }
}
