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
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            //projectile.aiStyle = 54;
            Projectile.timeLeft = 120;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            //this.aiType = 317;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.scale = 0.3f;
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
            if (Projectile.velocity.Length() > 2f)
            {
                Projectile.velocity *= 0.95f;
            }
            Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.1f,0.1f));
            if(Projectile.timeLeft <= 40)
            {
                Projectile.scale = 0.3f * Projectile.timeLeft / 40f;
            }
            lig = 1;
            if (On == 0)
            {
                for(int l = 0;l < 1000;l++)
                {
                    if(Main.projectile[l].type == Mod.Find<ModProjectile>("GoldPosiDust").Type && (Main.projectile[l].Center - Projectile.Center).Length() > 15 && (Main.projectile[l].Center - Projectile.Center).Length() < 145 && Main.projectile[l].active)
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
                lig2 = (Main.projectile[lx].scale + Projectile.scale) * 0.5f;
            }
        }
        private double Alp = 0;
        private double Beta = 0;
        private float Leng = 1;
        private float Leng2 = 1;
        public override bool PreDraw(ref Color lightColor)
        {
            spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale, SpriteEffects.None, 0f);
            Texture2D texture = Mod.GetTexture("Projectiles/projectile3/星尘光标连线");
            Texture2D texture2 = Mod.GetTexture("Projectiles/projectile3/Haiyi");
            if(On > 0)
            {
                if(On > 20)
                {
                    if (On > 22)
                    {
                        spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, Projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Projectile.scale * 2f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, xi - Main.screenPosition, null, new Color(lig, lig, lig, 0), 0, new Vector2(25, 25), Main.projectile[lx].scale * 2f, SpriteEffects.None, 0f);
                        for (float k = 0; k < (Projectile.Center - xi).Length(); k++)
                        {
                            spriteBatch.Draw(texture, xi + (Projectile.Center - xi) / (Projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * lig2, lig * 0.2f * lig2, lig * lig2, 0), 0, new Vector2(1, 1), 2, SpriteEffects.None, 0f);
                        }
                        if (On == 23)
                        {
                            for (int i = 0; i < 200; i++)
                            {
                                if (!Main.npc[i].friendly && !Main.npc[i].dontTakeDamage && Main.npc[i].active)
                                {
                                    float a = (xi - Projectile.Center).Length();
                                    if (a < 2000)
                                    {
                                        float b = (xi - Main.npc[i].Center).Length();
                                        float c = (Projectile.Center - Main.npc[i].Center).Length();
                                        float x = (c * c + a * a - b * b) / (2 * a);
                                        if (c * c - x * x < Math.Sqrt(Main.npc[i].width * Main.npc[i].width + Main.npc[i].height * Main.npc[i].height) && (b * b + c * c - a * a) <= 0)
                                        {
                                            Main.npc[i].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.8f, 1.2f)) / 3 * 2, 0, (int)(Main.npc[i].velocity.X / Math.Abs(Main.npc[i].velocity.X)), false, false, false);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (float k = 0; k < (Projectile.Center - xi).Length(); k++)
                        {
                            spriteBatch.Draw(texture, xi + (Projectile.Center - xi) / (Projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * lig2, lig * 0.2f * lig2, lig * lig2, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
                        }
                    }
                }
                else
                {
                    for (float k = 0; k < (Projectile.Center - xi).Length(); k++)
                    {
                        spriteBatch.Draw(texture, xi + (Projectile.Center - xi) / (Projectile.Center - xi).Length() * k - Main.screenPosition, null, new Color(lig * 0.5f * On / 20f * lig2, lig * 0.2f * On / 20f * lig2, lig * On / 20f * lig2, 0), 0, new Vector2(1, 1), 1, SpriteEffects.None, 0f);
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
