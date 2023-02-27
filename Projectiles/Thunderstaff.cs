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
namespace MythMod.Projectiles
{
    //135596
    public class Thunderstaff : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("天雷法杖");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
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
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        private bool chase = false;
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
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
                    int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 88, 0, 0, 150, default(Color), 3f);
                    Main.dust[num25].noGravity = true;
                    Main.dust[num25].velocity.X = 0;
                    Main.dust[num25].velocity.Y = 0;
                }
            }
            if (projectile.timeLeft % 6 == 1 && projectile.timeLeft < 872 && !chase && Main.rand.Next(2) == 1)
            {
                float num1 = (float)(Main.rand.Next(-500, 500) / 800f);
                projectile.velocity = projectile.velocity.RotatedBy(Math.PI * num1);
                Y += num1;
                if (Math.Abs(Y) > 0.1f && Main.rand.Next(1, 4) == 1)
                {
                    projectile.velocity = projectile.velocity.RotatedBy(-Y * Math.PI);
                    Y = 0;
                }
            }
            if (Main.rand.Next(1, 300) == 3)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.X, base.projectile.velocity.Y, mod.ProjectileType("闪电2"), 70, 2f, Main.myPlayer, 0f, 0);
            }
            if (!chase && projectile.timeLeft < 850)
            {
                for (int j = 0; j < 200; j++)
                {
                    if ((Main.npc[j].Center - projectile.Center).Length() <= 40 && Main.npc[j].friendly == false && Main.npc[j].dontTakeDamage == false && Main.npc[j].active)
                    {
                        chase = true;
                        projectile.velocity = (Main.npc[j].Center - projectile.Center) / (Main.npc[j].Center - projectile.Center).Length() * 2f;
                        b = projectile.timeLeft;
                        break;
                    }
                }
            }
            if(chase)
            {
                if(projectile.timeLeft - b < - 90)
                {
                    chase = false;
                }
            }
        }
        public override void Kill(int timeLeft)
		{
			for (int j = 0; j < 4; j++)
			{
                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(0, 10000) / 50000;
                int num40 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.mod.ProjectileType("闪电2"), 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}
            if(timeLeft != 0)
            {
                for (int a = 0; a < 90; a++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(25, 75) / 50f).RotatedByRandom(Math.PI * 2);
                    int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 88, v.X, v.Y, 150, default(Color), 0.6f);
                    Main.dust[num25].noGravity = false;
                }
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int j = 0; j < 4; j++)
			{
                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(0, 10000) / 50000;
                int num40 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.mod.ProjectileType("闪电2"), 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}
            for (int a = 0; a < 90; a++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(25, 75) / 50f).RotatedByRandom(Math.PI * 2);
                int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 88, v.X, v.Y, 150, default(Color), 0.6f);
                Main.dust[num25].noGravity = false;
            }
            target.AddBuff(base.mod.BuffType("ElectriShock"), 240);       
        }
    }
}