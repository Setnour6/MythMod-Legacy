using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
namespace MythMod.Items.Weapons
{
    public class SoulMeltingPool : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灵气熔炼池");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 282;
			base.Item.width = 52;
			base.Item.height = 28;
			base.Item.useTime = 1;
			base.Item.useAnimation = 4;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 3000;
			base.Item.rare = 11;
			base.Item.autoReuse = true;
            base.Item.shoot = 376;
			base.Item.shootSpeed = 20f;
			base.Item.useAmmo = 23;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			if(Main.rand.Next(0,100) < 50)
			{
				Projectile.NewProjectile(position.X + speedX + 2, position.Y - 2 + speedY, speedX, speedY, base.Mod.Find<ModProjectile>("MeltingpotBlaze").Type, (int)((double)damage * 2), knockBack, player.whoAmI, 1f, 0f);
			}
			else
			{
				Projectile.NewProjectile(position.X + speedX - 2, position.Y - 2 + speedY, speedX, speedY, base.Mod.Find<ModProjectile>("MeltingpotBlaze").Type, (int)((double)damage * 2), knockBack, player.whoAmI, 1f, 0f);
			}
            k += 1;
            if(k >= 1073741824)
            {
                k = 0;
            }
            return false;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(26f, 14f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/灵气熔炼池Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public int k = 0;
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return k % 18 == 0;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, -5.0f);
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1910, 5);
            modRecipe.AddIngredient(null, "MaChineSoul", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
