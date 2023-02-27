using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class StoneEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("石眼");
            base.Tooltip.SetDefault("你感到火山深处的颤抖");
        }
        public override void SetDefaults()
        {
            base.item.width = 28;
            base.item.height = 18;
            base.item.useAnimation = 45;
            base.item.useTime = 60;
            base.item.useStyle = 4;
            base.item.rare = 11;
            base.item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.mod.NPCType("熔岩巨石怪"));
        }
        public override bool UseItem(Player player)
        {
            if (NPC.CountNPCS(mod.NPCType("熔岩巨石怪")) < 1 && NPC.CountNPCS(mod.NPCType("熔岩巨石怪")) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, mod.NPCType("熔岩巨石怪"), 0, 0f, 0f, 0f, 0f, 255);
                Main.PlaySound(15, player.position, 0);
                //item.stack--;
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LavaStone", 30);
            recipe.requiredTile[0] = 412;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
