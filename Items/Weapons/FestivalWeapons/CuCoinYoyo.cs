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

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class CuCoinYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "铜币球");
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 30;
            item.height = 28;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;//近战 开
            item.channel = true;//通道开
            item.shoot = mod.ProjectileType("CuCoinYoyo");
            item.useAnimation = 5;//使用动画 调的越小发射频率越快
            item.useTime = 14;//使用时间 
            item.shootSpeed = 0f;//抛掷物的移速
            item.noMelee = true;//近战 开
            item.knockBack = 0.2f;//击退
            item.damage = 15;
            item.value = Item.sellPrice(0, 0, 0, 99);//价值
            item.rare = 2;//品质
        }
    }
}
