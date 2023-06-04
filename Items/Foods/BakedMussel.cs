using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakedMussel : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("炭烧青口");
            // base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
			base.Item.width = 34;
            base.Item.height = 30;
            base.Item.rare = 0;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 1;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            base.Item.createTile = base.Mod.Find<ModTile>("炭烧青口").Type;
        }
        public override void AddRecipes()
        {
        }
	}
}
