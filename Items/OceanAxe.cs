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
            base.DisplayName.SetDefault("碧海战斧");
			base.Tooltip.SetDefault("brush!");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "碧海战斧");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "像海啸一样破坏植被");
		}
		public override void SetDefaults()
		{
			base.item.damage = 105;
			base.item.melee = true;
			base.item.width = 50;
			base.item.height = 40;
			base.item.useTime = 20;
			base.item.useAnimation = 30;
			base.item.useTurn = true;
			base.item.axe = 34;	
			base.item.useStyle = 1;
			base.item.knockBack = 9f;
			base.item.value = 40000;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
            base.item.rare = 8;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "OceanBlueBar", 12);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
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
