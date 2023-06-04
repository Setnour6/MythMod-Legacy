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
    public class OrangeGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "香橙喜糖手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 152;
            base.Item.crit = 12;
            base.Item.width = 64;
			base.Item.height = 32;
			base.Item.useTime = 17;
			base.Item.useAnimation = 17;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
            base.Item.DamageType = DamageClass.Ranged;
            base.Item.knockBack = 1f;
			base.Item.value = 10000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = 14;
			base.Item.shootSpeed = 14f;
            base.Item.useAmmo = 97;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2?(new Vector2(-6f, 0f));
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(Main.rand.Next(3) == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.Mod.Find<ModProjectile>("OrangeGun").Type, (int)((double)damage * 2f), knockBack * 5, player.whoAmI, 0, 0f);
            }
            return true;
        }
    }
}