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
    public class CrystalEagle : ModItem
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "水晶之鹰");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
		public override void SetDefaults()
		{
			base.item.damage = 270;
			base.item.width = 62;
			base.item.height = 36;
			base.item.useTime = 6;
			base.item.useAnimation = 6;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 20000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 14;
			base.item.shootSpeed = 10f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
            if ((int)(Main.time / 5f) % 5 == 0)
            {
                int k = Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-2, 2), speedX * 2f, speedY * 2f, mod.ProjectileType("CrystalBullet"), (int)(damage * 2.5f), knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
	}
}
