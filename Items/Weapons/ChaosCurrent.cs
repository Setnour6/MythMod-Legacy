using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class ChaosCurrent : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("混乱炸流");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "混乱炸流");
            // base.Tooltip.SetDefault("鼠标周围爆炸出一圈乱流,鼠标和玩家距离越远威力越小");
        }
		public override void SetDefaults()
		{
			base.Item.damage = 11;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 30;
			base.Item.width = 42;
			base.Item.height = 42;
			base.Item.useTime = 36;
			base.Item.useAnimation = 36;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 9, 0, 0);
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("ChaosCurrent").Type;
			base.Item.shootSpeed = 0;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float shootSpeed = base.Item.shootSpeed;
            if((new Vector2((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY) - player.Center).Length() < 200)
            {
                Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY, 0, 0, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY, 0, 0, (int)type, (int)(damage * 200f / (new Vector2((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY) - player.Center).Length()), (float)knockBack, player.whoAmI, 0f, 0f);
            }
            /*player.statLife -= 30;*/
            return false;
        }
        public override void AddRecipes()
		{
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(1256, 1);
            modRecipe.requiredTile[0] = 16;
            modRecipe.Register();
        }
	}
}
