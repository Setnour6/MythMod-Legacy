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

namespace MythMod.Items.Weapons
{
    public class THUNDER : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "雷鸣");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 120;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 15;
			base.Item.width = 28;
			base.Item.height = 30;
			base.Item.useTime = 9;
			base.Item.useAnimation = 9;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 6f;
			base.Item.value = 10000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item14;
			base.Item.autoReuse = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("THUNDER").Type;
			base.Item.shootSpeed = 4f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY);
            int i = Main.rand.Next(1, 3);
            for (int k = 0; k < i; k++)
            {
                Vector2 v2 = v.RotatedBy(Main.rand.NextFloat(-0.16f, 0.16f)) * Main.rand.NextFloat(0.9f, 1.1f);
                int u = Projectile.NewProjectile(position.X, position.Y, v2.X, v2.Y, type, damage, knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[u].hostile = false;
                Main.projectile[u].friendly = true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1508, 20);
            modRecipe.AddIngredient(531, 1);
            modRecipe.AddIngredient(null, "MysteriesPearl", 1);
            modRecipe.AddIngredient(null, "LazarBattery", 10);
            modRecipe.requiredTile[0] = 125;
            modRecipe.Register();
        }
    }
}
