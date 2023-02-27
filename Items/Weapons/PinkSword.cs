using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class PinkSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("紫红陨石光剑");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 25;//伤害
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//是否是近战
            Item.width = 48;//宽
            Item.height = 48;//高
            Item.useTime = 25;//使用时挥动间隔时间
            Item.rare = 2;//品质
            Item.useAnimation = 25;//挥动时动作持续时间
            Item.useStyle = 1;//使用动画，这里是挥动
            Item.knockBack = 5.0f ;//击退
            Item.UseSound = SoundID.Item1;//挥动声音
            Item.autoReuse = false;
            Item.crit = 4;//暴击
            Item.value = 27000;//价值，1表示一铜币，这里是100铂金币
            Item.scale = 1f;//大小
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 220 / 255f, 0 / 255f, 164 / 255f);
        }
        public override void AddRecipes()
        {//合成表1
            Recipe recipe = CreateRecipe(1);//制作一个材料
            recipe.AddIngredient(117, 15); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.AddIngredient(null, "Garnet", 2); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.requiredTile[0] = 16;	//要在工作台旁制作，18是工作台的放置物id
            recipe.Register();
        }
    }
}
