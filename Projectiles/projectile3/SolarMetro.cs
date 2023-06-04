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
namespace MythMod.Projectiles.projectile3
{
    public class SolarMetro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("耀斑");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 4;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 100;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            if (Projectile.timeLeft < 99)
            {
                Vector2 vector = base.Projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Solar").Type, 0, 0, 0, default(Color), (float)Projectile.scale);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
            }
            if(Projectile.velocity.Y < 15)
            {
                Projectile.velocity.Y += 0.008f;
            }
            if (Projectile.timeLeft < 50)
            {
                Projectile.scale *= 0.95f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(189, 300, false);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 0, 0, 255));
        }
    }
}