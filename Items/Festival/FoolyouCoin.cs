using MythMod.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Festival
{
    public class FoolyouCoin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("忽悠币");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "看它笑得多么真诚\n召唤元宝大作战,此事件不会对玩家造成伤害,请放心使用\nBoss存在时不能使用\n元宝大作战期间意外介入Boss自动消除");
        }
        public override void SetDefaults()
        {
            base.Item.width = 30;
            base.Item.height = 32;
            base.Item.rare = 2;
            Item.noUseGraphic = true;
            base.Item.scale = 1f;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 5;
            base.Item.useTime = 5;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 0;
        }
        private bool BOSS = false;
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for(int m = 0; m < 200; m++)
            {
                if(Main.npc[m].boss == true && Main.npc[m].active)
                {
                    BOSS = true;
                }
            }
            if (mplayer.GoldTime == 0 && !BOSS)
            {
                mplayer.GoldTime = 3600;
                mplayer.GoldPoint = 0;
                mplayer.GoldLevel = 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void AddRecipes()
        {
            //ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(73, 1);
            //recipe.SetResult(this, 1);
            //recipe.requiredTile[0] = 26;
            //recipe.AddRecipe();
        }
    }
}
