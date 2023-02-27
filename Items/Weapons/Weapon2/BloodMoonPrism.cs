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
    public class BloodMoonPrism : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("血月棱镜");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血月棱镜");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 70;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 24;
			base.Item.width = 18;
			base.Item.height = 22;
			base.Item.useTime = 15;
			base.Item.useAnimation = 15;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 12000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("BloodMoonLight").Type;
			base.Item.shootSpeed = 14f;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(170, 50);
            recipe.AddIngredient(Mod.Find<ModItem>("BloodCryst").Type, 8);
            recipe.AddIngredient(Mod.Find<ModItem>("PureJelly").Type, 8);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X + speedX * 2f, position.Y + speedY * 2f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    }
}
