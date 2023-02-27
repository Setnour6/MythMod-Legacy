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
            DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.magic = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 180;
            projectile.penetrate = 1;
            projectile.scale = 1;
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
                if(projectile.timeLeft < 30)
                {
                    v = new Vector2(0, projectile.timeLeft / 6f).RotatedByRandom(MathHelper.TwoPi);
                }
                int num = Dust.NewDust(projectile.Center - new Vector2(4, 4), 2, 2, 183, v.X, v.Y, 0, default(Color), 3f);
                Main.dust[num].noGravity = true;
                if (projectile.timeLeft < 30)
                {
                    Main.dust[num].scale = projectile.timeLeft / 10f;
                }
            }
            projectile.velocity.Y += 0.1f;
        }       
    }
}