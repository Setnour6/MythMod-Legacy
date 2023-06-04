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
    public class GearGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "齿轮链条枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "射出疯狂子弹\n 66%不消耗弹药");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 470;
			base.Item.width = 62;
			base.Item.height = 44;
			base.Item.useTime = 4;
			base.Item.useAnimation = 4;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 50000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = 14;
			base.Item.shootSpeed = 20f;
			base.Item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
            Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-1, 2) * 6f, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
            if((int)(Main.time / 5f) % 5 == 0)
            {
                int k = Projectile.NewProjectile(position.X, position.Y + Main.rand.Next(-2, 2), speedX, speedY, 100, damage * 10, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[k].friendly = true;
                Main.projectile[k].hostile = false;
            }
            return false;
		}
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.Next(0, 100) > 66;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16.0f, 0.0f);
        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(31f, 22f);
			spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/齿轮链条枪Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1929, 5);
            modRecipe.AddIngredient(null, "MaChineSoul", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
