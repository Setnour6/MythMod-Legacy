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
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
namespace MythMod.Items.Weapons
{
	// Token: 0x020003B0 RID: 944
    public class PhosphorescenceGun : ModItem
	{
		// Token: 0x06001224 RID: 4644 RVA: 0x00084DFC File Offset: 0x00082FFC
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "磷光手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "在腐化的深渊中发出幽光");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "EvilScaleDust", 5); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenWingOfMoth", 15); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 22;
			base.Item.width = 66;
			base.Item.height = 48;
			base.Item.useTime = 16;
			base.Item.useAnimation = 16;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 3000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = 83;
			base.Item.shootSpeed = 10f;
			base.Item.useAmmo = 97;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			if(Main.rand.Next(0,100) < 50)
			{
				Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
			}
			else
			{
				int i = Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, 89, (int)((double)damage), knockBack * 2f, player.whoAmI, 0f, 0f);
                Main.projectile[i].friendly = true;
                Main.projectile[i].hostile = false;
            }
            if(Main.rand.Next(10) == 1)
            {
                int i = Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, 88, (int)((double)damage * 2.5f), knockBack * 2f, player.whoAmI, 0f, 0f);
                Main.projectile[i].friendly = true;
                Main.projectile[i].hostile = false;
            }
			return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26.0f, -5.0f);
        }
	}
}
