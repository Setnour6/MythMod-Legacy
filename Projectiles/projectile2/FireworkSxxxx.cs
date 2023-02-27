using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class FireworkSxxxx : ModProjectile
	{
        private bool x = true;
        private float i2 = 0;
        private float j2 = 0;
        public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("焰火");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 5;
			base.projectile.timeLeft = 750;
		}
		public override void AI()
		{
            if(x)
            {
                i2 = projectile.Center.X;
                j2 = projectile.Center.Y;
                x = false;
            }
            Player player = Main.player[Main.myPlayer];
            projectile.velocity.Y += 0.005f;
			base.projectile.localAI[1] += 1f;
			if (base.projectile.localAI[1] >= 21f && base.projectile.owner == Main.myPlayer)
			{
				base.projectile.localAI[1] = 0f;
			}
			base.projectile.localAI[0] += 1f;
			if(base.projectile.timeLeft <= 997 && base.projectile.timeLeft > 300)
			{
                if (base.projectile.localAI[0] > 9f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 vector = base.projectile.position;
                        vector -= base.projectile.velocity * (float)i * 0.25f;
                        base.projectile.alpha = 255;
                        int num1 = Dust.NewDust(vector, 1, 1, 55, 0f, 0f, 0, Color.Brown, 2f);
                        Main.dust[num1].position = vector;
                        Main.dust[num1].scale *= 0.95f;
                        Main.dust[num1].velocity *= 0f;
                        Main.dust[num1].velocity.Y = 0f;
                        Main.dust[num1].alpha = 160;
                        Main.dust[num1].noGravity = true;
                        int num = Dust.NewDust(vector, 1, 1, 156, 0f, 0f, 0, default(Color), 7f);
                        Main.dust[num].position = vector;
                        Main.dust[num].scale *= 0.1f;
                        Main.dust[num].velocity *= 0f;
                        Main.dust[num].noGravity = true;
                    }
                    Vector2 vect = base.projectile.position;
                    int num2 = Dust.NewDust(vect, 1, 1, 188, 0f, 0f, 201, default(Color), 4f);
                    Main.dust[num2].velocity *= 0f;
                    Main.dust[num2].position = vect;
                    Main.dust[num2].noGravity = true;
                }
            }
            if (base.projectile.timeLeft == 650)
            {
                Main.PlaySound(2, (int)i2, (int)j2, 14, 1f, 0f);
                Projectile.NewProjectile(i2, j2, Main.rand.Next(-1000, 1000) / 10000f, -4.17f, base.mod.ProjectileType("FireworkSxxx"), 400, 110, Main.myPlayer, 20f, 0f);
                for (int k = 0; k < 35; k++)
                {
                    int num7 = Main.rand.Next(0, 100000);
                    int num8 = Main.rand.Next(0, (int)num7) / 10000;
                    int num6 = Dust.NewDust(new Vector2(i2, j2), 4, 4, 174, 0, -5 * (float)num8, 0, Color.Orange, 1.6f);
                    Main.dust[num6].noGravity = false;
                    Main.dust[num6].scale *= 0.8f;
                    Main.dust[num6].alpha = 200;
                    break;
                }
            }
            if (base.projectile.timeLeft < 300 && base.projectile.timeLeft > 1)
			{
                for (int i = 0; i < 3; i++)
				{
					Vector2 vector = base.projectile.position;
					vector -= base.projectile.velocity * (float)i * 0.25f;
					base.projectile.alpha = 255;
			        int num1 = Dust.NewDust(vector, 1, 1, 55, 0f, 0f, 0, Color.Brown, 2f * (int)(base.projectile.timeLeft + 1) / 300);
                    Main.dust[num1].position = vector;
                    Main.dust[num1].scale *= 0.95f;
                    Main.dust[num1].velocity *= 0f;
				    Main.dust[num1].velocity.Y = 0f;
				    Main.dust[num1].alpha = 160;
                    Main.dust[num1].noGravity = true;
					int num = Dust.NewDust(vector, 1, 1, 156, 0f, 0f, 0, default(Color), 7f * (int)(base.projectile.timeLeft + 1) / 300);
					Main.dust[num].position = vector;
					Main.dust[num].scale *= 0.1f;
                    Main.dust[num].velocity *= 0f;
                    Main.dust[num].noGravity = true;
                }
                Vector2 vect = base.projectile.position;
                int num2 = Dust.NewDust(vect, 1, 1, 188, 0f, 0f, 201, default(Color), 4f);
                Main.dust[num2].velocity *= 0f;
                Main.dust[num2].position = vect;
                Main.dust[num2].noGravity = true;
            }
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Vector2 vk = base.projectile.Center;
                int nm2 = Dust.NewDust(vk, 1, 1, 188, 0f, 0f, 201, default(Color), 2f);
                Main.dust[nm2].position = vk;
                Main.dust[nm2].noGravity = true;
            }
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("FireworkBomb"), 0, 0, base.projectile.owner, 0f, 0f);
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            float num6 = (float)Main.rand.Next(0, 10000);
            float num7 = (float)Main.rand.Next((int)num6, 10000);
            float num3 = (float)Main.rand.Next((int)num7, 10000) / 10000;
            float num2 = (float)Main.rand.Next(0, 720) / 16f;
            int num8 = Main.rand.Next(-1000, 1000) / 100;
            double num9 = (double)Math.Sqrt(100 - (int)num8 * (int)num8);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num8, (float)num9)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num8, (float)num9);
            switch (Main.rand.Next(1, 11))
            {
                case 1:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 80; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 2:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 80; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 3:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 4:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkPurple"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 80; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkPurple"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 5:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 2) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkPurple"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            if (Main.rand.Next(0, 1) == 0)
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                        }
                    }
                    for (int j = 0; j < 13; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkPurple"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 14; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkGreen"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 13; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkRed"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 6:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 1.4f, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 1.4f, base.mod.ProjectileType("FireworkBrownTrade"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 80; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.7f, (float)((float)l * Math.Sin((float)a)) * 0.7f, base.mod.ProjectileType("FireworkBrownTrade"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 20; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 10f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8 * 0.7f, (float)num9 * 0.7f, base.mod.ProjectileType("FireworkBrownTrade2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000f));
                    }
                    break;
                case 8:
                    for (int i = 0; i < 20; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 10f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8 * 0.7f, (float)num9 * 0.7f, base.mod.ProjectileType("FireworkRed2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000f));
                    }
                    break;
                case 9:
                    for (int i = 0; i < 20; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 10f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8 * 0.7f, (float)num9 * 0.7f, base.mod.ProjectileType("FireworkGreen3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000f));
                    }
                    break;
                case 10:
                    for (int i = 0; i < 20; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 10f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("FireworkPurple2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
            }
        }
    }
}
