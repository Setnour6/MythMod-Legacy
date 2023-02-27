using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class CrystalLazarGun : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("晶状体激光枪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "晶状体激光枪");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 22;
			base.Item.DamageType = DamageClass.Magic;
            base.Item.mana = 4; 
            base.Item.rare = 3;
			base.Item.width = 56;
			base.Item.height = 26;
			base.Item.useTime = 12;
			base.Item.useAnimation = 12;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 3.75f;
			base.Item.value = 35000;
			base.Item.UseSound = SoundID.Item95;
			base.Item.autoReuse = true;
            base.Item.shoot = 83;

            base.Item.shootSpeed = 13f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            int u = Main.rand.Next(0, 12000);
            if(u < 10500)
            {
                int num = Projectile.NewProjectile(position.X + speedX, position.Y - 12f + speedY, speedX, speedY, 83, damage, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
            }
            if (u >= 10500 && u < 12000)
            {
                int num = Projectile.NewProjectile(position.X + speedX, position.Y - 12f + speedY, speedX, speedY, 100, damage * 2, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
            }
            return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, -5.0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("CrystalLazarGun").Type, 1);
            recipe.AddIngredient(null, "BloodCryst", 2);
            recipe.AddIngredient(38, 30);
            recipe.AddIngredient(236, 5);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
