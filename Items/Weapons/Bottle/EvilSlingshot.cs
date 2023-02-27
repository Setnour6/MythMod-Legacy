using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.Bottle
{
    public class EvilSlingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("妖火弹弓");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.damage = 22;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 38;
			base.item.height = 36;
			base.item.useTime = 22;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = true;
			base.item.value = Item.sellPrice(0, 0, 10, 0);
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = base.mod.ProjectileType("EvilSlingshot");
			base.item.shootSpeed = 11.5f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v0 = new Vector2(speedX, speedY);
            for (int i = 0; i < 5; i++)
            {
                Vector2 v = v0.RotatedBy((i - 2f) / 20f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, type, damage, 0f, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}
