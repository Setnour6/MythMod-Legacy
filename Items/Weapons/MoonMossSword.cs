using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//������mod����
{
    public class MoonMossSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳� ����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 422;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 20;//��
            item.height = 20;//��
            item.useTime = 24;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 9;//Ʒ��
            item.useAnimation = 24;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 11.6f;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 14;//����
            item.shoot = mod.ProjectileType("��Ӱ��ը");
            item.shootSpeed = 9;
            item.value = 9000000;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С

        }
    }
}
