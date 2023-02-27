using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BatMeat : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蝙蝠肉");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.width = 16;
            base.item.height = 22;
            base.item.rare = 1;
            base.item.value = Item.sellPrice(0, 0, 50, 0);
            base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
        }
	}
}
