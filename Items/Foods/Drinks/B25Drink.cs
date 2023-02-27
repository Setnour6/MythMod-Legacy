using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class B25Drink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("B-25轰炸机");
            Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			Item.width = 14;
            Item.height = 26;
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
            Item.buffType = Mod.Find<ModBuff>("B25").Type;
            Item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("B25").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("B25").Type, 14400, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("B25").Type);
        }
        public override void HoldItem(Player player)
        {
            if (Main.mouseRight)
            {
                Item.createTile = base.Mod.Find<ModTile>("B25").Type;
                Item.buffType = -1;
                Item.buffTime = 0;
                Item.useStyle = 1;
            }
            else
            {
                Item.createTile = -1;
                Item.useStyle = 2;
                Item.UseSound = SoundID.Item3;
                Item.buffType = Mod.Find<ModBuff>("B25").Type;
                Item.buffTime = 14400;
            }
            base.HoldItem(player);
        }
    }
}
