using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class AngerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("狂暴药剂");
            Tooltip.SetDefault("\n攻击次数越多伤害越高,近战武器效果更佳\n神话");
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
            item.buffType = mod.BuffType("嗜血狂暴");
            item.buffTime = 3600;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("嗜血狂暴")))
            {
                player.AddBuff(base.mod.BuffType("嗜血狂暴"), 3600, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("嗜血狂暴"));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BloodCryst"), 3);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}