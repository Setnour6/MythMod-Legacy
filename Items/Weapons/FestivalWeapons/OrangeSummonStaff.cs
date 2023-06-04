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

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class OrangeSummonStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蜜桔召唤杖");
			// base.Tooltip.SetDefault("召唤一个根系精灵协助作战");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 270;
			base.Item.mana = 46;
			base.Item.width = 58;
			base.Item.height = 64;
			base.Item.useTime = 36;
			base.Item.useAnimation = 36;
			base.Item.useStyle = 1;
			base.Item.noMelee = true;
			base.Item.knockBack = 2.25f;
			base.Item.value = 100000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item44;
			base.Item.shoot = base.Mod.Find<ModProjectile>("TangerineZh").Type;
			base.Item.autoReuse = true;
			base.Item.shootSpeed = 10f;
			base.Item.DamageType = DamageClass.Summon;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float shootSpeed = base.Item.shootSpeed;
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
			Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.Mod.Find<ModProjectile>("TangerineZh").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            for (int i = 0; i < 25; i++)
            {
                Vector2 v = new Vector2(0,5).RotatedBy(i / 12.5 * Math.PI);
                int num8 = Dust.NewDust(new Vector2(vector.X, vector.Y), 0, 0, 174, v.X, v.Y, 0, default(Color), 2f);
            }
            return false;
		}
	}
}
