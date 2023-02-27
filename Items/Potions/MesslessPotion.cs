using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class MesslessPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("飘幻药剂");
            Tooltip.SetDefault("闪避率提高6%");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 10000;
            item.rare = 6;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.useStyle = 2;
            base.item.UseSound = SoundID.Item3;
            base.item.consumable = true;
            item.buffType = mod.BuffType("Missable");
            item.buffTime = 10800;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("Missable")))
            {
                player.AddBuff(base.mod.BuffType("Missable"), 10800, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("Missable"));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(320, 2);
            recipe.AddIngredient(751, 15);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}