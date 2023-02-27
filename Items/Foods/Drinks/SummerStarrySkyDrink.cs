using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class SummerStarrySkyDrink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("夏夜星空");
            Tooltip.SetDefault("喝下去才知道效果");
		}
		public override void SetDefaults()
		{
			Item.width = 18;
            Item.height = 38;
            Item.rare = 5;
            Item.value = 50000;
            Item.useTurn = true;
			Item.consumable = true;
            Item.maxStack = 30;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.useStyle = 2;
            base.Item.UseSound = SoundID.Item3;
            Item.buffType = Mod.Find<ModBuff>("SummerStarrySkyDrink").Type;
            Item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("SummerStarrySkyDrink").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("SummerStarrySkyDrink").Type, 14400, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("SummerStarrySkyDrink").Type);
        }
    }
}
