using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class DirtSkeleton : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("泥塑颅骨");
            base.Tooltip.SetDefault("召唤潜地恶鬼");
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
            return !NPC.AnyNPCs(base.mod.NPCType("DirtSprite"));
        }
        public override bool UseItem(Player player)
        {
            if (NPC.CountNPCS(mod.NPCType("DirtSprite")) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, mod.NPCType("DirtSprite"), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(15, player.position, 0);
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(176, 40);
            modRecipe.requiredTile[0] = 26;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
