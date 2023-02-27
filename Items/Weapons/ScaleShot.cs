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
    public class ScaleShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火鳞散弹");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出一团子弹\n 24%不消耗弹药");
		}
		public override void SetDefaults()
		{
			base.item.damage = 100;
			base.item.width = 52;
			base.item.height = 26;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 50000;
			base.item.rare = 14;
			base.item.UseSound = SoundID.Item36;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("火鳞散弹");
			base.item.shootSpeed = 13f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for(int j = 0;j < 5;j++)
			{
			    for(int i = 0;i < 8;i++)
	    		{
					Vector2 v2 = position + new Vector2(speedX, speedY) * 2.1f;
			    	Vector2 v = new Vector2(speedX, speedY).RotatedBy((float)Math.PI * (4 - i) / 50f) * (0.3f + j / 8f) * Main.rand.Next(10,40) / 15f;
		    		Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, base.mod.ProjectileType("火鳞散弹"), damage, knockBack, player.whoAmI, 0f, 0f);
	    		}
			}
			return false;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.Next(0, 100) > 24;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(26f, 13f);
			spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/火鳞散弹Glow"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
	}
}
