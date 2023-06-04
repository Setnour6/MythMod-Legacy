using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
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
            Projectile.extraUpdates = 450;
            Projectile.timeLeft = 1000;
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
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        public override void AI()
        {
            if (Projectile.timeLeft == 999)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/雷击"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f);
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 88, 0, 0, 150, default(Color), 1.2f * base.Projectile.timeLeft / 1000);
            Main.dust[num25].noGravity = true;
            Main.dust[num25].velocity.X = 0;
            Main.dust[num25].velocity.Y = 0;
            if (Projectile.timeLeft % 8 == 1 && Main.rand.Next(1,5) == 3 && Projectile.timeLeft < 1000)
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
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            if(Main.rand.Next(1,3) == 1)
            {
                target.AddBuff(base.Mod.Find<ModBuff>("ElectriShock").Type, 25);     
            }  
        }
    }
}