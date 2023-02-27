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
            base.Item.damage = 150;
			base.Item.width = 46;
			base.Item.height = 26;
			base.Item.useTime = 11;
			base.Item.useAnimation = 11;
			base.Item.useStyle = 5;
            base.Item.mana = 11;
            base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.knockBack = 1f;
			base.Item.value = 50000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("FreezeLazar").Type;
			base.Item.shootSpeed = 40f;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.Next(0, 100) > 24;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(514);
            recipe.AddIngredient(2161, 5);
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
