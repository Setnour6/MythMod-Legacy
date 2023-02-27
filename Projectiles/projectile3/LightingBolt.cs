using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles.projectile3
{
    public class LightingBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("闪电霹雳");
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 80;
            projectile.timeLeft = 900;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        private bool chase = false;
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        private float M = 0;
        private float N = 0;
        public override void AI()
        {
            if(projectile.timeLeft == 899)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/雷击"), (int)projectile.Center.X, (int)projectile.Center.Y);
            }
            if (projectile.timeLeft < 872)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 1.0f / 255f);
                base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
                if (projectile.timeLeft % 2 == 0)
                {
                    int num25 = Dust.NewDust(base.projectile.Center, 0, 0, 88, 0, 0, 150, default(Color), (float)(0.7f * Math.Log10(projectile.damage)));
                    Main.dust[num25].noGravity = true;
                    Main.dust[num25].velocity.X = 0;
                    Main.dust[num25].velocity.Y = 0;
                }
            }
            if (projectile.timeLeft % 6 == 1 && projectile.timeLeft < 872 && !chase && Main.rand.Next(2) == 1)
            {
                Vector2 v2 = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
                if (v2.Length() > 500)
                {
                    M = projectile.Center.X + v2.X * 2000f;
                    N = projectile.Center.Y + v2.Y * 2000f;
                }
                if (v2.Length() > 30)
                {
                    v2 = v2 / v2.Length() * 2;
                    if (!chase)
                    {
                        float num1 = (float)(Main.rand.NextFloat(-500, 500) / 800f);
                        projectile.velocity = v2.RotatedBy(Math.PI * num1);
                        if (projectile.timeLeft < 600)
                        {
                            projectile.timeLeft = 600;
                        }
                    }
                }
                else
                {
                    v2 = v2 / v2.Length() * 2;
                    if (!chase)
                    {
                        projectile.timeLeft = 872;
                        chase = true;
                        float num1 = (float)(Main.rand.NextFloat(-v2.Length() * 5, v2.Length() * 5) / 800f);
                        projectile.velocity = v2.RotatedBy(Math.PI * num1);
                    }
                }
            }
            if (projectile.timeLeft % 6 == 1 && projectile.timeLeft < 872 && Main.rand.Next(2) == 1 && chase)
            {
                Vector2 v2 = new Vector2(M, N) - projectile.Center;
                v2 = v2 / v2.Length() * 2;
                float num1 = (float)(Main.rand.NextFloat(-500, 500) / 800f);
                projectile.velocity = v2.RotatedBy(Math.PI * num1);
            }
            if (Main.rand.Next(1, 300) == 3)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.X, base.projectile.velocity.Y, mod.ProjectileType("Lighting2"), 0, 2f, Main.myPlayer, 0f, 0);
            }
        }
        public override void Kill(int timeLeft)
		{
			/*for (int j = 0; j < 4; j++)
			{
                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(0, 10000) / 50000;
                int num40 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.mod.ProjectileType("Lighting2"), 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}*/
            if(timeLeft != 0)
            {
                for (int a = 0; a < 150; a++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(25, 175) / 150f).RotatedByRandom(Math.PI * 2) * (float)Math.Log10(projectile.damage);
                    int num25 = Dust.NewDust(projectile.Center, 0, 0, 88, v.X, v.Y, 150, default(Color), Main.rand.NextFloat(0, (float)(0.5f * Math.Log10(projectile.damage))));
                    Main.dust[num25].noGravity = false;
                }
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			/*for (int j = 0; j < 4; j++)
			{
                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(0, 10000) / 50000;
                int num40 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.mod.ProjectileType("Lighting2"), 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}*/
            for (int a = 0; a < 90; a++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(25, 175) / 50f).RotatedByRandom(Math.PI * 2);
                int num25 = Dust.NewDust(projectile.Center, 0, 0, 88, v.X, v.Y, 150, default(Color), (float)(0.5f * Math.Log10(projectile.damage)));
                Main.dust[num25].noGravity = false;
            }
            target.AddBuff(base.mod.BuffType("ElectriShock"), 240);       
        }
    }
}