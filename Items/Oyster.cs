using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//������mod����
{
    public class Oyster : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳�����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.width = 18;//��
            item.height = 14;//��
            item.rare = 11;//Ʒ��
            item.scale = 1f;//��С
            item.value = 3000;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
