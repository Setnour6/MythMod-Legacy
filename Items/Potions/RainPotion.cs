using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class RainPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("雨露药剂");
            Tooltip.SetDefault("\n下雨越大你的攻击伤害越高,且你的生命在雨中缓缓回复");
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
            item.buffType = mod.BuffType("雨露");
            item.buffTime = 10800;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("雨露")))
            {
                player.AddBuff(base.mod.BuffType("雨露"), 10800, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("雨露"));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(765, 15);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1); //制作一个武器
            recipe.AddRecipe();
        }
    }
}