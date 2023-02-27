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
    public class Lighting2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("闪电");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 80;
            projectile.timeLeft = 500;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
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
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f);
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 88, 0, 0, 150, default(Color), 1.2f * base.projectile.timeLeft / 500f);
            Main.dust[num25].noGravity = true;
            Main.dust[num25].velocity.X = 0;
            Main.dust[num25].velocity.Y = 0;
            if (projectile.timeLeft % 4 == 1 && Main.rand.Next(1,5) == 3 && projectile.timeLeft < 500)
            {
                float num1 = (float)(Main.rand.Next(-500,500) / 800f);
			    projectile.velocity = projectile.velocity.RotatedBy(Math.PI * num1);
                Y += num1;
                if (Math.Abs(Y) > 0.1f && Main.rand.Next(1,5) == 1)
                {
			        projectile.velocity = projectile.velocity.RotatedBy(-Y * (1 + Main.rand.Next(-500,500) / 2500f) * Math.PI);
                    Y = 0;
                }
            }
            if (projectile.wet)
            {
                projectile.active = false;
            }
            if(Main.rand.Next(250) == 1)
            {
                Vector2 v = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.9f,0.9f));
                int num40 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("Lighting2"), 35, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = projectile.timeLeft;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(1, 6) == 1)
            {
                target.AddBuff(base.mod.BuffType("ElectriShock"), 25);
            }
        }
    }
}