using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Fishes//������mod����
{
    public class Sargassum : ModItem//��������Ʒ����
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳�����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.width = 36;//��
            item.height = 38;//��
            item.rare = -1;//Ʒ��
            item.scale = 1f;//��С
            item.value = 10;
            item.maxStack = 999;
        }
    }
}
