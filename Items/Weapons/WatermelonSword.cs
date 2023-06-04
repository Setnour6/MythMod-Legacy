using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons//������mod����
{
    public class WatermelonSword : ModItem
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("看起来很好吃");//�̳� ����Ʒ����
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item.damage = 80;//�˺�
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;//�Ƿ��ǽ�ս
            Item.width = 68;//��
            Item.height = 68;//��
            Item.useTime = 42;//ʹ��ʱ�Ӷ����ʱ��
            Item.rare = 4;//Ʒ��
            Item.useAnimation = 14;//�Ӷ�ʱ��������ʱ��
            Item.useStyle = 1;//ʹ�ö����������ǻӶ�
            Item.knockBack = 4;//����
            Item.UseSound = SoundID.Item1;//�Ӷ�����
            Item.autoReuse = true;//�ܷ�����Ӷ�
            Item.crit = 8;//����
            Item.value = 60000;//��ֵ��1��ʾһͭ�ң�������100�����
            Item.scale = 1f;//��С
            Item.shoot = base.Mod.Find<ModProjectile>("西瓜剑气").Type;
            Item.shootSpeed = 7f;

        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 24; i++)
            {
                int num = Dust.NewDust(target.position, target.width, target.height, 115, target.velocity.X * 0f, target.velocity.Y * 0f, 115, default(Color), 2f);
                Main.dust[num].noGravity = true;
            }
            if (target.type == 488)
            {
                return;
            }
            float num1 = (float)damage * 0.04f;
            if ((int)num1 == 0)
            {
                return;
            }
            if (Main.rand.Next(5) == 1)
            {
            Projectile.NewProjectile(target.Center.X, target.Center.Y, 2f, 2f, base.Mod.Find<ModProjectile>("西瓜爆炸").Type, damage * 4, knockback, player.whoAmI, 0f, 0f);
            }
        }
        //15343648
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 60, 0f, 0f, 0, default(Color), 1f);
            int num = Main.rand.Next(5);
            if (num == 0)
            {
                num = 115;
            }
            else if (num == 1)
            {
                num = 115;
            }
            else if (num == 2)
            {
                num = 115;
            }
            else if (num == 3)
            {
                num = 183;
            }
            else
            {
                num = 183;
            }
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 0.4f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 0.4f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//����һ������
            recipe.AddIngredient(null, "WatermenlonPiece", 10); //��Ҫһ������
            recipe.AddIngredient(989, 1); 
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}
