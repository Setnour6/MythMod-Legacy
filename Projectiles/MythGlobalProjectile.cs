using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using MythMod;

namespace MythMod.Projectiles
{

    public class MythModGlobalProjectile : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            /*if ((projectile.timeLeft / projectile.extraUpdates) % 4 == 0 && projectile.ranged && projectile.ai[1] == 2475.18392f && projectile.active)
            {
                Vector2 v = projectile.velocity.RotatedBy(Math.PI / 3d) * 0.2f;
                Vector2 v2 = projectile.velocity.RotatedBy(-Math.PI / 3d) * 0.2f;
                int k0 = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, v.X, v.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                if (Main.projectile[k0].type == projectile.type)
                {
                    Main.projectile[k0].timeLeft = 16 * projectile.extraUpdates;
                    Main.projectile[k0].scale = projectile.scale * 0.7f;
                }
                
                int k1 = Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, v2.X, v2.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                if (Main.projectile[k1].type == projectile.type)
                {
                    Main.projectile[k1].timeLeft = 16 * projectile.extraUpdates;
                    Main.projectile[k1].scale = projectile.scale * 0.7f;
                }
            }*/
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (Main.rand.Next(10000) < mplayer.ExpolodePoint)
            {
                for (int i = 0; i < 170; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                    int num5 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                    Main.dust[num5].velocity = v;
                }
                SoundEngine.PlaySound(SoundID.Item14, projectile.Center);
                for (int i = 0; i < 200; i++)
                {
                    if ((Main.npc[i].Center - projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 30)
                    {
                        Main.npc[i].StrikeNPC((int)(projectile.damage * 6 * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1, Main.rand.Next(100) > 50 ? false : true);
                    }
                }
                target.AddBuff(189, 900, false);
            }
            if (Main.rand.Next(10000) < mplayer.BloodPoint)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, 305, 1000, 0, Main.myPlayer, 0, damage / 30f);
            }
            if (Main.rand.Next(10000) < mplayer.PoisonPoint)
            {
                target.AddBuff(70, 600, false);
                target.AddBuff(20, 600, false);
            }
            if (Main.rand.Next(10000) < mplayer.LightingPoint)
            {
                Vector2 v1 = target.Center;
                Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                v2 = v2 / v2.Length() * 2;
                Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1500 + Main.rand.Next(-200, 600), v2.X, v2.Y, Mod.Find<ModProjectile>("LightingBolt").Type, damage * 20, 0.5f, Main.myPlayer, v1.X, v1.Y);
            }
            if (Main.rand.Next(10000) < mplayer.FreezingPoint && projectile.type != Mod.Find<ModProjectile>("FreezeBallBrake").Type)
            {
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                {
                    target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, 240);
                    target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 242);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, 240);
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 242);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, 240);
                            Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, 242);
                        }
                    }
                }
                SoundEngine.PlaySound(SoundID.Item27, target.position);
                for (int i = 0; i < 30; i++)
                {
                    int num = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 88, 0f, 0f, 100, default(Color), 0.8f);
                    Main.dust[num].velocity *= 0.6f;
                }
                for (int k = 0; k <= 20; k++)
                {
                    float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                    float m = (float)Main.rand.Next(0, 50000);
                    float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                    int num4 = Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.06f, (float)((float)l * Math.Sin((float)a)) * 0.06f, base.Mod.Find<ModProjectile>("FreezeBallBrake").Type, 25, projectile.knockBack, projectile.owner, 0f, 30);
                    Main.projectile[num4].timeLeft = (int)(40 * Main.rand.NextFloat(0.2f, 0.7f));
                }
                Projectile.NewProjectile(target.Center.X, target.Center.Y - 199, 0, 0, base.Mod.Find<ModProjectile>("IceKill").Type, 0, 0, projectile.owner, 0f, 0);
            }
        }
    }
}
