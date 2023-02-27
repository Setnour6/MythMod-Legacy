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
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "黯莲");
            Tooltip.AddTranslation(GameCulture.Chinese, "抑郁之花,美丽的外表下藏着深渊");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 18;
			base.item.magic = true;
			base.item.mana = 22;
			base.item.width = 64;
			base.item.height = 64;
			base.item.useTime = 15;
			base.item.useAnimation = 15;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 1200;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("DepressLotus");
			base.item.shootSpeed = 14f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X + speedX * 3f, position.Y + speedY * 3f, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "CurseflameScale", 5);
            modRecipe.AddIngredient(64);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
