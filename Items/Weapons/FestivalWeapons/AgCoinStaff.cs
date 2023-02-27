using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class AgCoinStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("银元宝法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "银元宝法杖");
        }
		public override void SetDefaults()
		{
			base.item.damage = 116;
			base.item.magic = true;
			base.item.mana = 9;
			base.item.width = 66;
			base.item.height = 66;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 0, 99, 99);
			base.item.rare = 4;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("AgYuanbao");
			base.item.shootSpeed = 13f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)position.Y - 1000f, 0, 4, base.mod.ProjectileType("AgYuanbao"), (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        // Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
        public override void AddRecipes()
        {
        }
    }
}
