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
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血月棱镜");
        }
        public override void SetDefaults()
        {
            base.item.damage = 70;
			base.item.magic = true;
			base.item.mana = 24;
			base.item.width = 18;
			base.item.height = 22;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 12000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("BloodMoonLight");
			base.item.shootSpeed = 14f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(170, 50);
            recipe.AddIngredient(mod.ItemType("BloodCryst"), 8);
            recipe.AddIngredient(mod.ItemType("PureJelly"), 8);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + speedX * 2f, position.Y + speedY * 2f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
    }
}
