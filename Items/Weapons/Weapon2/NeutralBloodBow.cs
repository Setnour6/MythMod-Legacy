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
            Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "乙酰胆碱弓");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 30;
            item.height = 70;
            item.useTime = 14;
            item.useAnimation = 14;
            item.damage = 28;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 3000;
            item.scale = 1f;
            item.rare = 3;
            item.useStyle = 5;
            item.knockBack = 1.0f;
            item.shoot = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 0.08f;
            item.reuseDelay = 4;
        }
        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }*/
        private int p = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v = new Vector2(speedX, speedY) * 0.5f;
            Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, mod.ProjectileType("NeutralArrow"), (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "CellOfN", 5);
            modRecipe.AddIngredient(796);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
  