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
namespace MythMod.Projectiles.CorruptMoth
{
    //135596
    public class Coon : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("茧");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        //55555
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            projectile.velocity.Y = -5f;
        }
        public override void Kill(int timeLeft)
        {
            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y + 128, mod.NPCType("魔茧"), 0, 0f, 1f, 0f, 0f, 255);
        }
    }
}