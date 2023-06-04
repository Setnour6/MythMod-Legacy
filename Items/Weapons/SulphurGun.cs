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
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 208;
			base.Item.width = 50;
			base.Item.height = 26;
			base.Item.useTime = 12;
			base.Item.useAnimation = 12;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 30000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("SulfurBullet").Type;
			base.Item.shootSpeed = 14f;
			base.Item.useAmmo = 97;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			if(Main.rand.Next(0,100) < 89)
			{
				Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y - 2, speedX * 2f, speedY * 2f, base.Mod.Find<ModProjectile>("SulfurBullet").Type, (int)((double)damage * 5f), knockBack * 2f, player.whoAmI, 0f, 0f);
			}
			return false;
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Basalt", 12);
            modRecipe.AddIngredient(null, "Sulfur", 72);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26.0f, -5.0f);
        }
	}
}
