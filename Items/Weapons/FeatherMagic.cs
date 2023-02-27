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
    public class FeatherMagic : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "羽箭");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public override void SetDefaults()
        {
            base.Item.damage = 26;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 6;
			base.Item.width = 28;
			base.Item.height = 30;
			base.Item.useTime = 24;
			base.Item.useAnimation = 24;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 6f;
			base.Item.value = 2000;
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.autoReuse = true;
			base.Item.shoot = 38;
			base.Item.shootSpeed = 6f;
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Vector2 v = new Vector2(speedX, speedY);
            for (int k = 0; k < 6; k++)
            {
                Vector2 v2 = v.RotatedBy(Main.rand.NextFloat(-0.6f,0.6f)) * Main.rand.NextFloat(0.9f, 1.1f);
                int u = Projectile.NewProjectile(position.X, position.Y, v2.X, v2.Y, type, damage, knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[u].hostile = false;
                Main.projectile[u].friendly = true;
            }
			return false;
        }
	}
}
