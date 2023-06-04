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
            // base.DisplayName.SetDefault("蝙蝠肉");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.width = 16;
            base.Item.height = 22;
            base.Item.rare = 1;
            base.Item.value = Item.sellPrice(0, 0, 50, 0);
            base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
        }
	}
}
