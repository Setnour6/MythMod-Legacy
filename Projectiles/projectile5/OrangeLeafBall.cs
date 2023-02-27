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
    public class OrangeLeafBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("橘色光球");
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
            Projectile.timeLeft = 200;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1;
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
                Projectile.scale = S;
            }
            else
            {
                Projectile.scale *= 0.99f;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Projectile.Kill();
        }
        public override void Kill(int timeLeft)
        { 
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.Kill();
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
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile5/Lightball"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), null, new Color(1f,0.2f,0,0), 0, new Vector2(250, 250), base.Projectile.scale * 0.1f, SpriteEffects.None, 1f);
            return false;
        }
    }
}