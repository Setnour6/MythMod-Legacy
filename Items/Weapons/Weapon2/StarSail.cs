using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class StarSail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("StarSail");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星际漫游");
            Tooltip.SetDefault("StarSail");
            Tooltip.AddTranslation(GameCulture.Chinese, "星河欲转千帆舞");
        }
        public override void SetDefaults()
        {
            item.damage = 200;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 60;
            item.rare = 10;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("StarSail");
            item.shootSpeed = 12f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage * 2d), knockBack * 10, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(422, 20);
            modRecipe.AddIngredient(502, 20);
            modRecipe.AddIngredient(520, 20);
            modRecipe.AddIngredient(501, 20);
            modRecipe.AddIngredient(75, 20);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
