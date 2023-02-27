using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class ThornBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("刺球炸弹");
            base.Tooltip.SetDefault("神话");
		}
		public override void SetDefaults()
		{
            base.Item.damage = 120;
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.crit = 15;
            base.Item.width = 20;
            base.Item.height = 38;
            base.Item.useTime = 21;
            base.Item.useAnimation = 21;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 5, 0, 0);
            base.Item.shoot = base.Mod.Find<ModProjectile>("GreenThornBomb").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 6;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 17f;
        }
		public override void AddRecipes()
        {
        }
        private int l = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (l % 2 == 0)
            {
                type = Mod.Find<ModProjectile>("GreenThornBomb").Type;
            }
            else
            {
                type = Mod.Find<ModProjectile>("PinkThornBomb").Type;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            l++;
            return false;
        }
    }
}
