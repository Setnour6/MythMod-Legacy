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
using MythMod;

namespace MythMod.NPCs.Yasitaya
{
    public class WavePoint : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 480;
            Projectile.penetrate = -1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        private int n = -1;

        public override void AI()
        {
            WavCent = Projectile.Bottom - Main.screenPosition;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            WavCent = Projectile.Bottom - Main.screenPosition;
            return false;
        }
        public static Vector2 WavCent = new Vector2(0);
    }
}