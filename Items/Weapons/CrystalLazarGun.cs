using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
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
			base.item.damage = 22;
			base.item.magic = true;
            base.item.mana = 4; 
            base.item.rare = 3;
			base.item.width = 56;
			base.item.height = 26;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 3.75f;
			base.item.value = 35000;
			base.item.UseSound = SoundID.Item95;
			base.item.autoReuse = true;
            base.item.shoot = 83;

            base.item.shootSpeed = 13f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodCryst", 2);
            recipe.AddIngredient(38, 30);
            recipe.AddIngredient(236, 5);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(mod.ItemType("CrystalLazarGun"), 1);
            recipe.AddRecipe();
        }
    }
}
