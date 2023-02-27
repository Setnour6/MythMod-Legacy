﻿using Terraria.ID;
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
            Item.DamageType = DamageClass.Ranged;
            Item.width = 62;
            Item.height = 78;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.damage = 26;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 3000;
            Item.scale = 1f;
            Item.rare = 3;
            Item.shoot = 1;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 7f;
            Item.reuseDelay = 14;
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "BoneLiquid", 6); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenTooth", 14); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
            float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
            if (Main.rand.Next(0, 100) < 85)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, Mod.Find<ModProjectile>("TuskArrow").Type, damage * 2, knockBack * 2f, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  