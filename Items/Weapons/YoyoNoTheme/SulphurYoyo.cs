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

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class SulphurYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("硫磺悠悠球");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 30;
            item.height = 28;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("SulphurYoyo");
            item.useAnimation = 5;
            item.useTime = 14;
            item.shootSpeed = 0f;
            item.noMelee = true;
            item.knockBack = 0.2f;
            item.damage = 250;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 11;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 20);
            modRecipe.AddIngredient(null, "Sulfur", 64);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
