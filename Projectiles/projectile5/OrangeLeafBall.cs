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
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 200;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1;
            this.cooldownSlot = 1;
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
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if (Fa)
            {
                Fa = false;
            }
            if (projectile.timeLeft % 6 == 0)
            {
                if (projectile.frame < 3)
                {
                    projectile.frame += 1;
                }
                else
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.timeLeft > 120)
            {
                num += 0.011f;
                float S = (float)(Math.Sin(num) / 5f + 1);
                projectile.scale = S;
            }
            else
            {
                projectile.scale *= 0.99f;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
        public override void Kill(int timeLeft)
        { 
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.Kill();
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/Lightball"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), null, new Color(1f,0.2f,0,0), 0, new Vector2(250, 250), base.projectile.scale * 0.1f, SpriteEffects.None, 1f);
            return false;
        }
    }
}