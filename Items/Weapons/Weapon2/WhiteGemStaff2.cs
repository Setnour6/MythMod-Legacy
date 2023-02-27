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
    public class WhiteGemStaff2 : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("钻石神杖");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "钻石神杖");
        }
        public override void SetDefaults()
        {
            base.item.damage = 600;
			base.item.magic = true;
			base.item.mana = 12;
			base.item.width = 64;
			base.item.height = 64;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 120000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("WhiteGemStaff2");
			base.item.shootSpeed = 9f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + speedX * 10f, position.Y + speedY * 10f, speedX, speedY, type, damage * 4, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(744, 1);
            modRecipe.AddIngredient(1527, 15);
            modRecipe.AddIngredient(mod.ItemType("CrystalSoul"), 1);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
