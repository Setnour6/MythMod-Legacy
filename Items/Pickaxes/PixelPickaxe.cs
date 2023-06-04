using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Pickaxes
{
    public class PixelPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("PixelPickaxe");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "像素分割者");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 121;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.width = 40;
			base.Item.height = 42;
			base.Item.useTime = 4;
			base.Item.useAnimation = 9;
			base.Item.useTurn = true;
			base.Item.pick = 290;
			base.Item.useStyle = 1;
			base.Item.knockBack = 9f;
			base.Item.value = 90000;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
			base.Item.tileBoost += 4;
            base.Item.rare = 11;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int num = Main.rand.Next(3);
				if (num == 0)
				{
					num = Mod.Find<ModDust>("Pixel").Type;
				}
				else if (num == 1)
				{
					num = Mod.Find<ModDust>("Pixel2").Type;
				}
				else
				{
					num = Mod.Find<ModDust>("Pixel").Type;
				}
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1f);
			}
		}
    }
}
