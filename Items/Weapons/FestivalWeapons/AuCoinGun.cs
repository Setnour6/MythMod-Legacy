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
    public class AuCoinGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "金币发射器");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "不需要消耗金币，需要子弹");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 150;
            base.Item.crit = 12;
            base.Item.width = 64;
			base.Item.height = 32;
			base.Item.useTime = 9;
			base.Item.useAnimation = 9;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 99999;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("AuCoinBullet").Type;
			base.Item.shootSpeed = 14f;
			base.Item.useAmmo = 97;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX, speedY, base.Mod.Find<ModProjectile>("AuCoinBullet").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
    }
}
