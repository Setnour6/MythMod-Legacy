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
            item.glowMask = GetGlowMask;
            base.item.damage = 120;
			base.item.magic = true;
			base.item.mana = 15;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 9;
			base.item.useAnimation = 9;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = 10000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item14;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("THUNDER");
			base.item.shootSpeed = 4f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1508, 20);
            modRecipe.AddIngredient(531, 1);
            modRecipe.AddIngredient(null, "MysteriesPearl", 1);
            modRecipe.AddIngredient(null, "LazarBattery", 10);
            modRecipe.requiredTile[0] = 125;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
