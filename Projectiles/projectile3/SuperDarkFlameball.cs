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
    public class SuperDarkFlameball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("超级恶魔火球");
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 3600;
            projectile.alpha = 0;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        float r = 10;
        private Vector2 v0;
        private int Fra = 0;
        private int FraX = 0;
        private int FraY = 0;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 3595)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("DarkF"), 50f, 50f, 0, default(Color), (float)projectile.scale * 2.4f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 150;
            }
            if(projectile.velocity.Y < 15)
            {
                projectile.velocity.Y += 0.2f;
            }
            if (projectile.timeLeft == 3600)
            {
                v0 = projectile.Center;
            }
            if (projectile.timeLeft > 3540)
            {
                r += 0.2f;
            }
            if (projectile.timeLeft <= 3540 && projectile.timeLeft >= 60)
            {
                r = 24 + (float)(0.4f * Math.Sin((projectile.timeLeft - 60) / 60d * Math.PI));
            }
            if (projectile.timeLeft < 60 && r > 0.5f)
            {
                r -= 1f;
            }
            int Dx = (int)(r * 1.5f);
            int Dy = (int)(r * 1.5f);
            Fra = ((3600 - projectile.timeLeft) / (int)3) % 30;
            FraX = (Fra % 6) * 270;
            FraY = (Fra / (int)6) * 290;
            /*if (v0 != Vector2.Zero)
            {
                projectile.position = v0 - new Vector2(Dx, Dy) / 2f;
            }*/
            if(projectile.timeLeft < 3480)
            {
                projectile.tileCollide = true;
            }
            projectile.width = Dx;
            projectile.height = Dy;
        }
        public override void Kill(int timeLeft)
        {
            int pl = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 160; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(1.9f, (float)(7 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("DarkF2"), 0f, 0f, 100, Color.White, (float)(10f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            float D = (Main.player[pl].Center - projectile.Center).Length();
            if (D < 150)
            {
                Projectile.NewProjectile(Main.player[pl].Center.X, Main.player[pl].Center.Y, 0, 0, mod.ProjectileType("Hit"), projectile.damage, 0f, Main.myPlayer, 0f, 0f);
            }
            r = 200;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 150));
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if(r < 100)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile4/DarkLazerBall"), base.projectile.Center - Main.screenPosition, new Rectangle(FraX, 10 + FraY, 270, 270), new Color(1f, 1f, 1f, 0), base.projectile.rotation, new Vector2(135f, 135f), r / 60f, SpriteEffects.None, 0f);
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}