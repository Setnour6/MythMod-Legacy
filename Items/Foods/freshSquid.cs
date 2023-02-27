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
            base.DisplayName.SetDefault("鱿鱼叉串");
            base.Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            base.item.width = 22;
            base.item.height = 38;
            base.item.rare = 8;
			base.item.useAnimation = 30;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
		}
    }
}