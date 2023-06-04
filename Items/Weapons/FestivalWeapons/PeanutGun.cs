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
    public class PeanutGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "花生汤圆蓄能炮");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "左键放出爆炸汤圆,右键发出花生酱喷流");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 152;
            base.Item.crit = 12;
            base.Item.width = 64;
			base.Item.height = 32;
			base.Item.useTime = 9;
			base.Item.useAnimation = 9;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
            base.Item.DamageType = DamageClass.Magic;
            base.Item.mana = 8;
            base.Item.knockBack = 1f;
			base.Item.value = 99999;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("Peanut").Type;
			base.Item.shootSpeed = 14f;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2?(new Vector2(-16f, 0f));
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                base.Item.useTime = 2;
                base.Item.useAnimation = 6;
                base.Item.mana = 12;
            }
            else
            {
                base.Item.useTime = 25;
                base.Item.useAnimation = 25;
                base.Item.autoReuse = false;
                base.Item.mana = 40;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                float num = speedX;
                float num2 = speedY;
                Projectile.NewProjectile(position.X, position.Y, num * 0.15f, num2 * 0.15f, base.Mod.Find<ModProjectile>("Peanut").Type, (int)(damage * 0.4f), knockBack * 0.5f, player.whoAmI, 0f, 0f);
                return false;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.Mod.Find<ModProjectile>("PeanutTangyuan").Type, (int)((double)damage * 16f), knockBack * 5, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}