using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    // Token: 0x030007D0 RID: 3000
    public class FireWorkEx : ModProjectile
    {
        // Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("焰火Ex");
        }

        // Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
        public override void SetDefaults()
        {
            base.projectile.width = 4;
            base.projectile.height = 4;
            base.projectile.friendly = true;
            base.projectile.magic = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 5;
            base.projectile.timeLeft = 1000;
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
            if (base.projectile.timeLeft <= 997 && base.projectile.timeLeft > 300)
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
                int nm2 = Dust.NewDust(vk, 1, 1, 188, 0f, 0f, 201, default(Color), 5f);
                Main.dust[nm2].position = vk;
                Main.dust[nm2].noGravity = true;
            }
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            float num6 = (float)Main.rand.Next(0, 10000);
            float num7 = (float)Main.rand.Next((int)num6, 10000);
            float num3 = (float)Main.rand.Next((int)num7, 10000) / 10000;
            float num2 = (float)Main.rand.Next(0, 720) / 16f;
            int num8 = Main.rand.Next(-1000, 1000) / 100;
            double num9 = (double)Math.Sqrt(100 - (int)num8 * (int)num8);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num8, (float)num9)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num8, (float)num9);
            switch (Main.rand.Next(1, 46))
            {
                case 1:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 2:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 3:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 4:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 5:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 2) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            if (Main.rand.Next(0, 1) == 0)
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            }
                        }
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 6:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 8:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 9:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 10:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 11:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 12:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 13:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 14:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 15:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球紫"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 16:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球红变绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球红变绿"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 17:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球金"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球金"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 18:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球银"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球银"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 19:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球粉红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球粉红"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 20:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球金"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球银"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球金"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球银"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 21:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球粉红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 22:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 23:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 24:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球银闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球银闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 25:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 26:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 27:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球金闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球银闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球金闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球银闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 28:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球金闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a1 = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m1 = (float)Main.rand.Next(0, 50000);
                        float l1 = (float)Main.rand.Next((int)m1, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l1 * Math.Cos((float)a1)), (float)((float)l1 * Math.Sin((float)a1)), base.mod.ProjectileType("烟花火球金闪"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 29:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i < 23)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 30:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i < 23)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 31:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i < 23)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 32:
                    for (int i = 0; i < 46; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 23f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i % 2 == 1)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 33:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i < 15)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        if (i < 30)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 34:
                    for (int i = 0; i < 46; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 23f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i % 2 == 1)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 35:
                    for (int i = 0; i < 46; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 23f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i % 2 == 1)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 36:
                    for (int i = 0; i < 46; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 23f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i % 2 == 1)
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                    }
                    break;
                case 37:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 38:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 39:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 40:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 41:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球棕色尾迹2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 42:
                    for (int i = 0; i < 36; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 18f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                        Vector2 v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        if (num6 > 7000)
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        }
                        else
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 10000);
                        }
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 43:
                    for (int i = 0; i < 36; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 18f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                        Vector2 v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        if (num6 > 7000)
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        }
                        else
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 10000);
                        }
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球金闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 44:
                    for (int i = 0; i < 36; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 18f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                        Vector2 v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        if (num6 > 7000)
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 20000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 20000);
                        }
                        else
                        {
                            v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                            v3 = new Vector2(v1.X, v1.Y * (float)num6 / 10000);
                        }
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球红2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球绿3"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.mod.ProjectileType("烟花火球紫2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
                case 45:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num8, (float)num9, base.mod.ProjectileType("烟花火球银闪2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.mod.ProjectileType("烟花火球棕色尾迹"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                    break;
            }
        }
    }
}
