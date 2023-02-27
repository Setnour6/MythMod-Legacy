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
			base.item.width = 22;
			base.item.height = 26;
			base.item.rare = 2;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
		}
	}
}
