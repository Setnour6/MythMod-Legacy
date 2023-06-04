using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.FestivalWeapons//������mod����
{
    public class PtCoinSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");//�̳� ����Ʒ����
            // base.DisplayName.SetDefault("铂金币剑");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 460;//�˺�
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//�Ƿ��ǽ�ս
            Item.width = 68;//��
            Item.height = 68;//��
            Item.useTime = 30;//ʹ��ʱ�Ӷ����ʱ��
            Item.rare = 6;//Ʒ��
            Item.useAnimation = 10;//�Ӷ�ʱ��������ʱ��
            Item.useStyle = 1;//ʹ�ö����������ǻӶ�
            Item.knockBack = 7;//����
            Item.UseSound = SoundID.Item1;//�Ӷ�����
            Item.autoReuse = true;//�ܷ�����Ӷ�
            Item.crit = 8;//����
            Item.value = 99999;//��ֵ��1��ʾһͭ�ң�������100�����
            Item.scale = 1f;//��С
            Item.shoot = base.Mod.Find<ModProjectile>("PtSwordChi").Type;
            Item.shootSpeed = 14f;

        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
        }
        //15343648
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
        }
    }
}
