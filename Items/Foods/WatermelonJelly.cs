using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class WatermelonJelly : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巨大西瓜果冻");
            base.Tooltip.SetDefault("看样子很好吃");
		}
        public override void SetDefaults()
        {
            base.item.width = 74;
            base.item.height = 32;
            base.item.rare = 0;
            base.item.useAnimation = 20;
            base.item.useTime = 20;
            base.item.useStyle = 1;
            base.item.UseSound = SoundID.Item8;
            base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("西瓜果冻");
        }
        public override bool UseItem(Player player)
        {
            //MythPlayer modPlayer = player.GetModPlayer<MythPlayer>(base.mod);
            //if (player.itemAnimation > 0 && player.itemTime == 0)
            //{
            //player.itemTime = base.item.useTime;
            //modPlayer.YinLife += 2;
            //player.statLife += 150;
            //}
            return true;
        }
        public override void AddRecipes()
        {

        }
	}
}
