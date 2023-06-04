﻿using Terraria.ID;
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
            Item.shoot = base.Mod.Find<ModProjectile>("PineappleBeam").Type;
            Item.shootSpeed = 7f;

        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
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
