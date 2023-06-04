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
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "钢铁巨龙炮");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出一团子弹\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 190;
			base.Item.width = 78;
			base.Item.height = 34;
			base.Item.useTime = 40;
			base.Item.useAnimation = 40;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 50000;
			base.Item.rare = 5;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("SteelDragonGun").Type;
			base.Item.shootSpeed = 13f;
			base.Item.useAmmo = 771;
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
                base.Item.useTime = 60;
                base.Item.useAnimation = 60;
            }
            else
            {
                base.Item.useTime = 55;
                base.Item.useAnimation = 55;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.Mod.Find<ModProjectile>("SteelDragonGun").Type, damage * 2, knockBack, player.whoAmI, 0f, 0f);
                return false;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.Mod.Find<ModProjectile>("SteelDragonGun").Type, damage * 2, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
	}
}
