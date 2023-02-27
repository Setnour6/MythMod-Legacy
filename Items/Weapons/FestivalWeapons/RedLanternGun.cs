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
    public class RedLanternGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "霓虹散射");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 200;
            base.Item.crit = 12;
            base.Item.width = 98;
			base.Item.height = 42;
			base.Item.useTime = 9;
			base.Item.useAnimation = 9;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 99999;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("LanternBoomF").Type;
			base.Item.shootSpeed = 14f;
			base.Item.useAmmo = 771;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(position.X + speedX * 3, position.Y + Main.rand.Next(-1, 2) * 6f + speedY * 3 - 8, speedX, speedY, base.Mod.Find<ModProjectile>("LanternBoomF").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            for(int u = 0;u < 5;u++)
            {
                Vector2 v = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.6f, 0.6f)) * Main.rand.NextFloat(0.4f, 0.9f);
                Projectile.NewProjectile(position.X + speedX * 3, position.Y + Main.rand.Next(-1, 2) * 6f + speedY * 3 - 8, v.X, v.Y, base.Mod.Find<ModProjectile>("LanternBoomLiF").Type, damage / 3, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-38.0f, -8.0f);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
