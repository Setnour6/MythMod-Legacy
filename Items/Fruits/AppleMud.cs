using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
    public class AppleMud : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("苹果馅料");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 28;
			base.item.rare = 2;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.scale = 0.8f;
		}
    }
}
