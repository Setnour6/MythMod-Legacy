using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
    public class BambooNut : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("竹笋");
		}
		public override void SetDefaults()
		{
			base.Item.width = 46;
			base.Item.height = 62;
			base.Item.rare = 3;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            base.Item.scale = 0.8f;
		}
	}
}
