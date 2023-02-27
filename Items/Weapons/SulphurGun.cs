using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
namespace MythMod.Items.Weapons
{
    public class SulphurGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.item.damage = 208;
			base.item.width = 50;
			base.item.height = 26;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 30000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("SulfurBullet");
			base.item.shootSpeed = 14f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			if(Main.rand.Next(0,100) < 89)
			{
				Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y - 2, speedX * 2f, speedY * 2f, base.mod.ProjectileType("SulfurBullet"), (int)((double)damage * 5f), knockBack * 2f, player.whoAmI, 0f, 0f);
			}
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 12);
            modRecipe.AddIngredient(null, "Sulfur", 72);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26.0f, -5.0f);
        }
	}
}
