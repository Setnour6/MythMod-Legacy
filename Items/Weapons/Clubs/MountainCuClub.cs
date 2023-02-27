﻿using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Clubs
{
    public class MountainCuClub : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("山铜棍棒");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "快速旋转挥舞");
        }
        public override void SetDefaults()
        {
            Item.damage = 62;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 4;
            Item.rare = 3;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 4;
            Item.useStyle = 1;
            Item.knockBack = 11f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 0;
            Item.value = 3500;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("MountainCuClub").Type;
            Item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
            if (!Main.mouseLeft)
            {
                St = false;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(!St && Main.mouseLeft)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(1191, 18);
            recipe.requiredTile[0] = 18;
            recipe.Register();
        }
    }
}
