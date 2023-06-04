using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.Yasitaya
{
    public class RedDust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 180;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        public override void AI()
        {
            for(int h = 0;h < 10;h++)
            {
                Vector2 v = new Vector2(0, 5).RotatedByRandom(MathHelper.TwoPi);
                if(Projectile.timeLeft < 30)
                {
                    v = new Vector2(0, Projectile.timeLeft / 6f).RotatedByRandom(MathHelper.TwoPi);
                }
                int num = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 2, 2, 183, v.X, v.Y, 0, default(Color), 3f);
                Main.dust[num].noGravity = true;
                if (Projectile.timeLeft < 30)
                {
                    Main.dust[num].scale = Projectile.timeLeft / 10f;
                }
            }
            Projectile.velocity.Y += 0.1f;
        }       
    }
}