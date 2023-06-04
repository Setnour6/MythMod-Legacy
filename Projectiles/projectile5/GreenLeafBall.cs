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
namespace MythMod.Projectiles.projectile5
{
    public class GreenLeafBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("叶绿光球");
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 7200;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 0;
            this.CooldownSlot = 1;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0f));
        }
        private bool Fa = true;
        private int I = -1;
        private float S2 = 0;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if (Fa)
            {
                Fa = false;
            }
            if (S2 < 1f)
            {
                S2 += 0.01f;
            }
            if (Projectile.timeLeft % 6 == 0)
            {
                if (Projectile.frame < 3)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
            if (Projectile.timeLeft > 120)
            {
                num += 0.011f;
                float S = (float)(Math.Sin(num) / 5f + 1);
                Projectile.scale = S * S2;
            }
            else
            {
                Projectile.scale *= 0.99f;
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            for (int g = 0; g < 8; g++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.1f, 8.3f)).RotatedByRandom(MathHelper.TwoPi);
                int numk = Dust.NewDust(Projectile.Center - new Vector2(8, 8), 8, 8, Mod.Find<ModDust>("Poison").Type, v.X * Projectile.scale, v.Y * Projectile.scale, 0, default(Color), 4f * Projectile.scale);
                Main.dust[numk].noGravity = true;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.Kill();
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile5/Lightball"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), null, new Color(0, 1f, 0f, 0), 0, new Vector2(250, 250), base.Projectile.scale * 0.1f, SpriteEffects.None, 1f);
            return false;
        }
        private float num = 0;
        private int num1 = 0;
        private int num2 = -1;
        private float num3 = 0.8f;
        private float num4 = 0;
        private float num5 = 0;
        private float x = 0;
        private float y = 0;
        private int Fy = 0;
        private int fyc = 0;
    }
}