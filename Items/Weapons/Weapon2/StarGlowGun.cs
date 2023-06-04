using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
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

namespace MythMod.Items.Weapons.Weapon2
{
    public class StarGlowGun : ModItem
	{
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("");
            // base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星辉");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "无主星辉");
        }
		public override void SetDefaults()
		{
			base.Item.damage = 90;
			base.Item.width = 48;
			base.Item.height = 22;
			base.Item.useTime = 11;
			base.Item.useAnimation = 11;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 20000;
			base.Item.rare = 9;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = 14;
			base.Item.shootSpeed = 10f;
			base.Item.useAmmo = 97;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            if(Main.rand.Next(50) == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 v = new Vector2(0, 2).RotatedBy(i * Math.PI / 2.5d);
                    Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX + v.X, speedY + v.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
                }
                for (int i = 0; i < 5; i++)
                {
                    Vector2 v = new Vector2(0, 1).RotatedBy((i + 0.5) * Math.PI / 2.5d);
                    Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX + v.X, speedY + v.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
                }
            }
            else
            {
                if(Main.rand.Next(10) == 1)
                {
                    for(int i = 0; i < 5;i++)
                    {
                        Vector2 v = new Vector2(0, 1).RotatedBy(i * Math.PI / 2.5d);
                        Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX + v.X, speedY + v.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
                    }
                }
                else
                {
                    Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(824, 10);//日盘块
            recipe.AddIngredient(164, 1);//手枪
            recipe.AddIngredient(3337, 1);//闪亮石
            recipe.AddIngredient(75, 10);//落星
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
	}
}
