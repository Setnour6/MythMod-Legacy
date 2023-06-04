using MythMod.NPCs;
using Terraria.GameContent.Generation;
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
using Terraria.WorldBuilding;

namespace MythMod.Items
{
    public class GolChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Treasure Bag");
			// base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}
		public override void SetDefaults()
		{
            base.Item.maxStack = 1;
            base.Item.consumable = false;
            base.Item.width = 24;
            base.Item.height = 24;
            base.Item.rare = 9;
            base.Item.expert = true;
            //this.bossBagNPC = 4;
		}
		public override bool CanRightClick()
		{
			return true;
		}
        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 1)
            {
		    	player.QuickSpawnItem(base.Mod.Find<ModItem>("SwordGol").Type, 1);
            }
            player.QuickSpawnItem(base.Mod.Find<ModItem>("GolChest2").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("TrapYoyo").Type, 1);
            Item.stack--;
        }
	}
}
