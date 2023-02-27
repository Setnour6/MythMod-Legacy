using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Shaders;


namespace MythMod.Items.Accessories
{
	public class CorruptEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("暗影鳞之眼");
			base.Tooltip.SetDefault("增加5防御,8%暴击");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "暗影鳞之眼");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "增加5防御,8%暴击");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 32;
			base.item.height = 32;
			base.item.value = 10000;
			base.item.accessory = true;
            //Player player = Main.player[Main.myPlayer];
            //if (player.name != "万象元素")
            //{
                //base.item.maxStack = 0;
            //}
            //else
            //{
                //base.item.maxStack = 1;
            //}
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            /*MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.GreenBlood = 5;*/
            player.statDefense += 5;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            if (player.wet)
            {
                //player.meleeDamage *= 1.17f;
                //player.magicDamage *= 1.17f;
                //player.rangedDamage *= 1.17f;
                //player.minionDamage *= 1.17f;
                //player.thrownDamage *= 1.17f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "CurseflameScale", 5);
            modRecipe.AddIngredient(38,12);
            modRecipe.requiredTile[0] = 16;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
