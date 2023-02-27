using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x030007D0 RID: 3000
    public class FireworkExxx : ModProjectile
	{
        private bool x = true;
        private float i2 = 0;
        private float j2 = 0;
        // Token: 0x06002BA0 RID: 11168 RVA: 0x0000C67F File Offset: 0x0000A87F
        public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("焰火");
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00185D40 File Offset: 0x00183F40
		public override void SetDefaults()
		{
			base.Projectile.width = 4;
			base.Projectile.height = 4;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = 1;
			base.Projectile.extraUpdates = 5;
			base.Projectile.timeLeft = 1000;
		}

		// Token: 0x06002BA2 RID: 11170 RVA: 0x00229C74 File Offset: 0x00227E74
		public override void AI()
		{
            if(x)
            {
                i2 = Projectile.Center.X;
                j2 = Projectile.Center.Y;
                x = false;
            }
            Player player = Main.player[Main.myPlayer];
            Main.player[Main.myPlayer].GetModPlayer<MythPlayer>().FlyCamPosition = Projectile.Center - player.Center;
            Projectile.velocity.Y += 0.005f;
			base.Projectile.localAI[1] += 1f;
			if (base.Projectile.localAI[1] >= 21f && base.Projectile.owner == Main.myPlayer)
			{
				base.Projectile.localAI[1] = 0f;
			}
			base.Projectile.localAI[0] += 1f;
			if(base.Projectile.timeLeft <= 997 && base.Projectile.timeLeft > 300)
			{
                if (base.Projectile.localAI[0] > 9f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 vector = base.Projectile.position;
                        vector -= base.Projectile.velocity * (float)i * 0.25f;
                        base.Projectile.alpha = 255;
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
                    Vector2 vect = base.Projectile.position;
                    int num2 = Dust.NewDust(vect, 1, 1, 188, 0f, 0f, 201, default(Color), 4f);
                    Main.dust[num2].velocity *= 0f;
                    Main.dust[num2].position = vect;
                    Main.dust[num2].noGravity = true;
                }
            }
            if(base.Projectile.timeLeft < 300 && base.Projectile.timeLeft > 1)
			{
                for (int i = 0; i < 3; i++)
				{
					Vector2 vector = base.Projectile.position;
					vector -= base.Projectile.velocity * (float)i * 0.25f;
					base.Projectile.alpha = 255;
			        int num1 = Dust.NewDust(vector, 1, 1, 55, 0f, 0f, 0, Color.Brown, 2f * (int)(base.Projectile.timeLeft + 1) / 300);
                    Main.dust[num1].position = vector;
                    Main.dust[num1].scale *= 0.95f;
                    Main.dust[num1].velocity *= 0f;
				    Main.dust[num1].velocity.Y = 0f;
				    Main.dust[num1].alpha = 160;
                    Main.dust[num1].noGravity = true;
					int num = Dust.NewDust(vector, 1, 1, 156, 0f, 0f, 0, default(Color), 7f * (int)(base.Projectile.timeLeft + 1) / 300);
					Main.dust[num].position = vector;
					Main.dust[num].scale *= 0.1f;
                    Main.dust[num].velocity *= 0f;
                    Main.dust[num].noGravity = true;
                }
                Vector2 vect = base.Projectile.position;
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
                Vector2 vk = base.Projectile.Center;
                int nm2 = Dust.NewDust(vk, 1, 1, 188, 0f, 0f, 201, default(Color), 5f);
                Main.dust[nm2].position = vk;
                Main.dust[nm2].noGravity = true;
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("烟花滞留").Type, 0, 0, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("烟花爆炸").Type, 0, 0, base.Projectile.owner, 0f, 0f);
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            float num6 = (float)Main.rand.Next(0 , 10000);
			float num7 = (float)Main.rand.Next((int)num6 , 10000);
			float num3 = (float)Main.rand.Next((int)num7 , 10000) / 10000;
			float num2 = (float)Main.rand.Next(0 , 720) / 16f;
            int num8 = Main.rand.Next(-1000 , 1000) / 100;
			double num9 = (double)Math.Sqrt(100 - (int)num8 * (int)num8);
			Vector2 v1 = Vector2.Normalize(new Vector2((float)num8,(float)num9)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num8,(float)num9);
            switch (Main.rand.Next(1, 121))
            {
                case 1:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 2:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 3:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 4:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 5:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 2) == 0)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            if (Main.rand.Next(0, 1) == 0)
                            {
                                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            }
                        }
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 6:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 8:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 9:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 10:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 11:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 12:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 13:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 14:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 15:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 16:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedToGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedToGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 17:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGold").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGold").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 18:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSilver").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilver").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 19:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPink").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPink").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 20:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 1) == 0)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGold").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSilver").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGold").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilver").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 21:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPink2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 22:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGold2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 23:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilver2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 24:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 25:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 26:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 28:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a1 = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m1 = (float)Main.rand.Next(0, 50000);
                        float l1 = (float)Main.rand.Next((int)m1, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l1 * Math.Cos((float)a1)), (float)((float)l1 * Math.Sin((float)a1)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 29:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        if (i < 23)
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        if (i < 30)
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                            Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        }
                        else
                        {
                            int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 38:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 39:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 40:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 0.5f;
                        Main.projectile[q].scale = (0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000))) * 0.8f;
                    }
                    break;
                case 41:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                        int q = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[q].velocity = v3.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[q].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.X, -v1.Y) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 36; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, ((float)0 - (float)Math.Cos((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 36) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 45:
                    for (int i = 0; i < 40; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 20f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSilverShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 46:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 47:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 48:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 49:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreenGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 50:
                    for (int j = 0; j < 50; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 51:
                    for (int i = 0; i < 25; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 12.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 52:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int r = 0; r < 20; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 53:
                    for (int i = 0; i < 48; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = 0;
                        if (i % 8 >= 5)
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 54:
                    for (int i = 0; i < 48; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 24f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = 0;
                        if (i % 8 >= 5)
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreen3").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 55:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 56:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 57:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 58:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(100) > 7)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }

                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        if (Main.rand.Next(100) > 5)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    break;
                case 59:
                    for (int k = 0; k < 20; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 20) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 20) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 90; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 60:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(100) > 7)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }

                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        if (Main.rand.Next(100) > 5)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    break;
                case 61:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSliverMeteor2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 62:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSliverMeteor2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 17000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 63:
                    for (int j = 0; j < 50; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 64:
                    for (int j = 0; j < 25; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 25; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 65:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 66:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(0, 2) == 0)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            if (Main.rand.Next(0, 1) == 0)
                            {
                                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            }
                            else
                            {
                                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                            }
                        }
                    }
                    for (int j = 0; j < 36; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 36; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 36; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 12; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 67:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSliverMeteor2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 68:
                    for (int i = 0; i < 30; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 15f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8 * 0.8f, (float)num9 * 0.8f, base.Mod.Find<ModProjectile>("FireworkGreenBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 69:
                    for (int j = 0; j < 20; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 20; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 70:
                    for (int k = 0; k < 10; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 10) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 10) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 45; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 71:
                    for (int j = 0; j < 50; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 72:
                    for (int j = 0; j < 25; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 25; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 73:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 74:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 75:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 76:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 77:
                    for (int j = 0; j < 40; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteorBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 78:
                    for (int k = 0; k < 10; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 10) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 10) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 45; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 79:
                    for (int k = 0; k < 10; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 10) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 10) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 45; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 80:
                    for (int k = 0; k < 10; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 10) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 10) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGold粉尾迹").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 45; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 81:
                    for (int i = 0; i < 48; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000f, v1.Y);
                        int p = 0;
                        if (i % 8 >= 5)
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkRedBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 82:
                    for (int i = 0; i < 48; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = 0;
                        if (i % 8 >= 5)
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGoldShine2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 83:
                    for (int i = 0; i < 48; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = 0;
                        if (i % 8 >= 5)
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkGreenBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 84:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreenGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 85:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 86:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 87:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 88:
                    for (int i = 0; i < 30; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 15f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8 * 0.8f, (float)num9 * 0.8f, base.Mod.Find<ModProjectile>("FireworkRedBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    break;
                case 89:
                    for (int i = 0; i < 30; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 15f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8 * 0.8f, (float)num9 * 0.8f, base.Mod.Find<ModProjectile>("FireworkRedBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 90:
                    for (int i = 0; i < 30; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 15f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8 * 0.8f, (float)num9 * 0.8f, base.Mod.Find<ModProjectile>("FireworkRedBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 91:
                    for (int i = 0; i < 30; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 15f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8 * 0.8f, (float)num9 * 0.8f, base.Mod.Find<ModProjectile>("FireworkGreenBreak2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 92:
                    for (int k = 0; k < 10; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 10) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 10) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 45; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 93:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 94:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 95:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 96:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 97:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSilverShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 98:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 99:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 100:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 101:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 102:
                    for (int i = 0; i < 14; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 7f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkSunflower2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 103:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 104:
                    for (int i = 0; i < 45; i++)
                    {
                        v1 = v1.RotatedBy(Math.PI / 22.5f);
                        Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                        int p = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num8, (float)num9, base.Mod.Find<ModProjectile>("FireworkBrownTrade2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Main.projectile[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9));
                        Main.projectile[p].scale = 0.3f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num6 / 2000));
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 105:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 106:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 107:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldShine").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 108:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 109:
                    float num2001 = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (k >= 15)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2001) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2001) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2001) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2001) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    float num2000 = Main.rand.Next(0, Main.rand.Next(5000, 10000)) / 10000f;
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Vector2 v = new Vector2((float)(l * Math.Cos(a)), (float)(l * Math.Sin(a)));
                        if (v.Y > 0 && v.Y >= 5 * Math.Sin(a) * num2000)
                        {
                            v.Y *= -1;
                        }
                        v = v.RotatedBy(num2001);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v.X, -v.Y, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 110:
                    float num2002 = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (k >= 15)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2002) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2002) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2002) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2002) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    float num2003 = Main.rand.Next(0, Main.rand.Next(5000, 10000)) / 10000f;
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Vector2 v = new Vector2((float)(l * Math.Cos(a)), (float)(l * Math.Sin(a)));
                        if (v.Y > 0 && v.Y >= 5 * Math.Sin(a) * num2003)
                        {
                            v.Y *= -1;
                        }
                        v = v.RotatedBy(num2002);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v.X, -v.Y, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("FireworkBrownTrade").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 111:
                    float num2004 = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (k >= 15)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2004) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2004) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2004) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2004) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    float num2005 = Main.rand.Next(0, Main.rand.Next(5000, 10000)) / 10000f;
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Vector2 v = new Vector2((float)(l * Math.Cos(a)), (float)(l * Math.Sin(a)));
                        if (v.Y > 0 && v.Y >= 5 * Math.Sin(a) * num2005)
                        {
                            v.Y *= -1;
                        }
                        v = v.RotatedBy(num2004);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v.X, -v.Y, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 112:
                    float num2006 = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (k >= 15)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2006) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2006) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2006) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2006) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    float num2007 = Main.rand.Next(0, Main.rand.Next(5000, 10000)) / 10000f;
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Vector2 v = new Vector2((float)(l * Math.Cos(a)), (float)(l * Math.Sin(a)));
                        if (v.Y > 0 && v.Y >= 5 * Math.Sin(a) * num2007)
                        {
                            v.Y *= -1;
                        }
                        v = v.RotatedBy(num2006);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v.X, -v.Y, base.Mod.Find<ModProjectile>("FireworkGreen").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 113:
                    float num2008 = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (k >= 15)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2008) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2008) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f - num2008) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f - num2008) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    float num2009 = Main.rand.Next(0, Main.rand.Next(5000, 10000)) / 10000f;
                    for (int j = 0; j < 60; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Vector2 v = new Vector2((float)(l * Math.Cos(a)), (float)(l * Math.Sin(a)));
                        if (v.Y > 0 && v.Y >= 5 * Math.Sin(a) * num2009)
                        {
                            v.Y *= -1;
                        }
                        v = v.RotatedBy(num2008);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v.X, -v.Y, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 114:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(100) > 7)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }

                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        if (Main.rand.Next(100) > 5)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    break;
                case 115:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(100) > 7)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }

                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        if (Main.rand.Next(100) > 5)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGoldSand").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 116:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        if (Main.rand.Next(100) > 7)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }

                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        if (Main.rand.Next(100) > 5)
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                        else
                        {
                            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                        }
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 117:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkGreenBreak").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 118:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRed").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 119:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkSliverMeteor").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
                case 120:
                    for (int k = 0; k < 30; k++)
                    {
                        float i = k + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 2, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 2, base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int j = 0; j < 120; j++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 10000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkPurple").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int s = 0; s < 12; s++)
                    {
                        float t = s + 0.5f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos((2 * (float)t / 12) * 3.14159265358979f) * 2, (float)(0 - (float)Math.Sin((2 * (float)t / 12) * 3.14159265358979f)) * 2, base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    for (int r = 0; r < 40; r++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 27000f;
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)), (float)((float)l * Math.Sin((float)a)), base.Mod.Find<ModProjectile>("FireworkRedFly").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    }
                    break;
            }
        }
	}
}
