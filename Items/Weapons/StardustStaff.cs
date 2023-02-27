using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class StardustStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星光斑");
			base.Tooltip.SetDefault("召唤星尘光标协助作战");
		}
		public override void SetDefaults()
		{
			base.item.damage = 140;
			base.item.mana = 30;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.knockBack = 2.25f;
			base.item.value = 50000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item44;
			base.item.shoot = base.mod.ProjectileType("StarDustMark");
			base.item.autoReuse = true;
			base.item.shootSpeed = 10f;
			base.item.summon = true;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/裂星源Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float shootSpeed = base.item.shootSpeed;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float num = (float)Main.mouseX + Main.screenPosition.X - vector.X;
			float num2 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
			if (player.gravDir == -1f)
			{
				num2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
			}
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if ((float.IsNaN(num) && float.IsNaN(num2)) || (num == 0f && num2 == 0f))
			{
				num = (float)player.direction;
			}
			else
			{
				num3 = shootSpeed / num3;
			}
			num = 0f;
			num2 = 0f;
			vector.X = (float)Main.mouseX + Main.screenPosition.X;
			vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
			Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.mod.ProjectileType("StarDustMark"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
