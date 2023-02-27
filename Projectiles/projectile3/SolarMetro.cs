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
            DisplayName.SetDefault("耀斑");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 4;
            projectile.tileCollide = true;
            projectile.timeLeft = 100;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            if (projectile.timeLeft < 99)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 0, 0, mod.DustType("Solar"), 0, 0, 0, default(Color), (float)projectile.scale);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
            }
            if(projectile.velocity.Y < 15)
            {
                projectile.velocity.Y += 0.008f;
            }
            if (projectile.timeLeft < 50)
            {
                projectile.scale *= 0.95f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(189, 300, false);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 0, 0, 255));
        }
    }
}