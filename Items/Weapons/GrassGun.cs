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
    public class GrassGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "草本手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "泥土和草木做的枪，好用吗？");
		}
		public override void SetDefaults()
		{
			base.item.damage = 6;
			base.item.width = 58;
			base.item.height = 32;
			base.item.useTime = 22;
			base.item.useAnimation = 22;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 2000;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 14;
			base.item.shootSpeed = 10f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, 14, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, 0.0f);
        }
	}
}
