using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//������mod����
{
    public class BoneLiquid : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳�����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.width = 48;//��
            item.height = 18;//��
            item.rare = 3;//Ʒ��
            item.scale = 1f;//��С
            item.value = 50;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
