using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class YellowGreenSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("黄绿陨石光剑");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 25;//伤害
            item.melee = true;//是否是近战
            item.width = 48;//宽
            item.height = 48;//高
            item.useTime = 25;//使用时挥动间隔时间
            item.rare = 2;//品质
            item.useAnimation = 25;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 5.0f ;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = false;
            item.crit = 4;//暴击
            item.value = 27000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2((float)hitbox.X, (float)hitbox.Y), 102 / 255f, 220 / 255f, 0 / 255f);
        }
        public override void AddRecipes()
        {//合成表1
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(117, 15); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.AddIngredient(null, "Olivine", 2); //要用一个泥土制作，1是数量，ItemID.DirtBlock是泥土
            recipe.SetResult(this, 1);//制作一个材料
            recipe.requiredTile[0] = 16;	//要在工作台旁制作，18是工作台的放置物id
            recipe.AddRecipe();
        }
    }
}
