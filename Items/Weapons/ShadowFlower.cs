﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class ShadowFlower : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("影之花");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "影之花");
		}
		public override void SetDefaults()
		{
			base.item.damage = 130;
			base.item.magic = true;
			base.item.mana = 15;
			base.item.width = 58;
			base.item.height = 68;
			base.item.useTime = 26;
			base.item.useAnimation = 26;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 2, 0, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("DarkBall");
			base.item.shootSpeed = 3f;
		}
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
            //float shootSpeed = base.item.shootSpeed;
            //Projectile.NewProjectile((float)position.X + speedX * 4, (float)position.Y + speedY * 4, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            //return false;
        //}
	}
}
