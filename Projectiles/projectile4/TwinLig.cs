using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
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
            DisplayName.SetDefault("魔眼闪电");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 11;
            projectile.penetrate = -1;
            projectile.scale = 1;
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
            if (projectile.timeLeft == 11)
            {
                Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 36, 1f, 0f);
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
            if (projectile.timeLeft == 10)
            {
            }
            if (projectile.timeLeft < 10)
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
                        Lighting.AddLight(vL[i],new Vector3(0.9f, 0, 0f) * 0.1f * projectile.timeLeft * (1 - i / (float)Max) + new Vector3(0f, 0.9f, 0f) * 0.1f * projectile.timeLeft * (i / (float)Max));
                    }
                }
            }
            Stre -= 0.090909091f;
        }
        public override void Kill(int timeLeft)
        {
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.timeLeft == 10 && !Main.gamePaused)
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
            if (!Main.gamePaused && projectile.timeLeft < 10)
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
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, base.mod.ProjectileType("Hit"), 65, 2f, Main.myPlayer, 0f, 0f);
                        projectile.position = player.Center;
                    }
                }
            }
        }
    }
}