using System;
using Microsoft.Xna.Framework;
using Terraria;
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
            base.item.damage = 120;
            base.item.thrown = true;
            base.item.crit = 15;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 21;
            base.item.useAnimation = 21;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 5, 0, 0);
            base.item.shoot = base.mod.ProjectileType("GreenThornBomb");
            base.item.noUseGraphic = true;
            base.item.rare = 6;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 17f;
        }
		public override void AddRecipes()
        {
        }
        private int l = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (l % 2 == 0)
            {
                type = mod.ProjectileType("GreenThornBomb");
            }
            else
            {
                type = mod.ProjectileType("PinkThornBomb");
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            l++;
            return false;
        }
    }
}
