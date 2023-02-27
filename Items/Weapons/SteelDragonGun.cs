using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items.Weapons
{
    public class SteelDragonGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "钢铁巨龙炮");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出一团子弹\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 190;
			base.item.width = 78;
			base.item.height = 34;
			base.item.useTime = 40;
			base.item.useAnimation = 40;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 50000;
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("SteelDragonGun");
			base.item.shootSpeed = 13f;
			base.item.useAmmo = 771;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                base.item.useTime = 60;
                base.item.useAnimation = 60;
            }
            else
            {
                base.item.useTime = 55;
                base.item.useAnimation = 55;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("SteelDragonGun"), damage * 2, knockBack, player.whoAmI, 0f, 0f);
                return false;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("SteelDragonGun"), damage * 2, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
	}
}
