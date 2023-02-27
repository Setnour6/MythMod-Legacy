using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items
{
    public class MLChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Treasure Bag");
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}
		public override void SetDefaults()
		{
            base.item.maxStack = 1;
            base.item.consumable = false;
            base.item.width = 24;
            base.item.height = 24;
            base.item.rare = 9;
            base.item.expert = true;
            //this.bossBagNPC = 4;
		}
		public override bool CanRightClick()
		{
			return true;
		}
        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(base.mod.ItemType("MLChest2"), 1);
            player.QuickSpawnItem(base.mod.ItemType("MoonHeart"), 1);
            player.QuickSpawnItem(base.mod.ItemType("MESword"), 1);
            item.stack--;
        }
	}
}
