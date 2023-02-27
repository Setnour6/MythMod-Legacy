using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
    public class MangeCubes : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("芒果丁");
		}
		public override void SetDefaults()
		{
			base.Item.width = 22;
			base.Item.height = 26;
			base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}
	}
}
