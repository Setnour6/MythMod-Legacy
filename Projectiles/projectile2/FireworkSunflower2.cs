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
            // DisplayName.SetDefault("烟花火球向日葵");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 700;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        //55555
        private bool initialization = true;
        private float b;
        private float z;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void AI()
        {
            if (initialization)
            {
                b = Main.rand.Next(-50, 50);
                if (Projectile.velocity.Length() >= 1)
                {
                    z = Projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                initialization = false;
            }
            Projectile.velocity *= 0.995f;
            NPC target = null;
            if (Projectile.timeLeft < 480+ (float)b)
            {
                Projectile.scale *= 0.992f;
            }
            Projectile.velocity.Y += 0.01f;
            if (Projectile.timeLeft < 675)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, 0.15f).RotatedByRandom(Math.PI * 2);
                int num2 = Dust.NewDust(vector, 7, 7, 159, Projectile.velocity.X * 0.7f, Projectile.velocity.Y * 0.7f, 0, default(Color), (float)Projectile.scale);
                Main.dust[num2].noGravity = false;
            }
        }
        //14141414141414
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/烟花火球白黄light"), base.Projectile.Center - Main.screenPosition, null, new Color(Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), Projectile.scale * (Projectile.timeLeft - 300) / (2400f * z * z), 0), base.Projectile.rotation, new Vector2(56f, 56f), 1 + (800 - Projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 1200);
        }
    }
}