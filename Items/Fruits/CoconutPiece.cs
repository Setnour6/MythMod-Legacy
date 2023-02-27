using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
    public class CoconutPiece : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("椰肉");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 54;
			base.Item.height = 62;
			base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 400;
        }
    }
}
