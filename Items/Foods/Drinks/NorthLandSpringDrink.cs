using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class NorthLandSpringDrink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("北国之春");
            Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			item.width = 18;
            item.height = 32;
            item.rare = 5;
            item.useAnimation = 15;
            item.value = 50000;
            item.useTurn = true;
            item.consumable = true;
            item.maxStack = 30;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.useStyle = 2;
            base.item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType("NorthLandSpring");
            item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("NorthLandSpring")))
            {
                player.AddBuff(base.mod.BuffType("NorthLandSpring"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("NorthLandSpring"));
        }
    }
}
