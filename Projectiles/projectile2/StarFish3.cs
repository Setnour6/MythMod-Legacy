using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using MythMod.UI.Starfish;
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
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class StarFish3 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("海星");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 24;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 2000;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            Projectile.rotation = Y + Projectile.velocity.X * 0.2f;
            Projectile.velocity.X *= 0.995f;
            Projectile.velocity.Y += 0.07f;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(Mod.Find<ModBuff>("Starfishes").Type, 180, true);
            Projectile.timeLeft = 0;
        }
        //14141414141414
    }
}