using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.FestivalWeapons//������mod����
{
    public class AuCoinSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//�̳� ����Ʒ����
            base.DisplayName.SetDefault("金币剑");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 260;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 68;//��
            item.height = 68;//��
            item.useTime = 30;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 6;//Ʒ��
            item.useAnimation = 10;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 7;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 8;//����
            item.value = 99999;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С
            item.shoot = base.mod.ProjectileType("AuSwordChi");
            item.shootSpeed = 14f;

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