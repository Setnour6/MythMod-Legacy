using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
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
namespace MythMod.Items.TreasureBag
{
    public class OceanCrystalTreasureBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Treasure Bag");
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}
		public override void SetDefaults()
		{
            base.Item.maxStack = 999;
            base.Item.consumable = true;
            base.Item.width = 24;
            base.Item.height = 24;
            base.Item.rare = 9;
            base.Item.expert = true;
		}
		public override bool CanRightClick()
		{
			return true;
		}
        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(base.Mod.Find<ModItem>("Aquamarine").Type, Main.rand.Next(82, 137));
            player.QuickSpawnItem(base.Mod.Find<ModItem>("MysteriesPearl").Type, Main.rand.Next(16, 65));
            player.QuickSpawnItem(base.Mod.Find<ModItem>("MeanderWave").Type, 1);
            int type = 0;
            switch (Main.rand.Next(1, 6))
            {
                case 1:
                    type = base.Mod.Find<ModItem>("OceanBubble").Type;
                    break;
                case 2:
                    type = base.Mod.Find<ModItem>("OceanEverStone").Type;
                    break;
                case 3:
                    type = base.Mod.Find<ModItem>("OceanCurrentRay").Type;
                    break;
                case 4:
                    type = base.Mod.Find<ModItem>("OceanCrystalClub").Type;
                    break;
                case 5:
                    type = base.Mod.Find<ModItem>("OceanCrystalShield").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
        }
	}
}
