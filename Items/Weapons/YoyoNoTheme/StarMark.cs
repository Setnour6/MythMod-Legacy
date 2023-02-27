using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class StarMark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "星光球");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
            //base.Tooltip.AddTranslation(GameCulture.Chinese, "骸骨制成");
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("StarMarkYoyo");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.knockBack = 0.2f;
            item.damage = 40;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(824, 10);//日盘块
            recipe.AddIngredient(75, 30);//落星
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 305;
            recipe.AddRecipe();
        }
    }
}
