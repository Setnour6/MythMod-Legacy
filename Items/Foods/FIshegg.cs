using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class FIshegg : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("鱼子酱");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.width = 22;
            base.item.height = 16;
            base.item.rare = 1;
            base.item.value = Item.sellPrice(0, 0, 0, 25);
            base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
        }
	}
}
