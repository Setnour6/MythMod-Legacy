using Terraria.DataStructures;
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
            // DisplayName.SetDefault("StarSail");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星际漫游");
            // Tooltip.SetDefault("StarSail");
            Tooltip.AddTranslation(GameCulture.Chinese, "星河欲转千帆舞");
        }
        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 60;
            Item.rare = 10;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.UseSound = SoundID.Item1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("StarSail").Type;
            Item.shootSpeed = 12f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage * 2d), knockBack * 10, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(422, 20);
            modRecipe.AddIngredient(502, 20);
            modRecipe.AddIngredient(520, 20);
            modRecipe.AddIngredient(501, 20);
            modRecipe.AddIngredient(75, 20);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
