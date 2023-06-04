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
            // DisplayName.SetDefault("神盾药剂");
            // Tooltip.SetDefault("提升24点防御");
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 30;
            Item.value = 60000;
            Item.rare = 7;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.useStyle = 2;
            base.Item.UseSound = SoundID.Item3;
            base.Item.consumable = true;
            Item.buffType = Mod.Find<ModBuff>("ShieldPotion").Type;
            Item.buffTime = 10800;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("ShieldPotion").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("ShieldPotion").Type, 18000, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("ShieldPotion").Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(947, 3);
            recipe.AddIngredient(292, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
    }
}