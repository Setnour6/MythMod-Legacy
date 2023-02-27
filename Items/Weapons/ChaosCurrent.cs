using System;
using Terraria;
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
            base.DisplayName.SetDefault("混乱炸流");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "混乱炸流");
            base.Tooltip.SetDefault("鼠标周围爆炸出一圈乱流,鼠标和玩家距离越远威力越小");
        }
		public override void SetDefaults()
		{
			base.item.damage = 11;
			base.item.magic = true;
			base.item.mana = 30;
			base.item.width = 42;
			base.item.height = 42;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 9, 0, 0);
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("ChaosCurrent");
			base.item.shootSpeed = 0;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = base.item.shootSpeed;
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
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(1256, 1);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
	}
}
