using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class ThunderStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Death");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "天雷法杖");
		}
		public override void SetDefaults()
		{
			base.item.damage = 200;
			base.item.magic = true;
			base.item.mana = 25;
			base.item.width = 40;
			base.item.height = 44;
			base.item.useTime = 60;
			base.item.useAnimation = 60;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 1.5f;
			base.item.value = 10000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("Thunderstaff");
			base.item.shootSpeed = 2f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            damage *= 5;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
