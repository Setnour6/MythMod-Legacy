using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
			base.Item.useStyle = 3;
			base.Item.useTurn = false;
			base.Item.useAnimation = 5;
			base.Item.useTime = 5;
			base.Item.width = 42;
			base.Item.height = 42;
			base.Item.damage = 125;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.knockBack = 6.5f;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("WaveBallMini").Type;

            base.Item.shootSpeed = 12f;
			base.Item.value = Item.buyPrice(0, 80, 0, 0);
			base.Item.rare = 11;
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "OceanBlueBar", 8);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 33, 0f, 0f, 0, default(Color), 1f);
			}
		}
        private int r = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
