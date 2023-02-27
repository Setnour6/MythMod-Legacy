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

namespace MythMod.Items.Weapons
{
    public class IcyAnimal : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰封遗骸");
			base.Tooltip.SetDefault("召唤一个冰晶雪兽协助作战");
        }
        public override void SetDefaults()
        {
            base.item.damage = 36;
			base.item.mana = 15;
			base.item.width = 58;
			base.item.height = 64;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.knockBack = 2.25f;
			base.item.value = 55000;
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item44;
			base.item.shoot = base.mod.ProjectileType("IcyAnimal");
			base.item.autoReuse = true;
			base.item.shootSpeed = 10f;
			base.item.summon = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float shootSpeed = base.item.shootSpeed;
            player.AddBuff(base.mod.BuffType("IcyAnimal"), 36000000, true);
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float num = (float)Main.mouseX + Main.screenPosition.X - vector.X;
			float num2 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
			if (player.gravDir == -1f)
			{
				num2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
			}
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if ((float.IsNaN(num) && float.IsNaN(num2)) || (num == 0f && num2 == 0f))
			{
				num = (float)player.direction;
			}
			else
			{
				num3 = shootSpeed / num3;
			}
			num = 0f;
			num2 = 0f;
			vector.X = (float)Main.mouseX + Main.screenPosition.X;
			vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
			Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.mod.ProjectileType("IcyAnimal"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(2161, 1);
            modRecipe.AddIngredient(521, 12);
            modRecipe.requiredTile[0] = 134;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
