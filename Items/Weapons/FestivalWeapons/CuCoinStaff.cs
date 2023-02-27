﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.FestivalWeapons
{
	// Token: 0x020005C2 RID: 1474
    public class CuCoinStaff : ModItem
	{
		// Token: 0x060019F2 RID: 6642 RVA: 0x00008ED2 File Offset: 0x000070D2
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铜元宝法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铜元宝法杖");
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public override void SetDefaults()
		{
			base.item.damage = 40;
			base.item.magic = true;
			base.item.mana = 9;
			base.item.width = 66;
			base.item.height = 66;
			base.item.useTime = 24;
			base.item.useAnimation = 24;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 0, 0, 99);
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("CuYuanbao");
			base.item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)position.Y - 1200f, 0, 0, base.mod.ProjectileType("CuYuanbao"), (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        // Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
        public override void AddRecipes()
        {
        }
    }
}
