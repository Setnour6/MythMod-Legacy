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
            base.item.damage = 26;
			base.item.magic = true;
			base.item.mana = 6;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 24;
			base.item.useAnimation = 24;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = 2000;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.autoReuse = true;
			base.item.shoot = 38;
			base.item.shootSpeed = 6f;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
