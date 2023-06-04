using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class LazarStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("LazarStaff");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "深红凝视");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 40;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 20;
			base.Item.width = 68;
			base.Item.height = 68;
			base.Item.useTime = 4;
			base.Item.useAnimation = 4;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 9, 0, 0);
			base.Item.rare = 7;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("RedLazar").Type;
			base.Item.shootSpeed = 20f;
		}
        private int i = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY);
            i += 1;
            if(i % 50 == 0)
            {
                Vector2 v2 = v;
                for (int m = 0;m < 20; m++)
                {
                    v2 = v2.RotatedBy(Math.PI * 2 / 20d);
                    Projectile.NewProjectile((float)position.X + speedX * 2, (float)position.Y + speedY * 2, v2.X, v2.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
                }
            }
            if (i % 3 == 0)
            {
                Vector2 v2 = v.RotatedBy(Math.PI * 2 / 8d);
                for (int m = 0; m < 7; m++)
                {
                    v2 = v2.RotatedBy(-Math.PI * 2 / 32d);
                    Projectile.NewProjectile((float)position.X + v2.X * 2.2f, (float)position.Y + v2.Y * 2.2f, v.X, v.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
                }
            }
            float shootSpeed = base.Item.shootSpeed;
            Vector2 v3 = v.RotatedBy(Math.Sin(i / 8f) * 0.3d);
            Vector2 v4 = v.RotatedBy(-Math.Sin(i / 8f) * 0.3d);
            Projectile.NewProjectile((float)position.X + speedX * 2, (float)position.Y + speedY * 2, v3.X, v3.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            Projectile.NewProjectile((float)position.X + speedX * 2, (float)position.Y + speedY * 2, v4.X, v4.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            Vector2 v5 = v.RotatedBy(Math.Cos(i / 8f) * 0.3d);
            Vector2 v6 = v.RotatedBy(-Math.Cos(i / 8f) * 0.3d);
            Projectile.NewProjectile((float)position.X + speedX * 2, (float)position.Y + speedY * 2, v5.X, v5.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            Projectile.NewProjectile((float)position.X + speedX * 2, (float)position.Y + speedY * 2, v6.X, v6.Y, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
		{
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "LazarBattery", 16);
            modRecipe.AddIngredient(113, 1);
            modRecipe.AddIngredient(547, 10);
            modRecipe.AddIngredient(548, 10);
            modRecipe.AddIngredient(549, 10);
            modRecipe.requiredTile[0] = 134;
            modRecipe.Register();
        }
	}
}
