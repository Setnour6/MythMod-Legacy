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
            base.DisplayName.SetDefault("");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星辉");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "无主星辉");
        }
		public override void SetDefaults()
		{
			base.item.damage = 90;
			base.item.width = 48;
			base.item.height = 22;
			base.item.useTime = 11;
			base.item.useAnimation = 11;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 20000;
			base.item.rare = 9;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 14;
			base.item.shootSpeed = 10f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(824, 10);//日盘块
            recipe.AddIngredient(164, 1);//手枪
            recipe.AddIngredient(3337, 1);//闪亮石
            recipe.AddIngredient(75, 10);//落星
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
	}
}
