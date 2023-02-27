﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class CrystalScabbardEx : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("诅咒冰晶剑鞘");
            base.Tooltip.SetDefault("召唤冰洲石剑Ex\n无消耗\n这个你打不过");
        }
        public override void SetDefaults()
        {
            base.item.width = 28;
            base.item.height = 18;
            base.item.useAnimation = 45;
            base.item.useTime = 60;
            base.item.useStyle = 4;
            base.item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.mod.NPCType("CrystalSword"));
        }
        public override bool UseItem(Player player)
        {
            if (NPC.CountNPCS(mod.NPCType("CrystalSwordEX")) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, mod.NPCType("CrystalSwordEX"), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(15, player.position, 0);
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Crystal", 400);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}