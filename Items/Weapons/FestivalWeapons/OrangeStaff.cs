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
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "年桔法杖");
		}
        public override void SetDefaults()
		{
			base.Item.damage = 300;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 14;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 4;
			base.Item.useAnimation = 4;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 0.5f;
			base.Item.value = 16000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("HighPowerTangerine").Type;
			base.Item.shootSpeed = 15f;
		}
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.Ost && Main.mouseLeft)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("OrangeVortex").Type, 0, 0, Main.myPlayer, 0f, 0f);
                mplayer.Ost = false;
            }
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
