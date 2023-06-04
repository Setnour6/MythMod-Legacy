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
            // DisplayName.SetDefault("天雷法杖");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 80;
            Projectile.timeLeft = 900;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        private bool chase = false;
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        public override void AI()
        {
            if(Projectile.timeLeft == 899)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/雷击"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            }
            if (Projectile.timeLeft < 872)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 1.0f / 255f);
                base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
                if (Projectile.timeLeft % 2 == 0)
                {
                    int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, 0, 0, 150, default(Color), 3f);
                    Main.dust[num25].noGravity = true;
                    Main.dust[num25].velocity.X = 0;
                    Main.dust[num25].velocity.Y = 0;
                }
            }
            if (Projectile.timeLeft % 6 == 1 && Projectile.timeLeft < 872 && !chase && Main.rand.Next(2) == 1)
            {
                float num1 = (float)(Main.rand.Next(-500, 500) / 800f);
                Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI * num1);
                Y += num1;
                if (Math.Abs(Y) > 0.1f && Main.rand.Next(1, 4) == 1)
                {
                    Projectile.velocity = Projectile.velocity.RotatedBy(-Y * Math.PI);
                    Y = 0;
                }
            }
            if (Main.rand.Next(1, 300) == 3)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.X, base.Projectile.velocity.Y, Mod.Find<ModProjectile>("闪电2").Type, 70, 2f, Main.myPlayer, 0f, 0);
            }
            if (!chase && Projectile.timeLeft < 850)
            {
                for (int j = 0; j < 200; j++)
                {
                    if ((Main.npc[j].Center - Projectile.Center).Length() <= 40 && Main.npc[j].friendly == false && Main.npc[j].dontTakeDamage == false && Main.npc[j].active)
                    {
                        chase = true;
                        Projectile.velocity = (Main.npc[j].Center - Projectile.Center) / (Main.npc[j].Center - Projectile.Center).Length() * 2f;
                        b = Projectile.timeLeft;
                        break;
                    }
                }
            }
            if(chase)
            {
                if(Projectile.timeLeft - b < - 90)
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
                int num40 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("闪电2").Type, 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}
            if(timeLeft != 0)
            {
                for (int a = 0; a < 90; a++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(25, 75) / 50f).RotatedByRandom(Math.PI * 2);
                    int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, v.X, v.Y, 150, default(Color), 0.6f);
                    Main.dust[num25].noGravity = false;
                }
            }
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			for (int j = 0; j < 4; j++)
			{
                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(0, 10000) / 50000;
                int num40 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("闪电2").Type, 70, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].timeLeft = 800;
                Main.projectile[num40].tileCollide = false;
			}
            for (int a = 0; a < 90; a++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(25, 75) / 50f).RotatedByRandom(Math.PI * 2);
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, v.X, v.Y, 150, default(Color), 0.6f);
                Main.dust[num25].noGravity = false;
            }
            target.AddBuff(base.Mod.Find<ModBuff>("ElectriShock").Type, 240);       
        }
    }
}