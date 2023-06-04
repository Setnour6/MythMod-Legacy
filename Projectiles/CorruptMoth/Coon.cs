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
            // DisplayName.SetDefault("茧");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1000;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            Projectile.velocity.Y = -5f;
        }
        public override void Kill(int timeLeft)
        {
            NPC.NewNPC((int)Projectile.Center.X, (int)Projectile.Center.Y + 128, Mod.Find<ModNPC>("魔茧").Type, 0, 0f, 1f, 0f, 0f, 255);
        }
    }
}