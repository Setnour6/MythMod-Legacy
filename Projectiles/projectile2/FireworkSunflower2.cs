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
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class FireworkSunflower2 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球向日葵");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 700;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private float b;
        private float z;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void AI()
        {
            if (initialization)
            {
                b = Main.rand.Next(-50, 50);
                if (projectile.velocity.Length() >= 1)
                {
                    z = projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                initialization = false;
            }
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 480+ (float)b)
            {
                projectile.scale *= 0.992f;
            }
            projectile.velocity.Y += 0.01f;
            if (projectile.timeLeft < 675)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, 0.15f).RotatedByRandom(Math.PI * 2);
                int num2 = Dust.NewDust(vector, 7, 7, 159, projectile.velocity.X * 0.7f, projectile.velocity.Y * 0.7f, 0, default(Color), (float)projectile.scale);
                Main.dust[num2].noGravity = false;
            }
        }
        //14141414141414
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球白黄light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (800 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
    }
}