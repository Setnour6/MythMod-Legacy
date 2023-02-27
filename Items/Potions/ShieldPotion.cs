using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Potions
{
    public class ShieldPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("神盾药剂");
            Tooltip.SetDefault("提升24点防御");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 30;
            item.value = 60000;
            item.rare = 7;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.useStyle = 2;
            base.item.UseSound = SoundID.Item3;
            base.item.consumable = true;
            item.buffType = mod.BuffType("ShieldPotion");
            item.buffTime = 10800;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("ShieldPotion")))
            {
                player.AddBuff(base.mod.BuffType("ShieldPotion"), 18000, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("ShieldPotion"));
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(947, 3);
            recipe.AddIngredient(292, 1);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}