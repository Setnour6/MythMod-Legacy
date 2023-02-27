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
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "铜币球");
        }
        public override void SetDefaults()
        {
            Item.useStyle = 5;
            Item.width = 30;
            Item.height = 28;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//近战 开
            Item.channel = true;//通道开
            Item.shoot = Mod.Find<ModProjectile>("CuCoinYoyo").Type;
            Item.useAnimation = 5;//使用动画 调的越小发射频率越快
            Item.useTime = 14;//使用时间 
            Item.shootSpeed = 0f;//抛掷物的移速
            Item.noMelee = true;//近战 开
            Item.knockBack = 0.2f;//击退
            Item.damage = 15;
            Item.value = Item.sellPrice(0, 0, 0, 99);//价值
            Item.rare = 2;//品质
        }
    }
}
