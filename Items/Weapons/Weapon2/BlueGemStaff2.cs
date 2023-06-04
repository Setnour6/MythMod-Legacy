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
    public class BlueGemStaff2 : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蓝宝石神杖");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "蓝宝石神杖");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 600;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 64;
			base.Item.height = 64;
			base.Item.useTime = 15;
			base.Item.useAnimation = 15;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 120000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("BlueGemStaff2").Type;
			base.Item.shootSpeed = 9f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X + speedX * 10f, position.Y + speedY * 10f, speedX, speedY, type, damage * 4, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(741, 1);
            modRecipe.AddIngredient(1524, 15);
            modRecipe.AddIngredient(Mod.Find<ModItem>("CrystalSoul").Type, 15);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
