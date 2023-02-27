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

namespace MythMod.Items
{
    public class TwinsChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Treasure Bag");
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
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
            if (Main.rand.Next(2) == 1)
            {
            }
            //player.QuickSpawnItem(549, Main.rand.Next(322, 652));
            //player.QuickSpawnItem(1225, Main.rand.Next(178, 382));
            //player.QuickSpawnItem(3354, 1);
            //player.QuickSpawnItem(1368, 1);
            //player.QuickSpawnItem(1369, 1);
            //player.QuickSpawnItem(2106, 1);
            if (Main.rand.Next(100) >= 50)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordTwins"), 1);
            }
            player.QuickSpawnItem(499, Main.rand.Next(80, 140));
            player.QuickSpawnItem(base.mod.ItemType("TwinsChest2"), 1);
            player.QuickSpawnItem(base.mod.ItemType("BloodLightCyanFlame"), 1);
            player.QuickSpawnItem(base.mod.ItemType("LazarBattery"), Main.rand.Next(3, 8));
            item.stack--;
        }
	}
}
