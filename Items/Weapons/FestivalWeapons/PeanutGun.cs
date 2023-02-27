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
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "花生汤圆蓄能炮");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "左键放出爆炸汤圆,右键发出花生酱喷流");
		}
		public override void SetDefaults()
		{
			base.item.damage = 152;
            base.item.crit = 12;
            base.item.width = 64;
			base.item.height = 32;
			base.item.useTime = 9;
			base.item.useAnimation = 9;
			base.item.useStyle = 5;
			base.item.noMelee = true;
            base.item.magic = true;
            base.item.mana = 8;
            base.item.knockBack = 1f;
			base.item.value = 99999;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("Peanut");
			base.item.shootSpeed = 14f;
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
                base.item.useTime = 2;
                base.item.useAnimation = 6;
                base.item.mana = 12;
            }
            else
            {
                base.item.useTime = 25;
                base.item.useAnimation = 25;
                base.item.autoReuse = false;
                base.item.mana = 40;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                float num = speedX;
                float num2 = speedY;
                Projectile.NewProjectile(position.X, position.Y, num * 0.15f, num2 * 0.15f, base.mod.ProjectileType("Peanut"), (int)(damage * 0.4f), knockBack * 0.5f, player.whoAmI, 0f, 0f);
                return false;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("PeanutTangyuan"), (int)((double)damage * 16f), knockBack * 5, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}