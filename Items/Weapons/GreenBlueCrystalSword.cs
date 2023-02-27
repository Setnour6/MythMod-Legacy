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
    public class GreenBlueCrystalSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("蓝绿晶光刃");
        }
        public override void SetDefaults()
        {
            Item.damage = 49;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 26;
            Item.rare = 4;
            Item.useAnimation = 26;
            Item.useStyle = 1;
            Item.knockBack = 5.0f ;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 27000;
            Item.scale = 1f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 20 / 255f, 120 / 255f, 100 / 255f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(502, 50);
            recipe.AddIngredient(null, "GreenBlueSword", 1);
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
