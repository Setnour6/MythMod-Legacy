﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items.light
{
	public class PinkFlashlight : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("粉手电筒");
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 1;
            Item.flame = true;
            Item.value = 10000;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 16)
            {
                mplayer.SD = 16;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, Mod.Find<ModProjectile>("PinkFlashlight").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(3114, 3);
            recipe.AddIngredient(3113, 15);
            recipe.Register();
        }
    }
}