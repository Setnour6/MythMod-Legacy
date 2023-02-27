using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class PtCoinGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铂金币发射器");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "不需要消耗铂金币，需要子弹");
		}
		public override void SetDefaults()
		{
			base.item.damage = 250;
            base.item.crit = 12;
            base.item.width = 64;
			base.item.height = 32;
			base.item.useTime = 9;
			base.item.useAnimation = 9;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 99999;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("PtBullet");
			base.item.shootSpeed = 14f;
			base.item.useAmmo = 97;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX, speedY, base.mod.ProjectileType("PtBullet"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
    }
}
