using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class AppleDQL : ModItem
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("苹果德其利");
            // Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			Item.width = 30;
            Item.height = 38;
            Item.rare = 5;
            Item.useAnimation = 15;
            Item.value = 50000;
            Item.useTurn = true;
            Item.consumable = true;
            Item.maxStack = 30;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.useStyle = 2;
            base.Item.UseSound = SoundID.Item3;
            /*item.buffType = mod.BuffType("LonelyJelly");
            item.buffTime = 14400;*/
        }
       /* public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("LonelyJelly")))
            {
                player.AddBuff(base.mod.BuffType("LonelyJelly"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("LonelyJelly"));
        }*/
    }
}
