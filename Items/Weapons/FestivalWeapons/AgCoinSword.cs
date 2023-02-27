using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.FestivalWeapons//������mod����
{
    public class AgCoinSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("银币剑");
            Tooltip.SetDefault("");//�̳� ����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 45;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 68;//��
            item.height = 68;//��
            item.useTime = 36;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 4;//Ʒ��
            item.useAnimation = 12;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 4;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 4;//����
            item.value = 9999;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С
            item.shoot = base.mod.ProjectileType("AgSwordChi");
            item.shootSpeed = 12f;

        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
        }
        //15343648
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
    }
}
