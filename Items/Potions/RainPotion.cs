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
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 999;
            Item.value = 10000;
            Item.rare = 6;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.useStyle = 2;
            base.Item.UseSound = SoundID.Item3;
            base.Item.consumable = true;
            Item.buffType = Mod.Find<ModBuff>("雨露").Type;
            Item.buffTime = 10800;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("雨露").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("雨露").Type, 10800, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("雨露").Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//制作一个武器
            recipe.AddIngredient(765, 15);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
    }
}