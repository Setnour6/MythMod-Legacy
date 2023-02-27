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
    public class AuCoinYoyo : ModItem//教程是你的文件的名字
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;//这是一个yoyo球
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;//这两个不用做变动
            DisplayName.AddTranslation(GameCulture.Chinese, "金币球");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item.useStyle = 5;//使用方式
            Item.width = 30;//长
            Item.height = 28;//高
            Item.noUseGraphic = true;//不用使用物件贴图 直接抛出抛掷物
            Item.UseSound = SoundID.Item1;//使用时的声音
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//近战 开
            Item.channel = true;//通道开
            Item.shoot = Mod.Find<ModProjectile>("AuCoinYoyo").Type;//发出抛掷物“yoyo”
            Item.useAnimation = 5;//使用动画 调的越小发射频率越快
            Item.useTime = 14;//使用时间 
            Item.shootSpeed = 0f;//抛掷物的移速
            Item.noMelee = true;//近战 开
            Item.knockBack = 0.2f;//击退
            Item.damage = 240;
            Item.value = Item.sellPrice(0, 9, 99, 99);//价值
            Item.rare = 6;//品质
        }
    }
}
