using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//������mod����
{
    public class IridiumSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("��â�ƿ�");//�̳� ����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 541;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 20;//��
            item.height = 20;//��
            item.useTime = 24;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 9;//Ʒ��
            item.useAnimation = 24;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 12;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 25;//����
            item.shoot = mod.ProjectileType("ҿ�𽣽���");
            item.shootSpeed = 10f;
            item.value = 14000000;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С

        }
    }
}
