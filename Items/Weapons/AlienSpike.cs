using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
namespace MythMod.Items.Weapons
{
    public class AlienSpike : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "异星蜇刺");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.item.damage = 90;
			base.item.width = 40;
			base.item.height = 22;
			base.item.useTime = 12;
			base.item.useAnimation = 12;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 50000;
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 577;
			base.item.shootSpeed = 14f;
			base.item.useAmmo = 97;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/异星蜇刺Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
            for(int y = 0;y < 2;y++)
            {
                Vector2 v = new Vector2(speedX, speedY) * Main.rand.NextFloat(0.8f,1.2f);
                v = v.RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f));
                int zi = Projectile.NewProjectile(position.X, position.Y - 2, v.X / 2f, v.Y / 2f, 577, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[zi].hostile = false;
                Main.projectile[zi].friendly = true;
            }
            for (int y = 0; y < 3; y++)
            {
                Vector2 v = new Vector2(speedX, speedY) * Main.rand.NextFloat(0.8f, 1.2f);
                v = v.RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f));
                int zi = Projectile.NewProjectile(position.X, position.Y - 2, v.X / 2f, v.Y / 2f, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[zi].hostile = false;
                Main.projectile[zi].friendly = true;
            }
            for (int y = 0; y < 2; y++)
            {
                Vector2 v = new Vector2(speedX, speedY) * Main.rand.NextFloat(0.8f, 1.2f);
                v = v.RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f));
                int zi = Projectile.NewProjectile(position.X, position.Y - 2, v.X, v.Y, 581, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[zi].hostile = false;
                Main.projectile[zi].friendly = true;
            }
            if(Main.rand.Next(10) == 1)
            {
                int zi = Projectile.NewProjectile(position.X, position.Y - 2, speedX / 7f, speedY / 7f, mod.ProjectileType("Thunderstaff"), (int)((double)damage) * 32, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-9.0f, -5.0f);
        }
	}
}
