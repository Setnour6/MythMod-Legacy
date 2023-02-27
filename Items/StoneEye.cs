using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
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
            base.Item.width = 28;
            base.Item.height = 18;
            base.Item.useAnimation = 45;
            base.Item.useTime = 60;
            base.Item.useStyle = 4;
            base.Item.rare = 11;
            base.Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.Mod.Find<ModNPC>("熔岩巨石怪").Type);
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (NPC.CountNPCS(Mod.Find<ModNPC>("熔岩巨石怪").Type) < 1 && NPC.CountNPCS(Mod.Find<ModNPC>("熔岩巨石怪").Type) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, Mod.Find<ModNPC>("熔岩巨石怪").Type, 0, 0f, 0f, 0f, 0f, 255);
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                //item.stack--;
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "LavaStone", 30);
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}
