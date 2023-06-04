using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.Weapons.Weapon2
{
    public class NeutralBloodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "乙酰胆碱弓");
        }
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 30;
            Item.height = 70;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.damage = 28;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 3000;
            Item.scale = 1f;
            Item.rare = 3;
            Item.useStyle = 5;
            Item.knockBack = 1.0f;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 0.08f;
            Item.reuseDelay = 4;
        }
        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }*/
        private int p = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY) * 0.5f;
            Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, Mod.Find<ModProjectile>("NeutralArrow").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(796);
            modRecipe.requiredTile[0] = 16;
            modRecipe.Register();
        }
    }
}
  