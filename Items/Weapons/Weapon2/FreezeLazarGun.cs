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
namespace MythMod.Items.Weapons.Weapon2
{
    public class FreezeLazarGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰凌激光");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出冷冻射线");
        }
        public override void SetDefaults()
        {
            base.item.damage = 150;
			base.item.width = 46;
			base.item.height = 26;
			base.item.useTime = 11;
			base.item.useAnimation = 11;
			base.item.useStyle = 5;
            base.item.mana = 11;
            base.item.noMelee = true;
			base.item.magic = true;
			base.item.knockBack = 1f;
			base.item.value = 50000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("FreezeLazar");
			base.item.shootSpeed = 40f;
		}
        public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.Next(0, 100) > 24;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(514);
            recipe.AddIngredient(2161, 5);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
    }
}
