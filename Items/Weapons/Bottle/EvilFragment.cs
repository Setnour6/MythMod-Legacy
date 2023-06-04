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
            // base.DisplayName.SetDefault("封印碎片");
            // base.Tooltip.SetDefault("这是封印碎片堆里的最后一块碎块,放回碎片堆以修复一件上古魔器\n召唤封魔石瓶");
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
            return !NPC.AnyNPCs(base.Mod.Find<ModNPC>("EvilBotle").Type);
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(3081, 50);
            modRecipe.AddIngredient(3001, 1);
            modRecipe.requiredTile[0] = 26;
            modRecipe.Register();
        }
    }
}
