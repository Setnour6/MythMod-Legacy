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
            Item.buffType = Mod.Find<ModBuff>("嗜血狂暴").Type;
            Item.buffTime = 3600;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(Mod.Find<ModBuff>("嗜血狂暴").Type))
            {
                player.AddBuff(base.Mod.Find<ModBuff>("嗜血狂暴").Type, 3600, true);
                Item.stack--;
            }
            return player.HasBuff(Mod.Find<ModBuff>("嗜血狂暴").Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("BloodCryst").Type, 3);
            recipe.AddIngredient(126, 1);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
    }
}