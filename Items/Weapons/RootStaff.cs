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
	// Token: 0x020003E0 RID: 992
    public class RootStaff : ModItem
	{
		// Token: 0x06001301 RID: 4865 RVA: 0x0008B390 File Offset: 0x00089590
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("根系法杖");
			base.Tooltip.SetDefault("召唤一个根系精灵协助作战");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 3;
			base.item.mana = 6;
			base.item.width = 58;
			base.item.height = 64;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.knockBack = 2.25f;
			base.item.value = 55000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item44;
			base.item.shoot = base.mod.ProjectileType("根系精灵");
			base.item.autoReuse = true;
			base.item.shootSpeed = 10f;
			base.item.summon = true;
		}
		// Token: 0x06001304 RID: 4868 RVA: 0x0008B534 File Offset: 0x00089734
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
			Projectile.NewProjectile(vector.X, vector.Y, num, num2, base.mod.ProjectileType("根系精灵"), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
