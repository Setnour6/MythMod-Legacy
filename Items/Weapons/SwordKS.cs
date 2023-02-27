using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordKS : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·史莱姆王");
            base.Tooltip.SetDefault("你的实力已经碾压了史莱姆王，这把属于你的剑里面封印了它的灵魂\n放出弹来弹去的史莱姆剑气\n神话");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 12;//伤害
            item.melee = true;//是否是近战
            item.width = 50;//宽
            item.height = 50;//高
            item.useTime = 48;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 24;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 2f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 4;//暴击
            item.value = 10000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
            item.shoot = mod.ProjectileType("SlimeBeam");
            item.shootSpeed = 3.75f;
        }
    }
}
