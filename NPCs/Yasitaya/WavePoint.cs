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
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 480;
            projectile.penetrate = -1;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        private int n = -1;

        public override void AI()
        {
            WavCent = projectile.Bottom - Main.screenPosition;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            WavCent = projectile.Bottom - Main.screenPosition;
            return false;
        }
        public static Vector2 WavCent = new Vector2(0);
    }
}