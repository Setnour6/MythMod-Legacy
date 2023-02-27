using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class BrokenBone : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "断魂裂骨之杖");
            Tooltip.SetDefault("释放出吸食骨髓的鬼虫");
        }
        public override void SetDefaults()
		{
			base.item.damage = 60;
			base.item.magic = true;
			base.item.mana = 3;
			base.item.width = 50;
			base.item.height = 54;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 35f;
			base.item.value = 3000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            item.shoot = mod.ProjectileType("BrokenBone");
            base.item.shootSpeed = 6f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float shootSpeed = base.item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 5, (float)position.Y + speedY * 5, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
