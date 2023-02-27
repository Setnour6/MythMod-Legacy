using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MythMod.Items.Walls
{
    public class CyanCoralWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "青纽扣珊瑚墙");
		}
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.maxStack = 999;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 7;
			base.item.useStyle = 1;
			base.item.consumable = true;
            base.item.createWall = base.mod.WallType("青纽扣珊瑚墙");
		}
    }
}
