using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class StarAbyssPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星渊毒剂");
            Tooltip.SetDefault("血色毒素中流动着撕裂神经的能量\n近战携带恐怖的剧毒\n一瓶撒下自来水系统足以毁灭一座城");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 10000;
            item.rare = 11;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.useStyle = 2;
            base.item.UseSound = SoundID.Item3;
            base.item.consumable = true;
            item.buffType = mod.BuffType("StarSword");
            item.buffTime = 72000;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("StarSword")))
            {
                player.AddBuff(base.mod.BuffType("StarSword"), 72000, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("StarSword"));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StarAbyssCell"), 3);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1); 
            recipe.AddRecipe();
        }
    }
}