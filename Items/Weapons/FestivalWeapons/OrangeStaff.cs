using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class OrangeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("年桔法杖");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "年桔法杖");
		}
        public override void SetDefaults()
		{
			base.item.damage = 300;
			base.item.magic = true;
			base.item.mana = 14;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 4;
			base.item.useAnimation = 4;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.5f;
			base.item.value = 16000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("HighPowerTangerine");
			base.item.shootSpeed = 15f;
		}
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.Ost && Main.mouseLeft)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("OrangeVortex"), 0, 0, Main.myPlayer, 0f, 0f);
                mplayer.Ost = false;
            }
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 v = new Vector2(speedX, speedY);
            Vector2 v2 = v.RotatedBy(Math.PI / 2d) * Main.rand.NextFloat(-1.5f, 1.5f) + v * Main.rand.NextFloat(2.5f, 3f);
            Projectile.NewProjectile(position.X + v2.X - 15, position.Y + v2.Y - 15, v.X, v.Y, type, damage, knockBack, player.whoAmI, 1f);
            v2 = v.RotatedBy(Math.PI / 2d) * Main.rand.NextFloat(-1.5f, 1.5f) + v * Main.rand.NextFloat(2.5f, 3f);
            Projectile.NewProjectile(position.X + v2.X - 15, position.Y + v2.Y - 15, v.X, v.Y, type, damage, knockBack, player.whoAmI, 1f);
            v2 = v.RotatedBy(Math.PI / 2d) * Main.rand.NextFloat(-1.5f, 1.5f) + v * Main.rand.NextFloat(2.5f, 3f);
            Projectile.NewProjectile(position.X + v2.X - 15, position.Y + v2.Y - 15, v.X, v.Y, type, damage, knockBack, player.whoAmI, 1f);
            v2 = v.RotatedBy(Math.PI / 2d) * Main.rand.NextFloat(-1.5f, 1.5f) + v * Main.rand.NextFloat(2.5f, 3f);
            Projectile.NewProjectile(position.X + v2.X - 15, position.Y + v2.Y - 15, v.X, v.Y, type, damage, knockBack, player.whoAmI, 1f);
            return false;
        }
    }
}
