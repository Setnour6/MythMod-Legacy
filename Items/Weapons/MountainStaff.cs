﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class MountainStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("埋山法杖");
			base.Tooltip.SetDefault("从天而降无数土块\n 神话");
		}
		public override void SetDefaults()
		{
			base.item.damage = 38;
            base.item.magic = true;
            base.item.mana = 16;
            base.item.width = 64;
			base.item.height = 76;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6;
			base.item.value = 10000;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("DirtBall");
            item.shootSpeed = 9f;
            base.item.autoReuse = false;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            for (int i = 0; i < 4f; i++)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                int u = Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, mod.ProjectileType("DirtBall"), (int)damage, (float)knockBack, player.whoAmI, 2, 0f);
                Main.projectile[u].hostile = false;
                Main.projectile[u].friendly = true;
            }
            return false;
		}
	}
}