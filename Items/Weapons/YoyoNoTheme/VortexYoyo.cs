using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class VortexYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("漩涡球");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "这里面有澎湃的惊涛");
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
            Item.shoot = Mod.Find<ModProjectile>("VortexYoyo").Type;
            Item.useAnimation = 5;
            Item.useTime = 14;
            Item.shootSpeed = 0f;
            Item.knockBack = 0.2f;
            Item.damage = 204;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 8;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "OceanBlueBar", 12);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
