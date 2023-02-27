using System;
using Terraria;
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
            base.DisplayName.SetDefault("LazarStaff");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "深红凝视");
		}
		public override void SetDefaults()
		{
			base.item.damage = 40;
			base.item.magic = true;
			base.item.mana = 20;
			base.item.width = 68;
			base.item.height = 68;
			base.item.useTime = 4;
			base.item.useAnimation = 4;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 9, 0, 0);
			base.item.rare = 7;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("RedLazar");
			base.item.shootSpeed = 20f;
		}
        private int i = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            float shootSpeed = base.item.shootSpeed;
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
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "LazarBattery", 16);
            modRecipe.AddIngredient(113, 1);
            modRecipe.AddIngredient(547, 10);
            modRecipe.AddIngredient(548, 10);
            modRecipe.AddIngredient(549, 10);
            modRecipe.requiredTile[0] = 134;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
	}
}
