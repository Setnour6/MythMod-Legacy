using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;

namespace MythMod.Items.Weapons.Bottle
{
    public class GeometryEvil : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "几何魔焰");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
        }
        public override void SetDefaults()
        {
            base.item.damage = 54;
			base.item.magic = true;
			base.item.mana = 28;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 27;
			base.item.useAnimation = 27;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = 2000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item8;
			base.item.autoReuse = true;
			base.item.shoot = mod.ProjectileType("BoneFeather");
			base.item.shootSpeed = 9f;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 v0 = new Vector2(speedX, speedY);
            float Rot = Main.rand.NextFloat(0, (float)Math.PI * 2);
            double io = Main.rand.NextFloat(0, 10f);
            Vector2 P1 = new Vector2(0, 50).RotatedBy(Rot);
            Vector2 P2 = new Vector2(0, 50).RotatedBy(Rot + Math.PI * 0.6666666667d);
            Vector2 P3 = new Vector2(0, 50).RotatedBy(Rot + Math.PI * 1.3333333333d);
            for (int i = 0; i < 6; i++)
            {
                float m = i / 6f;
                Vector2 v = (P1 * m + P2 * (1 - m)) * 0.1f + v0;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, mod.ProjectileType("DarkFlameball3"), damage, 0f, Main.myPlayer, 0f, 0f);
            }
            for (int i = 0; i < 6; i++)
            {
                float m = i / 6f;
                Vector2 v = (P2 * m + P3 * (1 - m)) * 0.1f + v0;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, mod.ProjectileType("DarkFlameball3"), damage, 0f, Main.myPlayer, 0f, 0f);
            }
            for (int i = 0; i < 6; i++)
            {
                float m = i / 6f;
                Vector2 v = (P3 * m + P1 * (1 - m)) * 0.1f + v0;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, mod.ProjectileType("DarkFlameball3"), damage, 0f, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
    }
}
