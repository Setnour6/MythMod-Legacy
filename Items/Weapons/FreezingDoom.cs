using System;
using Terraria;
using Terraria.DataStructures;
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
			base.Item.damage = 240;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 74;
			base.Item.height = 76;
			base.Item.useTime = 5;
			base.Item.useAnimation = 3;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 5, 0, 0);
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("SnowPiece").Type;
			base.Item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1931, 5);
            modRecipe.AddIngredient(null, "SoulOfFrozen", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
