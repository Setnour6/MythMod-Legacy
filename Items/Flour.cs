using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//������mod����
{
    public class Flour : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳�����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.useStyle = 1;
			base.item.useTurn = true;
            item.width = 56;//��
            item.height = 38;//��
            item.rare = 2;//Ʒ��
            item.scale = 1f;//��С
            item.value = 100;
            item.maxStack = 999;
        }
    }
}
