using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class StonI : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("一阶岩石神盾符咒");
            // Tooltip.SetDefault("让你防御极大地提升\n持续5s\n冷却10s");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item.width = 26;//长度
            Item.height = 40;//高度
            Item.maxStack = 999;//最大叠加
            Item.value = 1000;//价值
            Item.rare = 0;//稀有度
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                player.AddBuff(Mod.Find<ModBuff>("护体神盾").Type, 300);
                mplayer.MagicCool += 600;
                Item.stack--;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "EmpMagic", 1);
            recipe.AddIngredient(3, 50);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
    }
}