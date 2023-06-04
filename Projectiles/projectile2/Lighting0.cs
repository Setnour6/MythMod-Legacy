using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using MythMod.NPCs;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class Lighting0 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("闪电");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 80;
            Projectile.timeLeft = 1200 * 81;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(0,0,0,0));
		}
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        public override void AI()
        {
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f);
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.timeLeft < 96800 && Projectile.timeLeft > 400)
            {
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, 0, 0, 150, default(Color), 1.8f);
                Main.dust[num25].noGravity = true;
                Main.dust[num25].velocity.X = 0;
                Main.dust[num25].velocity.Y = 0;
            }
            if (Projectile.timeLeft >= 96800)
            {
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, 0, 0, 150, default(Color), 1.8f * (97200 - Projectile.timeLeft) / 400f);
                Main.dust[num25].noGravity = true;
                Main.dust[num25].velocity.X = 0;
                Main.dust[num25].velocity.Y = 0;
            }
            if (Projectile.timeLeft <= 400)
            {
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, 0, 0, 150, default(Color), 1.8f * Projectile.timeLeft / 400f);
                Main.dust[num25].noGravity = true;
                Main.dust[num25].velocity.X = 0;
                Main.dust[num25].velocity.Y = 0;
            }
            if (Projectile.timeLeft % 8 == 1 && Main.rand.Next(1,5) == 3 && Projectile.timeLeft < 97200)
            {
                float num1 = (float)(Main.rand.Next(-500,500) / 800f);
			    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI * num1);
                Y += num1;
                if (Math.Abs(Y) > 0.1f && Main.rand.Next(1,5) == 1)
                {
			        Projectile.velocity = Projectile.velocity.RotatedBy(-Y * (1 + Main.rand.Next(-500,500) / 2500f) * Math.PI);
                    Y = 0;
                }
            }
            if (Main.rand.Next(1, 300) == 3 && Projectile.timeLeft > 300)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.X, base.Projectile.velocity.Y, Mod.Find<ModProjectile>("闪电2").Type, 70, 2f, Main.myPlayer, 0f, 0);
            }
            if(Projectile.wet)
            {
                Projectile.active = false;
            }
            Player player = Main.player[Main.myPlayer];
            if ((Projectile.Center - player.Center).Length() >= 600)
            {
                Projectile.velocity = ((-Projectile.Center + player.Center) / (-Projectile.Center + player.Center).Length() * 1200f).RotatedBy(Main.rand.NextFloat((float)Math.PI * -0.3f, (float)Math.PI * 0.3f)) / (Projectile.Center - player.Center).Length();
            }
            for(int r = 0;r < 200;r++)
            {
                if((Main.npc[r].Center - Projectile.Center).Length() < 200 && Main.rand.Next(10) == 1)
                {
                    Main.npc[r].AddBuff(base.Mod.Find<ModBuff>("ElectriShock").Type, 25);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
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
            target.AddBuff(base.Mod.Find<ModBuff>("ElectriShock").Type, 60);
        }
    }
}