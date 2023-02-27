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
    public class ShinyFire : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火树银花");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "让它在夜空中绽放吧!\n威力远远大于普通烟花");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 5000;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 100;
			base.Item.width = 28;
			base.Item.height = 30;
			base.Item.useTime = 48;
			base.Item.useAnimation = 48;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 6f;
			base.Item.value = 100000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item14;
			base.Item.autoReuse = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("焰火").Type;
			base.Item.shootSpeed = 2.7f;
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float num = 0.7854f;
			double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)(num / 2f);
			double num3 = (double)(num / 8f);
            for (int i = 0; i < 4; i++)
            {
                double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
            }
            int num5 = 0;
			for (int j = 0; j < 30; j++)
            {
			int num7 = Main.rand.Next(0, 100000);
			int num8 = Main.rand.Next(0, (int)num7) / 14400;
            int num6 = Dust.NewDust(position, 2, 2, 174, speedX * (float)num8, speedY * (float)num8, 0, Color.Orange, 1.6f);
            Main.dust[num6].noGravity = false;
            Main.dust[num6].scale *=  0.8f;
            Main.dust[num6].alpha = 200;
			}
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.3f + num5, speedY * 1.3f + num5, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
        }
	}
}
