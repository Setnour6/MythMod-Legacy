using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.Bottle
{
    public class DarkStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "影焰法杖");
        }
        public override void SetDefaults()
		{
			base.Item.damage = 48;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 12;
			base.Item.width = 46;
			base.Item.height = 46;
			base.Item.useTime = 12;
			base.Item.useAnimation = 12;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 4f;
			base.Item.value = 6000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("DarkStaff").Type;
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
