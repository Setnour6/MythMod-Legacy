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
namespace MythMod.Items.Weapons
{
    public class MiniEruption : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "迷你喷流");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出高能喷流,火力很猛的\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 150;
			base.Item.width = 42;
			base.Item.height = 26;
			base.Item.useTime = 4;
			base.Item.useAnimation = 4;
			base.Item.useStyle = 5;
            base.Item.mana = 7;
            base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.knockBack = 1f;
			base.Item.value = 50000;
			base.Item.rare = 5;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("MiniEruption").Type;
			base.Item.shootSpeed = 9f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Vector2 v2 = position + new Vector2(speedX, speedY) * 4.2f;
            Vector2 v = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.05f, 0.05f)) * Main.rand.Next(10, 40) / 15f;
            int num8 = Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, base.Mod.Find<ModProjectile>("MiniEruption").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[num8].scale = Main.rand.NextFloat(0.44f, 1f);
            Vector2 v23 = position + new Vector2(speedX, speedY) * 2.1f;
            Vector2 v3 = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.05f, 0.05f)) * Main.rand.Next(10, 40) / 15f;
            int num3 = Projectile.NewProjectile(v23.X, v23.Y - 4, v3.X, v3.Y, 100, damage, knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[num3].hostile = false;
            Main.projectile[num3].friendly = true;
            for(int t = 0;t < 8;t++)
            {
                Vector2 v4 = new Vector2(speedX, speedY).RotatedBy(Main.rand.NextFloat(-0.05f, 0.05f)) * Main.rand.Next(10, 90) / 15f;
                int h = Dust.NewDust(new Vector2(v2.X, v2.Y - 4), 0, 0, 182, v4.X, v4.Y, 0, default(Color), Main.rand.NextFloat(1.5f, 3f));
                Main.dust[h].noGravity = true;
            }
            return false;
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.Next(0, 100) > 24;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9.0f, 0.0f);
        }
	}
}
