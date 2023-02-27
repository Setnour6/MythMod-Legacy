using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class U8GrapefruitDrink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("U8西柚");
            Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			item.width = 18;
            item.height = 34;
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
            item.buffType = mod.BuffType("U8Grapefruit");
            item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("U8Grapefruit")))
            {
                player.AddBuff(base.mod.BuffType("U8Grapefruit"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("U8Grapefruit"));
        }
    }
}
