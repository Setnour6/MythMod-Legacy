using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items//在虚无mod的Items文件夹里
{
    public class SoulOfPine : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("青松之魂");//在游戏里的名称
            // Tooltip.SetDefault("");//物品介绍
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));//后面的5搞不懂 不过调的越小 动态懂得越快 4就是你刚刚图片中画的几个。
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;//是动物的精魄吗 这里写的不是
            ItemID.Sets.ItemIconPulse[Item.type] = true; //会浮动吗 就是慢慢变大慢慢变小那种
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;//长度
            Item.height = refItem.height;//高度
            Item.maxStack = 999;//最大叠加
            Item.value = 3333;//价值
            Item.rare = 9;//稀有度
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            maxFallSpeed *= 0f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(200, 200, 200, 0));
        }
    }
}