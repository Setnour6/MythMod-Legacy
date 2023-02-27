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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "金乌");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 90;
            base.Item.mana = 17;
            base.Item.width = 46;
            base.Item.height = 46;
            base.Item.useTime = 36;
            base.Item.useAnimation = 36;
            base.Item.useStyle = 1;
            base.Item.noMelee = true;
            base.Item.knockBack = 2.25f;
            base.Item.value = 55000;
            base.Item.rare = 7;
            base.Item.UseSound = SoundID.Item44;
            base.Item.shoot = base.Mod.Find<ModProjectile>("GoldBird").Type;
            base.Item.autoReuse = true;
            base.Item.shootSpeed = 10f;
            base.Item.DamageType = DamageClass.Summon;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Mod.Find<ModBuff>("GoldBird").Type, 3600, true);
            float shootSpeed = base.Item.shootSpeed;
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
            Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.Mod.Find<ModProjectile>("GoldBird").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(1518, 3);//火羽
            recipe.AddIngredient(Mod.Find<ModItem>("GoldBirdFeather").Type, 3);//手枪
            recipe.AddIngredient(Mod.Find<ModItem>("GoldFeather").Type, 3);//闪亮石
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
