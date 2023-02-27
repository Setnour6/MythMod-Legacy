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
    public class DirtSkeleton : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("泥塑颅骨");
            base.Tooltip.SetDefault("召唤潜地恶鬼");
        }
        public override void SetDefaults()
        {
            base.Item.width = 32;
            base.Item.height = 30;
            base.Item.useAnimation = 45;
            base.Item.useTime = 60;
            base.Item.useStyle = 4;
            Item.maxStack = 20;
            base.Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.Mod.Find<ModNPC>("DirtSprite").Type);
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (NPC.CountNPCS(Mod.Find<ModNPC>("DirtSprite").Type) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, Mod.Find<ModNPC>("DirtSprite").Type, 0, 0f, 0f, 0f, 0f, 255);
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(176, 40);
            modRecipe.requiredTile[0] = 26;
            modRecipe.Register();
        }
    }
}
