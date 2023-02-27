using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class GoldPosiDust : ModProjectile
	{
		private float num4;
		private bool num5 = true;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("金相");
		}
		public override void SetDefaults()
		{
            projectile.width = 50;
            projectile.height = 50;
            projectile.netImportant = true;
            projectile.friendly = true;
            //projectile.aiStyle = 54;
            projectile.timeLeft = 120;
            projectile.penetrate = -1;
            projectile.melee = true;
            //this.aiType = 317;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.scale = 0.3f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig,lig,lig, 0));
        }
        private float lig = 0;
        private float lig2 = 0;
        private int On = 0;
        private int lx = 0;
        private Vector2 xi = new Vector2(0,0);
        public override void AI()
        {
            if (projectile.velocity.Length() > 2f)
            {
                projectile.velocity *= 0.95f;
            }
            projectile.velocity = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.1f,0.1f));
            if(projectile.timeLeft <= 40)
            {
                projectile.scale = 0.3f * projectile.timeLeft / 40f;
            }
            lig = 1;
            if (On == 0)
            {
                for(int l = 0;l < 1000;l++)
                {
                    if(Main.projectile[l].type == mod.ProjectileType("GoldPosiDust") && (Main.projectile[l].Center - projectile.Center).Length() > 15 && (Main.projectile[l].Center - projectile.Center).Length() < 145 && Main.projectile[l].active)
                    {
                        if(Main.rand.Next(200) == 1)
                        {
                            xi = Main.projectile[l].Center;
                            lx = l;
                            On = 24;
                            break;
                        }
                    }
                }
            }
            if(Main.projectile[lx].active && lx != 0 && On > 0)
            {
                xi = Main.projectile[lx].Center;
                lig2 = (Main.projectile[lx].scale + projectile.scale) * 0.5f;
            }
        }
        private double Alp = 0;
        private double Beta = 0;
        private float Leng = 1;
        private float Leng2 = 1;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = mod.GetTexture("Projectiles/projectile3/星尘光标连线");
            Texture2D texture2 = mod.GetTexture("Projectiles/projectile3/Haiyi");
            if(On > 0)
            {
                if(On > 20)
                {
                    if (On > 22)
                    {
                        spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), projectile.scale * 2f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(Main.projectileTexture[projectile.type], xi - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Main.projectile[lx].scale * 2f, SpriteEffects.None, 0f);
                        for (float k = 0; k < (projectile.Center - xi).Length(); k++)
                        {
                            spriteBatch.Draw(texture, xi + (projectile.Center - xi) / (projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * lig2, lig * 0.2f * lig2, lig * lig2, 0), 0, new Vector2(1, 1), 2, SpriteEffects.None, 0f);
                        }
                        if (On == 23)
                        {
                            for (int i = 0; i < 200; i++)
                            {
                                if (!Main.npc[i].friendly && !Main.npc[i].dontTakeDamage && Main.npc[i].active)
                                {
                                    float a = (xi - projectile.Center).Length();
                                    if (a < 2000)
                                    {
                                        float b = (xi - Main.npc[i].Center).Length();
                                        float c = (projectile.Center - Main.npc[i].Center).Length();
                                        float x = (c * c + a * a - b * b) / (2 * a);
                                        if (c * c - x * x < Math.Sqrt(Main.npc[i].width * Main.npc[i].width + Main.npc[i].height * Main.npc[i].height) && (b * b + c * c - a * a) <= 0)
                                        {
                                            Main.npc[i].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.8f, 1.2f)) / 3 * 2, 0, (int)(Main.npc[i].velocity.X / Math.Abs(Main.npc[i].velocity.X)), false, false, false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (float k = 0; k < (projectile.Center - xi).Length(); k++)
                        {
                            spriteBatch.Draw(texture, xi + (projectile.Center - xi) / (projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * lig2, lig * 0.2f * lig2, lig * lig2, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
                        }
                    }
                }
                else
                {
                    for (float k = 0; k < (projectile.Center - xi).Length(); k++)
                    {
                        spriteBatch.Draw(texture, xi + (projectile.Center - xi) / (projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * On / 20f * lig2, lig * 0.2f * On / 20f * lig2, lig * On / 20f * lig2, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
                    }
                }
                On--;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 0.36f, 0f);
                base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
                base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
                base.projectile.width = 40;
                base.projectile.height = 40;
                base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
                base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
                for (int j = 0; j < 90; j++)
                {
                    int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y), 0, 0, mod.DustType("Haiyi"), 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num2].velocity.X = (float)(1f * Math.Sin(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.9f, 1.1f);
                    Main.dust[num2].velocity.Y = (float)(1f * Math.Cos(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.9f, 1.1f);
                }
                for (int j = 0; j < 200; j++)
                {
                    if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                    {
                        Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - projectile.Center).Length(), (int)((Main.npc[j].Center.X - projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - projectile.Center.X)));
                    }
                }
            }
        }
    }
}
