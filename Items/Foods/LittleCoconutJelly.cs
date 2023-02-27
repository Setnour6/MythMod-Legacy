using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class LittleCoconutJelly : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("小椰子果冻");
            base.Tooltip.SetDefault("放在身边获得增益,美味等级II");
		}
        public override void SetDefaults()
        {
            base.Item.width = 74;
            base.Item.height = 32;
            base.Item.rare = 0;
            base.Item.useAnimation = 20;
            base.Item.useTime = 20;
            base.Item.useStyle = 1;
            base.Item.UseSound = SoundID.Item8;
            base.Item.consumable = true;
            base.Item.maxStack = 200;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("小椰子果冻").Type;
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
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
