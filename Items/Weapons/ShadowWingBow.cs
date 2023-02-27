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
    public class ShadowWingBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            base.DisplayName.SetDefault("影翼巨弓");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 46;
            Item.height = 82;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.damage = 29;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 3000;
            Item.scale = 1f;
            Item.rare = 3;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shootSpeed = 7f;
            Item.reuseDelay = 14;
            Item.glowMask = GetGlowMask;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "EvilScaleDust", 4); //��Ҫһ������
            recipe.AddIngredient(null, "BrokenWingOfMoth", 16); //��Ҫһ������
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        // Token: 0x06000D6F RID: 3439 RVA: 0x0006A288 File Offset: 0x00068488
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY);
            int num = Main.rand.Next(2, 6);
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            for(int i = 0; i < num; i++)
            {
                v = v.RotatedBy(Main.rand.Next(-2000, 2000) / 4000f) * Main.rand.Next(1000, 1600) / 2000f;
                Projectile.NewProjectile(position.X, position.Y, v.X, v.Y, Mod.Find<ModProjectile>("魔光弹2").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
  