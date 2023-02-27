using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//������mod����
{
    public class PineAppleSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("看起来很好吃");//�̳� ����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.damage = 80;//�˺�
            item.melee = true;//�Ƿ��ǽ�ս
            item.width = 68;//��
            item.height = 68;//��
            item.useTime = 42;//ʹ��ʱ�Ӷ����ʱ��
            item.rare = 4;//Ʒ��
            item.useAnimation = 14;//�Ӷ�ʱ��������ʱ��
            item.useStyle = 1;//ʹ�ö����������ǻӶ�
            item.knockBack = 4;//����
            item.UseSound = SoundID.Item1;//�Ӷ�����
            item.autoReuse = true;//�ܷ�����Ӷ�
            item.crit = 8;//����
            item.value = 60000;//��ֵ��1��ʾһͭ�ң�������100�����
            item.scale = 1f;//��С
            item.shoot = base.mod.ProjectileType("PineappleBeam");
            item.shootSpeed = 7f;

        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
        }
        //15343648
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 64, 0f, 0f, 0, default(Color), 1f);
            int num = Main.rand.Next(5);
            if (num == 0)
            {
                num = 64;
            }
            else if (num == 1)
            {
                num = 64;
            }
            else if (num == 2)
            {
                num = 64;
            }
            else if (num == 3)
            {
                num = 87;
            }
            else
            {
                num = 87;
            }
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 0.4f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 0.4f);
        }
        public override void AddRecipes()
        {
        }
    }
}
