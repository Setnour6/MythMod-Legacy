using System;
using System.Collections.Generic;
using System.IO;
using MythMod.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace MythMod.Items
{
    public class FleChest : ModItem
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
            base.Item.maxStack = 1;
            base.Item.consumable = false;
            base.Item.width = 24;
            base.Item.height = 24;
            base.Item.rare = 9;
            base.Item.expert = true;
            //this.bossBagNPC = 13;
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 1)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("SwordWOF").Type, 1);
            }
            player.QuickSpawnItem(base.Mod.Find<ModItem>("FleChest2").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("BloodHeartStone").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("UnstableTranspStaff").Type, 1);
            if (Main.rand.Next(20) == 1)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("BloodGoldBlade").Type, 1);
            }
            Item.stack--;
        }
    }
}
