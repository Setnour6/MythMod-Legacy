using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.WorldBuilding;

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
            Item.glowMask = GetGlowMask;
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
            }
            //player.QuickSpawnItem(549, Main.rand.Next(322, 652));
            //player.QuickSpawnItem(1225, Main.rand.Next(178, 382));
            //player.QuickSpawnItem(3354, 1);
            //player.QuickSpawnItem(1368, 1);
            //player.QuickSpawnItem(1369, 1);
            //player.QuickSpawnItem(2106, 1);
            if (Main.rand.Next(100) >= 50)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("SwordTwins").Type, 1);
            }
            player.QuickSpawnItem(499, Main.rand.Next(80, 140));
            player.QuickSpawnItem(base.Mod.Find<ModItem>("TwinsChest2").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("BloodLightCyanFlame").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("LazarBattery").Type, Main.rand.Next(3, 8));
            Item.stack--;
        }
	}
}
