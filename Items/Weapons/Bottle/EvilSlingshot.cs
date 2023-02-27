using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
			base.Item.damage = 22;
			base.Item.crit = 6;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 38;
			base.Item.height = 36;
			base.Item.useTime = 22;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = true;
			base.Item.value = Item.sellPrice(0, 0, 10, 0);
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item5;
                 Item.shoot = base.Mod.Find<ModProjectile>("EvilSlingshot").Type;
			base.Item.shootSpeed = 11.5f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
