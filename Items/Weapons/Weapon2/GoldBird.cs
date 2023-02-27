using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MythMod.Items.Weapons.Weapon2
{
    public class GoldBird : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("金乌");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "金乌");
        }
        public override void SetDefaults()
        {
            base.item.damage = 90;
            base.item.mana = 17;
            base.item.width = 46;
            base.item.height = 46;
            base.item.useTime = 36;
            base.item.useAnimation = 36;
            base.item.useStyle = 1;
            base.item.noMelee = true;
            base.item.knockBack = 2.25f;
            base.item.value = 55000;
            base.item.rare = 7;
            base.item.UseSound = SoundID.Item44;
            base.item.shoot = base.mod.ProjectileType("GoldBird");
            base.item.autoReuse = true;
            base.item.shootSpeed = 10f;
            base.item.summon = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(mod.BuffType("GoldBird"), 3600, true);
            float shootSpeed = base.item.shootSpeed;
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
            Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.mod.ProjectileType("GoldBird"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1518, 3);//火羽
            recipe.AddIngredient(mod.ItemType("GoldBirdFeather"), 3);//手枪
            recipe.AddIngredient(mod.ItemType("GoldFeather"), 3);//闪亮石
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
    }
}
