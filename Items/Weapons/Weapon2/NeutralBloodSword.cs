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
    public class NeutralBloodSword : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("NeutralBloodSword");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "神经刺刀");
        }
        public override void SetDefaults()
        {
            base.item.damage = 46;
			base.item.width = 32;
			base.item.height = 32;
            item.melee = true;
            base.item.useTime = 6;
			base.item.useAnimation = 6;
			base.item.useStyle = 5;
			base.item.knockBack = 0.5f;
			base.item.value = 1200;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = false;
            base.item.shoot = base.mod.ProjectileType("NeutralBloodSword");
			base.item.shootSpeed = 23f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + speedX * 4f, position.Y + speedY * 4f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(6);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
            ModRecipe modRecipe2 = new ModRecipe(base.mod);
            modRecipe2.AddIngredient(null, "CellOfN", 5);
            modRecipe2.AddIngredient(3495);
            modRecipe2.requiredTile[0] = 16;
            modRecipe2.SetResult(this, 1);
            modRecipe2.AddRecipe();
        }
    }
}
