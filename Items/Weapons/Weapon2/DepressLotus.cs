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
    public class DepressLotus : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("DepressLotus");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "黯莲");
            Tooltip.AddTranslation(GameCulture.Chinese, "抑郁之花,美丽的外表下藏着深渊");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 18;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 22;
			base.Item.width = 64;
			base.Item.height = 64;
			base.Item.useTime = 15;
			base.Item.useAnimation = 15;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 1200;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("DepressLotus").Type;
			base.Item.shootSpeed = 14f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X + speedX * 3f, position.Y + speedY * 3f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "CurseflameScale", 5);
            modRecipe.AddIngredient(64);
            modRecipe.requiredTile[0] = 16;
            modRecipe.Register();
        }
    }
}
