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
            item.glowMask = GetGlowMask;
            base.item.damage = 200;
            base.item.crit = 12;
            base.item.width = 98;
			base.item.height = 42;
			base.item.useTime = 9;
			base.item.useAnimation = 9;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 99999;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("LanternBoomF");
			base.item.shootSpeed = 14f;
			base.item.useAmmo = 771;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Projectile.NewProjectile(position.X + speedX * 3, position.Y + Main.rand.Next(-1, 2) * 6f + speedY * 3 - 8, speedX, speedY, base.mod.ProjectileType("LanternBoomF"), damage, knockBack, player.whoAmI, 0f, 0f);
            for(int u = 0;u < 5;u++)
            {
                Vector2 v = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.6f, 0.6f)) * Main.rand.NextFloat(0.4f, 0.9f);
                Projectile.NewProjectile(position.X + speedX * 3, position.Y + Main.rand.Next(-1, 2) * 6f + speedY * 3 - 8, v.X, v.Y, base.mod.ProjectileType("LanternBoomLiF"), damage / 3, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-38.0f, -8.0f);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.4f, 0f, 0f);
        }
    }
}
