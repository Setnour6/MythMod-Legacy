using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.FestivalWeapons//������mod����
{
    public class CuCoinSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");//�̳� ����Ʒ����
            // base.DisplayName.SetDefault("铜币剑");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.damage = 22;//�˺�
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//�Ƿ��ǽ�ս
            Item.width = 68;//��
            Item.height = 68;//��
            Item.useTime = 42;//ʹ��ʱ�Ӷ����ʱ��
            Item.rare = 2;//Ʒ��
            Item.useAnimation = 14;//�Ӷ�ʱ��������ʱ��
            Item.useStyle = 1;//ʹ�ö����������ǻӶ�
            Item.knockBack = 4;//����
            Item.UseSound = SoundID.Item1;//�Ӷ�����
            Item.autoReuse = true;//�ܷ�����Ӷ�
            Item.crit = 0;//����
            Item.value = 99;//��ֵ��1��ʾһͭ�ң�������100�����
            Item.scale = 1f;//��С
            Item.shoot = base.Mod.Find<ModProjectile>("CuSwordChi").Type;
            Item.shootSpeed = 10f;

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
