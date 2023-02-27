using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Weapons
{
    public class TuskBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "獠牙巨弓");
        }
        public override void SetDefaults()
        {
            item.ranged = true;
            item.width = 62;
            item.height = 78;
            item.useTime = 11;
            item.useAnimation = 11;
            item.damage = 26;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 4;
            item.value = 3000;
            item.scale = 1f;
            item.rare = 3;
            item.shoot = 1;
            item.useStyle = 5;
            item.knockBack = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shootSpeed = 7f;
            item.reuseDelay = 14;
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 6); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenTooth", 14); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1); //����һ������
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
            float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
            if (Main.rand.Next(0, 100) < 85)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, mod.ProjectileType("TuskArrow"), damage * 2, knockBack * 2f, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  