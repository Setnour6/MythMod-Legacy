using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using TemplateMod2.Utils;
using Terraria.Localization;
using Terraria.Graphics.Capture;

namespace MythMod.Projectiles.projectile4
{
    public class TwinLig : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("魔眼闪电");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 11;
            Projectile.penetrate = -1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float Stre = 1f;
        private float K = 10;
        private Vector2[] vL = new Vector2[2050];

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 0, 0, 0));
        }
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (Projectile.timeLeft == 11)
            {
                SoundEngine.PlaySound(SoundID.Item36, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
                vL[0] = mplayer.LaserV[0];
                int K = 0;
                for (int i = 1; i < 1000; i++)
                {
                    if(mplayer.LaserV[i] != Vector2.Zero)
                    {
                        vL[i] = mplayer.LaserV[i];
                        K = i;
                    }
                    else
                    {
                        break;
                    }
                }
                int M = 0;
                for (int i = 999; i > -1; i--)
                {
                    if (mplayer.CurseV[i] != Vector2.Zero)
                    {
                        M += 1;
                        vL[K + M] = mplayer.CurseV[i];
                    }
                }
            }
            if (Projectile.timeLeft == 10)
            {
            }
            if (Projectile.timeLeft < 10)
            {
                int Max = 1;
                for (int i = 0; i < 1999; ++i)
                {
                    if (vL[i + 1] == Vector2.Zero)
                    {
                        Max = i + 1;
                        break;
                    }
                }
                for (int i = 1; i < 1999; i++)
                {
                    if (vL[i] != Vector2.Zero)
                    {
                        vL[i] += new Vector2(0,Main.rand.NextFloat(0,2f)).RotatedByRandom(Math.PI * 2);
                        Lighting.AddLight(vL[i],new Vector3(0.9f, 0, 0f) * 0.1f * Projectile.timeLeft * (1 - i / (float)Max) + new Vector3(0f, 0.9f, 0f) * 0.1f * Projectile.timeLeft * (i / (float)Max));
                    }
                }
            }
            Stre -= 0.090909091f;
        }
        public override void Kill(int timeLeft)
        {
        }
        public override void PostDraw(Color lightColor)
        {
            if (Projectile.timeLeft == 10 && !Main.gamePaused)
            {
                int Max = 1;
                for (int i = 0; i < 1999; ++i)
                {
                    if (vL[i + 1] == Vector2.Zero)
                    {
                        Max = i + 1;
                        break;
                    }
                }
                for (int i = 0; i < 1999; ++i)
                {
                    if (vL[i + 1] == Vector2.Zero)
                    {
                        break;
                    }
                    Vector2 v = vL[i + 1] - vL[i];
                    Vector2 v2 = v / v.Length();
                    for (float j = 0; j < v.Length(); j += 0.3f)
                    {
                        if (Main.rand.Next(-500, 500) > (float)((i - (float)Max / 2) / (float)Max * 3000))
                        {
                            int n = Dust.NewDust(vL[i] + v2 * j, 0, 0, 183, 0, 0, 0, default(Color), 1.7f);
                            Main.dust[n].noGravity = true;
                            Main.dust[n].velocity *= 0;
                        }
                        else
                        {
                            int n = Dust.NewDust(vL[i] + v2 * j, 0, 0, 75, 0, 0, 0, default(Color), 3f);
                            Main.dust[n].noGravity = true;
                            Main.dust[n].velocity *= 0;
                            Main.dust[n].noLight = true;
                        }
                    }
                }
            }
            if (!Main.gamePaused && Projectile.timeLeft < 10)
            {
                Player player = Main.player[Main.myPlayer];
                for (int i = 0; i < 1999; ++i)
                {
                    if (vL[i + 1] == Vector2.Zero)
                    {
                        break;
                    }
                    if((player.Center - vL[i]).Length() < 10)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("Hit").Type, 65, 2f, Main.myPlayer, 0f, 0f);
                        Projectile.position = player.Center;
                    }
                }
            }
        }
    }
}