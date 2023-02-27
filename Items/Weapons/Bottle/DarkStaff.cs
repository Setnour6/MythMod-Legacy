using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.Bottle
{
    public class DarkStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "影焰法杖");
        }
        public override void SetDefaults()
		{
			base.item.damage = 48;
			base.item.magic = true;
			base.item.mana = 12;
			base.item.width = 46;
			base.item.height = 46;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 4f;
			base.item.value = 6000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            item.shoot = mod.ProjectileType("DarkStaff");
            base.item.shootSpeed = 6f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = base.item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 5, (float)position.Y + speedY * 5, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
