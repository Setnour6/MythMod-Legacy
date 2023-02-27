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
    public class NavyCrystalSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("海蓝晶光刃");
        }
        public override void SetDefaults()
        {
            item.damage = 49;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 26;
            item.rare = 4;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 5.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 27000;
            item.scale = 1f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 0 / 255f, 12 / 255f, 220 / 255f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(502, 50);
            recipe.AddIngredient(null, "NavyLightSword", 1);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
    }
}
