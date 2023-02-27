using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	public class WaveTip : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Tip of the wave");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "浪尖");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.item.useStyle = 3;
			base.item.useTurn = false;
			base.item.useAnimation = 5;
			base.item.useTime = 5;
			base.item.width = 42;
			base.item.height = 42;
			base.item.damage = 125;
			base.item.melee = true;
			base.item.knockBack = 6.5f;
			base.item.UseSound = SoundID.Item1;
			base.item.useTurn = true;
			base.item.autoReuse = true;
            item.shoot = mod.ProjectileType("WaveBallMini");

            base.item.shootSpeed = 12f;
			base.item.value = Item.buyPrice(0, 80, 0, 0);
			base.item.rare = 11;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "OceanBlueBar", 8);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 33, 0f, 0f, 0, default(Color), 1f);
			}
		}
        private int r = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            r += 1;
            if(r % 4 == 0)
            {
                Projectile.NewProjectile((float)position.X, (float)position.Y, player.direction * 14f, 0, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
