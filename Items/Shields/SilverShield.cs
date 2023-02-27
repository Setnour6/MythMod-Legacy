﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Shields
{
	public class SilverShield : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("银盾");
            Tooltip.AddTranslation(GameCulture.Chinese, "拿在手上才能获得防御,并且受到伤害减少21%\n有概率挡住盾牌方向的弹幕,越慢的越容易被挡住");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 1;
            Item.flame = true;
            Item.value = 100;
            Item.defense = 22;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 5)
            {
                mplayer.SD = 5;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, Mod.Find<ModProjectile>("SilverShield").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
            mplayer.AddDef = 22;
            mplayer.DisHurt = 21;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(21, 30);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}