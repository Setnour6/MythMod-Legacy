using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class SwordEoc : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·克苏鲁之眼");
            base.Tooltip.SetDefault("你的实力已经碾压克苏鲁之眼\n这把剑是你的见证");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 20;
            item.rare = 2;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 9;
            item.value = 10000;
            item.scale = 1f;
        }
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            float num2 = 25f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
                float num3 = (float)Main.mouseX - Main.screenPosition.X - vector.X;
                float num4 = (float)Main.mouseY - Main.screenPosition.Y - vector.Y;
            if (player.gravDir == -1f)
            {
                num4 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
            }
            float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
            if ((float.IsNaN(num3) && float.IsNaN(num4)) || (num3 == 0f && num4 == 0f))
            {
                num3 = (float)player.direction;
                num4 = 0f;
                num5 = num2;
            }
            else
            {
                num5 = num2 / num5;
            }
            num3 *= num5;
            num4 *= num5;
            int num6 = 1;
            for (int i = 0; i < num6; i++)
            {
                vector = new Vector2(player.position.X + (float)player.width * 0.5f + (float)Main.rand.Next(201) * -(float)player.direction + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
                vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-800, 801);
                vector.Y -= (float)(100 * i);
                num3 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                num4 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                if (num4 < 0f)
                {
                    num4 *= -1f;
                }
                if (num4 < 20f)
                {
                    num4 = 20f;
                }
                num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
                num5 = num2 / num5;
                num3 *= num5;
                num4 *= num5;
                float num7 = num3;
                float num8 = num4 + (float)Main.rand.Next(-180, 181) * 0.02f;
                Projectile.NewProjectile(vector.X, vector.Y, num7, num8, base.mod.ProjectileType("EOCPhatom"), damage, knockback, player.whoAmI, 0f, (float)Main.rand.Next(10));
            }
        }        
    }
}
