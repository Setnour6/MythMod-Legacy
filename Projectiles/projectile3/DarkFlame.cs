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
    public class DarkFlame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("恶魔火");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 120;
            projectile.alpha = 0;
            projectile.penetrate = 3;
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
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            /*if (projectile.timeLeft < 3595)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("DarkF"), 50f, 50f, 0, default(Color), (float)projectile.scale * 2.4f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 150;
            }*/
            projectile.velocity *= 0.985f;
            projectile.velocity = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f) / projectile.velocity.Length());
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 150));
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.penetrate--;
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                projectile.velocity = projectile.velocity.RotatedBy(Main.rand.NextFloat(1.57f, 4.71f));
                projectile.velocity.Y *= 0.2f;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 900);
        }
    }
}