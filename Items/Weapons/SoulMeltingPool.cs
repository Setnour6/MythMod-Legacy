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
			base.item.damage = 282;
			base.item.width = 52;
			base.item.height = 28;
			base.item.useTime = 1;
			base.item.useAnimation = 4;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 3000;
			base.item.rare = 11;
			base.item.autoReuse = true;
            base.item.shoot = 376;
			base.item.shootSpeed = 20f;
			base.item.useAmmo = 23;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			if(Main.rand.Next(0,100) < 50)
			{
				Projectile.NewProjectile(position.X + speedX + 2, position.Y - 2 + speedY, speedX, speedY, base.mod.ProjectileType("MeltingpotBlaze"), (int)((double)damage * 2), knockBack, player.whoAmI, 1f, 0f);
			}
			else
			{
				Projectile.NewProjectile(position.X + speedX - 2, position.Y - 2 + speedY, speedX, speedY, base.mod.ProjectileType("MeltingpotBlaze"), (int)((double)damage * 2), knockBack, player.whoAmI, 1f, 0f);
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
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/灵气熔炼池Glow"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public int k = 0;
        public override bool ConsumeAmmo(Player player)
        {
            return k % 18 == 0;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12.0f, -5.0f);
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1910, 5);
            modRecipe.AddIngredient(null, "MaChineSoul", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
