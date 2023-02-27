using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using MythMod.UI.Starfish;
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
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class StarFish2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("海星");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.melee = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 2000;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private double X;
        private float Y = 0;
        private float b;
        public override void AI()
        {
            if(initialization)
            {
                Y = Main.rand.Next(0, 10000) / 5000f * (float)Math.PI;
                initialization = false;
            }
            projectile.rotation = Y + projectile.velocity.X * 0.2f;
            projectile.velocity.X *= 0.995f;
            projectile.velocity.Y += 0.07f;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Starfishes"), 180, true);
            projectile.timeLeft = 0;
        }
        //14141414141414
    }
}