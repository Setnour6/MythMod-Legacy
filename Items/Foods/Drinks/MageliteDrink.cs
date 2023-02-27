using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class MageliteDrink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("玛格丽特");
            Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			item.width = 28;
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
            item.buffType = mod.BuffType("Magelite");
            item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("Magelite")))
            {
                player.AddBuff(base.mod.BuffType("Magelite"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("Magelite"));
        }
    }
}
