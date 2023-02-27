using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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

namespace MythMod.Items.Weapons
{
    public class ScaleWingBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("鳞翅之刃");
            Tooltip.SetDefault("");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 37;//伤害
            item.melee = true;//是否是近战
            item.width = 50;//宽
            item.height = 72;//高
            item.useTime = 22;//使用时挥动间隔时间
            item.rare = 3;//品质
            item.useAnimation = 22;//挥动时动作持续时间
            item.useStyle = 1;//使用动画，这里是挥动
            item.knockBack = 2;//击退
            item.UseSound = SoundID.Item1;//挥动声音
            item.autoReuse = true;//能否持续挥动
            item.crit = 4;//暴击
            item.value = 3000;//价值，1表示一铜币，这里是100铂金币
            item.scale = 1f;//大小
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 113, 0f, 0f, 0, default(Color), 0.4f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 240, 0f, 0f, 0, default(Color), 0.4f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 240, 0f, 0f, 0, default(Color), 0.4f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EvilScaleDust", 6); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenWingOfMoth", 14); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1); //����һ������
            recipe.AddRecipe();
        }
    }
}
