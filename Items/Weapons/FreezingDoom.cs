using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class FreezingDoom : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("末日暴雪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "末日暴雪");
		}

		public override void SetDefaults()
		{
			base.item.damage = 240;
			base.item.magic = true;
			base.item.mana = 12;
			base.item.width = 74;
			base.item.height = 76;
			base.item.useTime = 5;
			base.item.useAnimation = 3;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 5, 0, 0);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("SnowPiece");
			base.item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 4f; i++)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, 337, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
                if (Main.rand.Next(25) == 0)
                {
                    Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, (int)type, (int)damage * 10, (float)knockBack, player.whoAmI, 0f, 0f);
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1931, 5);
            modRecipe.AddIngredient(null, "SoulOfFrozen", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
