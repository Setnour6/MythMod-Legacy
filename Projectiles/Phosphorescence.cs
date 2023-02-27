using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace MythMod/*mod��*/.Projectiles
{
    public class Phosphorescence : ModProjectile
    {
        // Brought to you with <3 by Gorateron
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("�׹�");//����
            Main.projFrames[projectile.type] = 4; /*��֡��Ϊ6����Ӧ����ͼҲҪ��6֡Ŷ*/

        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.friendly = true;//�Ѻ�
            projectile.melee = false;//��ս
            projectile.ignoreWater = true;//����ˮӰ��
            projectile.tileCollide = false;//�ܴ�ǽ������Ϊfalse
            projectile.timeLeft = 1800;//����ʱ�䣬60��1��
            projectile.scale = 1f;//��С
            projectile.alpha = 140;//��С
            projectile.extraUpdates = (int)3f;

        }
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 4)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 3)
            {
                base.projectile.frame = 0;
            }
            if (Main.rand.Next(1, 3) == 1)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 15, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num].velocity *= 0.5f;
                Main.dust[num].noGravity = true;
            }
                int num1 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 172, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num1].velocity *= 0f;
                Main.dust[num1].noGravity = true;
            #region
            if (projectile.timeLeft == 710) { projectile.tileCollide = true; }//�������Ч����710��ʱ�����ܴ�ǽ
            projectile.light = 0.1f;//����//0Ϊ������
            Vector2 pc = projectile.position + new Vector2(projectile.width, projectile.height) / 2;//�������Ч������
            projectile.light = 0.1f;//����
            #endregion
            if (Main.rand.Next(2) == 0)
            {
                base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 2f);
                base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 2f);
            }
            else
            {
                base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 2f);
                base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 2f);
            }
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
            base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
            base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
            base.projectile.width = 160;
            base.projectile.height = 160;
            base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
            base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
        }
    }
}
