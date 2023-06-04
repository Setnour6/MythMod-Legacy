using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MythMod.Items.Weapons.Weapon2
{
    public class NeutralBloodSword : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("NeutralBloodSword");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "神经刺刀");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 46;
			base.Item.width = 32;
			base.Item.height = 32;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            base.Item.useTime = 6;
			base.Item.useAnimation = 6;
			base.Item.useStyle = 5;
			base.Item.knockBack = 0.5f;
			base.Item.value = 1200;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = false;
            base.Item.shoot = base.Mod.Find<ModProjectile>("NeutralBloodSword").Type;
			base.Item.shootSpeed = 23f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X + speedX * 4f, position.Y + speedY * 4f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(6);
            modRecipe.requiredTile[0] = 16;
            modRecipe.Register();
            Recipe modRecipe2 = /* base */Recipe.Create(this.Type, 1);
            modRecipe2.AddIngredient(null, "CellOfN", 5);
            modRecipe2.AddIngredient(3495);
            modRecipe2.requiredTile[0] = 16;
            modRecipe2.Register();
        }
    }
}
