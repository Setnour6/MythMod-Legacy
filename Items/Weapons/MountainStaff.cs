using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class MountainStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("埋山法杖");
			base.Tooltip.SetDefault("从天而降无数土块\n 神话");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 38;
            base.Item.DamageType = DamageClass.Magic;
            base.Item.mana = 16;
            base.Item.width = 64;
			base.Item.height = 76;
			base.Item.useTime = 16;
			base.Item.useAnimation = 16;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 6;
			base.Item.value = 10000;
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item44;
            Item.shoot = Mod.Find<ModProjectile>("DirtBall").Type;
            Item.shootSpeed = 9f;
            base.Item.autoReuse = false;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            for (int i = 0; i < 4f; i++)
            {
                float X = Main.rand.NextFloat(-250, 250);
                float Y = Main.rand.NextFloat(-250, 250);
                Vector2 v2 = (new Vector2(Main.screenPosition.X + Main.mouseX + Main.rand.NextFloat(-24, 24), Main.screenPosition.Y + Main.mouseY + Main.rand.NextFloat(-24, 24)) - new Vector2((float)position.X + X, (float)position.Y - 1000f + Y));
                v2 = v2 / v2.Length() * 13f;
                int u = Projectile.NewProjectile((float)position.X + X, (float)position.Y - 1000f + Y, v2.X, v2.Y, Mod.Find<ModProjectile>("DirtBall").Type, (int)damage, (float)knockBack, player.whoAmI, 2, 0f);
                Main.projectile[u].hostile = false;
                Main.projectile[u].friendly = true;
            }
            return false;
		}
	}
}
