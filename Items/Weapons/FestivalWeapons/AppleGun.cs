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
    public class AppleGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "苹果喜糖手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.item.damage = 152;
            base.item.crit = 12;
            base.item.width = 64;
			base.item.height = 32;
			base.item.useTime = 17;
			base.item.useAnimation = 17;
			base.item.useStyle = 5;
			base.item.noMelee = true;
            base.item.ranged = true;
            base.item.knockBack = 1f;
			base.item.value = 10000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 14;
			base.item.shootSpeed = 14f;
            base.item.useAmmo = 97;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2?(new Vector2(-6f, 0f));
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(Main.rand.Next(3) == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("AppleGun"), (int)((double)damage * 2f), knockBack * 5, player.whoAmI, 0, 0f);
            }
            return true;
        }
    }
}