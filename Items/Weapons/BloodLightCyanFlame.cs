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
	public class BloodLightCyanFlame : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("血光青炎");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "一共有两种回旋刃,交替放出\n神话");
        }

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.shootSpeed = 17f;
			item.shoot = mod.ProjectileType("BloodLightCyanFlame1");
			item.width = 68;
			item.height = 68;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = 5;
            item.damage = 150;
            item.autoReuse = true;
            item.melee = true;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/血光青炎Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        private int l = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(l % 2 == 0)
            {
                type = mod.ProjectileType("BloodLightCyanFlame");
            }
            else
            {
                type = mod.ProjectileType("BloodLightCyanFlame1");
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            l++;
            return false;
        }
    }
}
