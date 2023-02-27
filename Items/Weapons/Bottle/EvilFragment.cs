using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.Bottle
{
    public class EvilFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("封印碎片");
            base.Tooltip.SetDefault("这是封印碎片堆里的最后一块碎块,放回碎片堆以修复一件上古魔器\n召唤封魔石瓶");
        }
        public override void SetDefaults()
        {
            base.item.width = 32;
            base.item.height = 30;
            base.item.useAnimation = 45;
            base.item.useTime = 60;
            base.item.useStyle = 4;
            item.maxStack = 20;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.mod.NPCType("EvilBotle"));
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(3081, 50);
            modRecipe.AddIngredient(3001, 1);
            modRecipe.requiredTile[0] = 26;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
