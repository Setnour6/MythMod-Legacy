using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class ThunderStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Death");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "天雷法杖");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 200;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 25;
			base.Item.width = 40;
			base.Item.height = 44;
			base.Item.useTime = 60;
			base.Item.useAnimation = 60;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 10000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("Thunderstaff").Type;
			base.Item.shootSpeed = 2f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            damage *= 5;
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
