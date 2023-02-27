using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    // Token: 0x030007D0 RID: 3000
    public class FireWork : ModProjectile
    {
        // Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("焰火");
        }

        // Token: 0x06002BA1 RID: 11169 RVA: 0x00185 28 File Offset: 0x00183 28
        public override void SetDefaults()
        {
            base.projectile.width = 4;
            base.projectile.height = 4;
            base.projectile.friendly = true;
            base.projectile.magic = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 5;
            base.projectile.timeLeft = 800;
        }

        // Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
        public override void AI()
        {
            projectile.velocity.Y += 0.005f;
            base.projectile.localAI[1] += 1f;
            if (base.projectile.localAI[1] >= 21f && base.projectile.owner == Main.myPlayer)
            {
                base.projectile.localAI[1] = 0f;
            }
            base.projectile.localAI[0] += 1f;
            if (base.projectile.timeLeft <= 797)
            {
                if (base.projectile.localAI[0] > 9f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 vector = base.projectile.position;
                        vector -= base.projectile.velocity * (float)i * 0.25f;
                        base.projectile.alpha = 255;
                        int num1 = Dust.NewDust(vector, 1, 1, 55, 0f, 0f, 0, Color.Brown, 1.5f);
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
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
            float num6 = (float)Main.rand.Next(0, 10000);
            float num3 = (float)Main.rand.Next((int)num6, 10000) / 10000;
            float num2 = (float)Main.rand.Next(0, 720) / 16f;
            switch (Main.rand.Next(1, 7))
            {
                case 1:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 84; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 2:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 84; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 3:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 42; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 42; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 4:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 84; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 5:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 2) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            if (Main.rand.Next(0, 1) == 0)
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                        }
                    }
                    for (int j = 0; j < 28; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 28; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 28; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 6:
                    for (int k = 0; k < 21; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 21) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 21) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 84; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.72f, (float)((float)l * Math.Sin((float)a)) * 0.72f, base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
            }
        }
    }
}
