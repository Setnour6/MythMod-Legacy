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
namespace MythMod.Projectiles
{
    //135596
    public class Thunderstaff2 : ModProjectile
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
            projectile.extraUpdates = 450;
            projectile.timeLeft = 1000;
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
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        public override void AI()
        {
            if (projectile.timeLeft == 999)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/雷击"), (int)projectile.Center.X, (int)projectile.Center.Y);
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f);
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 88, 0, 0, 150, default(Color), 1.2f * base.projectile.timeLeft / 1000);
            Main.dust[num25].noGravity = true;
            Main.dust[num25].velocity.X = 0;
            Main.dust[num25].velocity.Y = 0;
            if (projectile.timeLeft % 8 == 1 && Main.rand.Next(1,5) == 3 && projectile.timeLeft < 1000)
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
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if(Main.rand.Next(1,3) == 1)
            {
                target.AddBuff(base.mod.BuffType("ElectriShock"), 25);     
            }  
        }
    }
}