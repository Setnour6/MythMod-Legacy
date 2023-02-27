using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class CurseYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "诅咒焰球");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "用烈焰熔化抑郁\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        private int o = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.useStyle = 5;
            Item.width = 24;
            Item.height = 24;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.channel = true;
            Item.shoot = Mod.Find<ModProjectile>("CurseYoyo").Type;
            Item.useAnimation = 5;
            Item.useTime = 14;
            Item.shootSpeed = 0f;
            Item.knockBack = 0.2f;
            Item.damage = 30;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.rare = 3;
            ItemID.Sets.Yoyo[base.Item.type] = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("CurseflameScale").Type, 5);
            recipe.AddIngredient(3279, 1); 
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
