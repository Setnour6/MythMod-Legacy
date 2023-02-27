using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakedOyster : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("炭烧生蚝");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 38;
            base.Item.height = 28;
            base.Item.rare = 0;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 1;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            base.Item.createTile = base.Mod.Find<ModTile>("炭烧生蚝").Type;
        }
        public override void AddRecipes()
        {
        }
	}
}
