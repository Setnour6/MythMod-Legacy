using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class DaturaImpression : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("曼陀罗印象");
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
            item.buffType = mod.BuffType("DaturaImpression");
            item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("DaturaImpression")))
            {
                player.AddBuff(base.mod.BuffType("DaturaImpression"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("DaturaImpression"));
        }
    }
}
