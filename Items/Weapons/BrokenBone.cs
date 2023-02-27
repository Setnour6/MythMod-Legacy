using System;
using Terraria;
using Terraria.DataStructures;
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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "断魂裂骨之杖");
            Tooltip.SetDefault("释放出吸食骨髓的鬼虫");
        }
        public override void SetDefaults()
		{
			base.Item.damage = 60;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 3;
			base.Item.width = 50;
			base.Item.height = 54;
			base.Item.useTime = 12;
			base.Item.useAnimation = 12;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 35f;
			base.Item.value = 3000;
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("BrokenBone").Type;
            base.Item.shootSpeed = 6f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float shootSpeed = base.Item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 5, (float)position.Y + speedY * 5, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
