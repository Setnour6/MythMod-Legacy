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
    public class CrystalScabbard : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("冰晶剑鞘");
            base.Tooltip.SetDefault("召唤冰洲石剑\n无消耗");
        }
        public override void SetDefaults()
        {
            base.Item.width = 28;
            base.Item.height = 18;
            base.Item.useAnimation = 45;
            base.Item.useTime = 60;
            base.Item.useStyle = 4;
            base.Item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(base.Mod.Find<ModNPC>("CrystalSword").Type);
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (NPC.CountNPCS(Mod.Find<ModNPC>("CrystalSword").Type) < 1)
            {
                NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, Mod.Find<ModNPC>("CrystalSword").Type, 0, 0f, 0f, 0f, 0f, 255);
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                return true;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Crystal", 40);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
