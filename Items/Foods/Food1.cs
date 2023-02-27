using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MythMod.UI.smartPhone;

namespace MythMod.Items.Foods
{
    public class Food1 : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("一阶美食手册");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.width = 28;
            base.item.height = 30;
            base.item.rare = 0;
            base.item.value = Item.sellPrice(0, 0, 5, 0);
            base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
        }
        public override void AddRecipes()
        {
        }
        public override bool UseItem(Player player)
        {
            smartPhoneMain.Book = 1;
            smartPhone.Open = true;
            return base.UseItem(player);
        }
        public override void HoldItem(Player player)
        {
            MythGlobalItem.MrC = 60;
            base.HoldItem(player);
        }
    }
}
