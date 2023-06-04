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
			// DisplayName.SetDefault("血光青炎");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "一共有两种回旋刃,交替放出\n神话");
        }

		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.shootSpeed = 17f;
			Item.shoot = Mod.Find<ModProjectile>("BloodLightCyanFlame1").Type;
			Item.width = 68;
			Item.height = 68;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = 5;
            Item.damage = 150;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/血光青炎Glow"), base.Item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        private int l = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(l % 2 == 0)
            {
                type = Mod.Find<ModProjectile>("BloodLightCyanFlame").Type;
            }
            else
            {
                type = Mod.Find<ModProjectile>("BloodLightCyanFlame1").Type;
            }
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
            l++;
            return false;
        }
    }
}
