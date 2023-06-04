using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class HaiyisSickle : ModProjectile
	{
		private float num4;
		private bool num5 = true;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("海伊的镰刀");
		}
		public override void SetDefaults()
		{
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            //projectile.aiStyle = 54;
            Projectile.timeLeft = 300;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            //this.aiType = 317;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.scale = 0.3f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig, lig, lig, 0));
        }
        private int zo = 300;
        private bool off = false;
        private bool Flag = false;
        private float lig = 0;
        private float pink = 0;
        public override void AI()
        {
            if(!off)
            {
                if(Projectile.timeLeft > 100)
                {
                    if (lig < 1)
                    {
                        lig += 0.03f;
                    }
                    else
                    {
                        lig = 1;
                    }
                }
                else
                {
                    lig -= 0.01f;
                }
            }
            if (off)
            {
                zo -= 1;
                if (zo < 0)
                {
                    lig -= 0.01f;
                    if (lig <= 0)
                    {
                        Projectile.Kill();
                    }
                }
            }
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                        Flag = true;
                        if(pink < 10f)
                        {
                            pink += num4 / 1000f;
                        }
                    }
                    else
                    {
                        Flag = false;
                        if (pink >= 0)
                        {
                            pink -= 0.1f;
                        }
                        else
                        {
                            pink = 0;
                        }
                    }
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(Projectile.damage, Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                        NPC target = Main.npc[j];
                    }
                }
            }
            if (flag)
            {
                float num8 = 50f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * ((Leng + 0.25f) * 20f) + num9) / ((Leng + 0.25f) * 21f);
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * ((Leng + 0.25f) * 20f) + num10) / ((Leng + 0.25f) * 21f);
                if(Projectile.velocity.Length() > 15f)
                {
                    Projectile.velocity *= 0.65f;
                }
                Projectile.velocity *= 0.65f;
            }
            if (Leng < 0.85f)
            {
                if(Projectile.timeLeft > 60)
                {
                    Vector2 vector = base.Projectile.Center;
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Haiyi").Type, 0, 0, 0, default(Color), 3f * (0.85f - Leng));
                    Main.dust[num].velocity *= 0.0f;
                    Main.dust[num].noGravity = true;
                    Main.dust[num].scale *= 1.2f;
                }
                else
                {
                    Vector2 vector = base.Projectile.Center;
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Haiyi").Type, 0, 0, 0, default(Color), 3f * (0.85f - Leng) * Projectile.timeLeft / 60f);
                    Main.dust[num].velocity *= 0.0f;
                    Main.dust[num].noGravity = true;
                    Main.dust[num].scale *= 1.2f;
                }
            }
            if(Leng < 0.1f)
            {
                Projectile.penetrate = 1;
            }
        }
        private double Alp = 0;
        private double Beta = 0;
        private float Leng = 1;
        private float Leng2 = 1;
        public override bool PreDraw(ref Color lightColor)
        {
            if(!Flag)
            {
                if(Leng < 1 + (float)Math.Sin(Projectile.timeLeft / 6f) / 15f)
                {
                    Leng += 0.02f;
                }
                else
                {
                    Leng = 1 + (float)Math.Sin(Projectile.timeLeft / 6f) / 15f;
                }
                Leng2 = 0;
            }
            else
            {
                if(Leng2 == 0)
                {
                    Leng2 = Leng;
                }
                if(Leng > 0.01f)
                {
                    Leng -= 0.01f;
                }
            }
            Alp += 0.15f;
            Beta += 0.05f;
            Vector3 v1 = new Vector3(27.863833229655f, 0, 34.980091448565f) * Leng;
            Vector3 v2 = new Vector3(-27.863833229655f, 0, 34.980091448565f) * Leng;
            Vector3 v3 = new Vector3(27.863833229655f, 0, -34.980091448565f) * Leng;
            Vector3 v4 = new Vector3(-27.863833229655f, 0, -34.980091448565f) * Leng;
            Vector3 v5 = new Vector3(0, 34.980091448565f, 27.863833229655f) * Leng;
            Vector3 v6 = new Vector3(0, -34.980091448565f, 27.863833229655f) * Leng;
            Vector3 v7 = new Vector3(0, 34.980091448565f, -27.863833229655f) * Leng;
            Vector3 v8 = new Vector3(0, -34.980091448565f, -27.863833229655f) * Leng;
            Vector3 v9 = new Vector3(34.980091448565f, 27.863833229655f, 0) * Leng;
            Vector3 v10 = new Vector3(-34.980091448565f, 27.863833229655f, 0) * Leng;
            Vector3 v11 = new Vector3(34.980091448565f, -27.863833229655f, 0) * Leng;
            Vector3 v12 = new Vector3(-34.980091448565f, -27.863833229655f, 0) * Leng;
            Vector2 v102 = new Vector2(v1.X + v1.Y * (float)Math.Cos(Alp) / 2f, -v1.Y * (float)Math.Sin(Alp) / 2f  + v1.Z).RotatedBy(Beta);
            Vector2 v202 = new Vector2(v2.X + v2.Y * (float)Math.Cos(Alp) / 2f, -v2.Y * (float)Math.Sin(Alp) / 2f  + v2.Z).RotatedBy(Beta);
            Vector2 v302 = new Vector2(v3.X + v3.Y * (float)Math.Cos(Alp) / 2f , -v3.Y * (float)Math.Sin(Alp) / 2f  + v3.Z).RotatedBy(Beta);
            Vector2 v402 = new Vector2(v4.X + v4.Y * (float)Math.Cos(Alp) / 2f , -v4.Y * (float)Math.Sin(Alp) / 2f  + v4.Z).RotatedBy(Beta);
            Vector2 v502 = new Vector2(v5.X + v5.Y * (float)Math.Cos(Alp) / 2f , -v5.Y * (float)Math.Sin(Alp) / 2f  + v5.Z).RotatedBy(Beta);
            Vector2 v602 = new Vector2(v6.X + v6.Y * (float)Math.Cos(Alp) / 2f , -v6.Y * (float)Math.Sin(Alp) / 2f  + v6.Z).RotatedBy(Beta);
            Vector2 v702 = new Vector2(v7.X + v7.Y * (float)Math.Cos(Alp) / 2f , -v7.Y * (float)Math.Sin(Alp) / 2f  + v7.Z).RotatedBy(Beta);
            Vector2 v802 = new Vector2(v8.X + v8.Y * (float)Math.Cos(Alp) / 2f , -v8.Y * (float)Math.Sin(Alp) / 2f  + v8.Z).RotatedBy(Beta);
            Vector2 v902 = new Vector2(v9.X + v9.Y * (float)Math.Cos(Alp) / 2f , -v9.Y * (float)Math.Sin(Alp) / 2f  + v9.Z).RotatedBy(Beta);
            Vector2 v1002 = new Vector2(v10.X + v10.Y * (float)Math.Cos(Alp) / 2f, -v10.Y * (float)Math.Sin(Alp) / 2f + v10.Z).RotatedBy(Beta);
            Vector2 v1102 = new Vector2(v11.X + v11.Y * (float)Math.Cos(Alp) / 2f, -v11.Y * (float)Math.Sin(Alp) / 2f + v11.Z).RotatedBy(Beta);
            Vector2 v1202 = new Vector2(v12.X + v12.Y * (float)Math.Cos(Alp) / 2f, -v12.Y * (float)Math.Sin(Alp) / 2f + v12.Z).RotatedBy(Beta);
            /*float Zm = -50 * Leng;
            Vector2 v102 = new Vector2(v1.X * Zm / (Zm - v1.Z), v1.Y * Zm / (Zm - v1.Z)).RotatedBy(Beta);
            Vector2 v202 = new Vector2(v2.X * Zm / (Zm - v2.Z), v2.Y * Zm / (Zm - v2.Z)).RotatedBy(Beta);
            Vector2 v302 = new Vector2(v3.X * Zm / (Zm - v3.Z), v3.Y * Zm / (Zm - v3.Z)).RotatedBy(Beta);
            Vector2 v402 = new Vector2(v4.X * Zm / (Zm - v4.Z), v4.Y * Zm / (Zm - v4.Z)).RotatedBy(Beta);
            Vector2 v502 = new Vector2(v5.X * Zm / (Zm - v5.Z), v5.Y * Zm / (Zm - v5.Z)).RotatedBy(Beta);
            Vector2 v602 = new Vector2(v6.X * Zm / (Zm - v6.Z), v6.Y * Zm / (Zm - v6.Z)).RotatedBy(Beta);
            Vector2 v702 = new Vector2(v7.X * Zm / (Zm - v7.Z), v7.Y * Zm / (Zm - v7.Z)).RotatedBy(Beta);
            Vector2 v802 = new Vector2(v8.X * Zm / (Zm - v8.Z), v8.Y * Zm / (Zm - v8.Z)).RotatedBy(Beta);
            Vector2 v902 = new Vector2(v9.X * Zm / (Zm - v9.Z), v9.Y * Zm / (Zm - v9.Z)).RotatedBy(Beta);
            Vector2 v1002 = new Vector2(v10.X * Zm / (Zm - v10.Z), v10.Y * Zm / (Zm - v10.Z)).RotatedBy(Beta);
            Vector2 v1102 = new Vector2(v11.X * Zm / (Zm - v11.Z), v11.Y * Zm / (Zm - v11.Z)).RotatedBy(Beta);
            Vector2 v1202 = new Vector2(v12.X * Zm / (Zm - v12.Z), v12.Y * Zm / (Zm - v12.Z)).RotatedBy(Beta);*/
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v102 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v202 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v302 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v402 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v502 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v602 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v702 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v802 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v902 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1002 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1102 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1202 + Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = Mod.GetTexture("Projectiles/projectile3/星尘光标连线");
            Texture2D texture2 = Mod.GetTexture("Projectiles/projectile3/Haiyi");
            //*1
            for (float k = 0;k < (v1102 - v302).Length();k++)
            {
                spriteBatch.Draw(texture, v1102 + (v302 - v1102) / (v302 - v1102).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1102 - v102).Length(); k++)
            {
                spriteBatch.Draw(texture, v1102 + (v102 - v1102) / (v102 - v1102).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1102 - v802).Length(); k++)
            {
                spriteBatch.Draw(texture, v1102 + (v802 - v1102) / (v802 - v1102).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1102 - v902).Length(); k++)
            {
                spriteBatch.Draw(texture, v1102 + (v902 - v1102) / (v902 - v1102).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1102 - v602).Length(); k++)
            {
                spriteBatch.Draw(texture, v1102 + (v602 - v1102) / (v1102 - v602).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            //*2
            for (float k = 0; k < (v1002 - v402).Length(); k++)
            {
                spriteBatch.Draw(texture, v1002 + (v402 - v1002) / (v402 - v1002).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1002 - v202).Length(); k++)
            {
                spriteBatch.Draw(texture, v1002 + (v202 - v1002) / (v202 - v1002).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1002 - v702).Length(); k++)
            {
                spriteBatch.Draw(texture, v1002 + (v702 - v1002) / (v702 - v1002).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1002 - v1202).Length(); k++)
            {
                spriteBatch.Draw(texture, v1002 + (v1202 - v1002) / (v1202 - v1002).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1002 - v502).Length(); k++)
            {
                spriteBatch.Draw(texture, v1002 + (v502 - v1002) / (v1002 - v502).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            //*3
            for (float k = 0; k < (v802 - v602).Length(); k++)
            {
                spriteBatch.Draw(texture, v802 + (v602 - v802) / (v602 - v802).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v602 - v102).Length(); k++)
            {
                spriteBatch.Draw(texture, v602 + (v102 - v602) / (v102 - v602).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v102 - v902).Length(); k++)
            {
                spriteBatch.Draw(texture, v102 + (v902 - v102) / (v902 - v102).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v902 - v302).Length(); k++)
            {
                spriteBatch.Draw(texture, v302 + (v902 - v302) / (v902 - v302).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v302 - v802).Length(); k++)
            {
                spriteBatch.Draw(texture, v302 + (v802 - v302) / (v802 - v302).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            //*4
            for (float k = 0; k < (v502 - v702).Length(); k++)
            {
                spriteBatch.Draw(texture, v502 + (v702 - v502) / (v702 - v502).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v702 - v402).Length(); k++)
            {
                spriteBatch.Draw(texture, v702 + (v402 - v702) / (v402 - v702).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v402 - v1202).Length(); k++)
            {
                spriteBatch.Draw(texture, v402 + (v1202 - v402) / (v1202 - v402).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1202 - v202).Length(); k++)
            {
                spriteBatch.Draw(texture, v1202 + (v202 - v1202) / (v202 - v1202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v202 - v502).Length(); k++)
            {
                spriteBatch.Draw(texture, v202 + (v502 - v202) / (v502 - v202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            //*5
            for (float k = 0; k < (v402 - v802).Length(); k++)
            {
                spriteBatch.Draw(texture, v402 + (v802 - v402) / (v802 - v402).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v402 - v302).Length(); k++)
            {
                spriteBatch.Draw(texture, v402 + (v302 - v402) / (v302 - v402).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v702 - v902).Length(); k++)
            {
                spriteBatch.Draw(texture, v702 + (v902 - v702) / (v902 - v702).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v702 - v302).Length(); k++)
            {
                spriteBatch.Draw(texture, v702 + (v302 - v702) / (v302 - v702).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v502 - v902).Length(); k++)
            {
                spriteBatch.Draw(texture, v502 + (v902 - v502) / (v902 - v502).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v502 - v102).Length(); k++)
            {
                spriteBatch.Draw(texture, v502 + (v102 - v502) / (v102 - v502).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v202 - v602).Length(); k++)
            {
                spriteBatch.Draw(texture, v202 + (v602 - v202) / (v602 - v202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v202 - v102).Length(); k++)
            {
                spriteBatch.Draw(texture, v202 + (v102 - v202) / (v102 - v202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1202 - v602).Length(); k++)
            {
                spriteBatch.Draw(texture, v1202 + (v602 - v1202) / (v602 - v1202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            for (float k = 0; k < (v1202 - v802).Length(); k++)
            {
                spriteBatch.Draw(texture, v1202 + (v802 - v1202) / (v802 - v1202).Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.5f, lig * 0.2f, lig, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
            }
            //*6
            if(pink > 0)
            {
                Vector2 v0 = new Vector2(0, 0);
                for (float k = 0; k < (v0 - v102).Length(); k++)
                {
                    spriteBatch.Draw(texture, v102 / v102.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v102).Length() - k) / (v0 - v102).Length() * pink, lig * 0.2f * ((v0 - v102).Length() - k) / (v0 - v102).Length(), lig * 0.2f * k / (v0 - v102).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v202).Length(); k++)
                {
                    spriteBatch.Draw(texture, v202 / v202.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v202).Length() - k) / (v0 - v202).Length() * pink, lig * 0.2f * ((v0 - v202).Length() - k) / (v0 - v202).Length(), lig * 0.2f * k / (v0 - v202).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v302).Length(); k++)
                {
                    spriteBatch.Draw(texture, v302 / v302.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v302).Length() - k) / (v0 - v302).Length() * pink, lig * 0.2f * ((v0 - v302).Length() - k) / (v0 - v302).Length(), lig * 0.2f * k / (v0 - v302).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v402).Length(); k++)
                {
                    spriteBatch.Draw(texture, v402 / v402.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v402).Length() - k) / (v0 - v402).Length() * pink, lig * 0.2f * ((v0 - v402).Length() - k) / (v0 - v402).Length(), lig * 0.2f * k / (v0 - v402).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v502).Length(); k++)
                {
                    spriteBatch.Draw(texture, v502 / v502.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v502).Length() - k) / (v0 - v502).Length() * pink, lig * 0.2f * ((v0 - v502).Length() - k) / (v0 - v502).Length(), lig * 0.2f * k / (v0 - v502).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v602).Length(); k++)
                {
                    spriteBatch.Draw(texture, v602 / v602.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v602).Length() - k) / (v0 - v602).Length() * pink, lig * 0.2f * ((v0 - v602).Length() - k) / (v0 - v602).Length(), lig * 0.2f * k / (v0 - v602).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v702).Length(); k++)
                {
                    spriteBatch.Draw(texture, v702 / v702.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v702).Length() - k) / (v0 - v702).Length() * pink, lig * 0.2f * ((v0 - v702).Length() - k) / (v0 - v702).Length(), lig * 0.2f * k / (v0 - v702).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v802).Length(); k++)
                {
                    spriteBatch.Draw(texture, v802 / v802.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v802).Length() - k) / (v0 - v802).Length() * pink, lig * 0.2f * ((v0 - v802).Length() - k) / (v0 - v802).Length(), lig * 0.2f * k / (v0 - v802).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v902).Length(); k++)
                {
                    spriteBatch.Draw(texture, v902 / v902.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v902).Length() - k) / (v0 - v902).Length() * pink, lig * 0.2f * ((v0 - v902).Length() - k) / (v0 - v902).Length(), lig * 0.2f * k / (v0 - v902).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v1002).Length(); k++)
                {
                    spriteBatch.Draw(texture, v1002 / v1002.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v1002).Length() - k) / (v0 - v1002).Length() * pink, lig * 0.2f * ((v0 - v1002).Length() - k) / (v0 - v1002).Length(), lig * 0.2f * k / (v0 - v1002).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v1102).Length(); k++)
                {
                    spriteBatch.Draw(texture, v1102 / v1102.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v1102).Length() - k) / (v0 - v1102).Length() * pink, lig * 0.2f * ((v0 - v1102).Length() - k) / (v0 - v1102).Length(), lig * 0.2f * k / (v0 - v1102).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
                for (float k = 0; k < (v0 - v1202).Length(); k++)
                {
                    spriteBatch.Draw(texture, v1202 / v1202.Length() * k + Projectile.Center - Main.screenPosition, null, new Color(lig * 0.9f * ((v0 - v1202).Length() - k) / (v0 - v1202).Length() * pink, lig * 0.2f * ((v0 - v1202).Length() - k) / (v0 - v1202).Length(), lig * 0.2f * k / (v0 - v1202).Length(), 0), 0, new Vector2(1, 1), 2.5f / (k / 3f + 3) + 0.5f, SpriteEffects.None, 0f);
                }
            }

            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.36f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
                base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
                base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
                base.Projectile.width = 40;
                base.Projectile.height = 40;
                base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
                base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
                for (int j = 0; j < 90; j++)
                {
                    int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Haiyi").Type, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num2].velocity.X = (float)(1f * Math.Sin(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.9f, 1.1f);
                    Main.dust[num2].velocity.Y = (float)(1f * Math.Cos(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.9f, 1.1f);
                }
                for (int j = 0; j < 200; j++)
                {
                    if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - Projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                    {
                        Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - Projectile.Center).Length(), (int)((Main.npc[j].Center.X - Projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - Projectile.Center.X)));
                    }
                }
            }
        }
    }
}
