using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class EmpMagic : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("空符咒");
            Tooltip.SetDefault("在恶魔或猩红祭坛附魔后变成符咒");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;//长度
            item.height = refItem.height;//高度
            item.maxStack = 999;//最大叠加
            item.value = 100;//价值
            item.rare = 0;//稀有度
        }
    }
}