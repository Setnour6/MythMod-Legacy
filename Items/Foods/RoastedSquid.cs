using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class RoastedSquid : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("烤鲜鱿");
            base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
			base.item.width = 50;
            base.item.height = 52;
            base.item.rare = 5;
			base.item.useAnimation = 30;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
		}
        public override void AddRecipes()
        {

        }
    }
}
