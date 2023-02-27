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
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
            //base.Tooltip.AddTranslation(GameCulture.Chinese, "骸骨制成");
        }
        public override void SetDefaults()
        {
            Item.useStyle = 5;
            Item.width = 24;
            Item.height = 24;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.channel = true;
            Item.shoot = Mod.Find<ModProjectile>("StarMarkYoyo").Type;
            Item.useAnimation = 5;
            Item.useTime = 14;
            Item.shootSpeed = 0f;
            Item.knockBack = 0.2f;
            Item.damage = 40;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.rare = 3;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(824, 10);//日盘块
            recipe.AddIngredient(75, 30);//落星
            recipe.requiredTile[0] = 305;
            recipe.Register();
        }
    }
}
