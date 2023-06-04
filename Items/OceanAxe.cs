using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class OceanAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("碧海战斧");
			// base.Tooltip.SetDefault("brush!");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "碧海战斧");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "像海啸一样破坏植被");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 105;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.width = 50;
			base.Item.height = 40;
			base.Item.useTime = 20;
			base.Item.useAnimation = 30;
			base.Item.useTurn = true;
			base.Item.axe = 34;	
			base.Item.useStyle = 1;
			base.Item.knockBack = 9f;
			base.Item.value = 40000;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
            base.Item.rare = 8;
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "OceanBlueBar", 12);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height / 4, 33, 0f, 0f, 0, default(Color), 1f);
			Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height / 2, 33, 0f, 0f, 0, default(Color), 1.8f);
			if (Main.rand.Next(3) == 0)
			{
				int num = Main.rand.Next(3);
				if (num == 0)
				{
					num = 33;
				}
				else if (num == 1)
				{
					num = 56;
				}
				else
				{
					num = 277;
				}
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
