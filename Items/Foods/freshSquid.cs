using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class freshSquid : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("鱿鱼叉串");
            // base.Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.Item.width = 22;
            base.Item.height = 38;
            base.Item.rare = 8;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
		}
    }
}