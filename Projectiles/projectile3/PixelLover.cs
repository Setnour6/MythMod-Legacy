using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class PixelLover : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("像素之恋");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
            projectile.penetrate = 1;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + Math.PI * 0.25);
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(projectile.damage, projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        projectile.penetrate--;
                    }
                }
            }
            Vector2 vector = base.projectile.Center;
            if(Main.rand.Next(3) == 1)
            {
                int num = Dust.NewDust(vector - new Vector2(10, 10), 20, 20, mod.DustType("Pixel"), 0, 0, 0, default(Color), 1.2f);
                Main.dust[num].noGravity = true;
                Main.dust[num].velocity *= 0;
            }
            if (Main.rand.Next(3) == 1)
            {
                int num2 = Dust.NewDust(vector - new Vector2(25, 25), 50, 50, mod.DustType("Pixel2"), 0, 0, 0, default(Color), 2f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(15f, 17f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Pixel"), v.X, v.Y, 0, default(Color), 1.2f);
                Main.dust[num].noGravity = false;
            }
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(15f, 17f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Pixel2"), v.X, v.Y, 0, default(Color), 4f);
                Main.dust[num].noGravity = false;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Player player = Main.player[Main.myPlayer];
            for (int X = (int)(projectile.Center.X - Main.screenPosition.X - 50); X <= (int)(projectile.Center.X - Main.screenPosition.X + 50); X += 8)
            {
                for (int Y = (int)(projectile.Center.Y - Main.screenPosition.Y - 50); Y <= (int)(projectile.Center.Y - Main.screenPosition.Y + 50); Y += 8)
                {
                    Vector2 vx = new Vector2(X, Y) + Main.screenPosition;
                    if ((vx - projectile.Center).Length() < 40)
                    {
                        if (X + (int)player.position.X % 2048 <= 2040)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/PIXELEFFECT"), new Vector2(X, Y), new Rectangle(X + (int)player.position.X % 2048, Y + (int)(player.position.Y / 24f), 8, 8), new Color(150, 150, 150, 50), 0f, new Vector2(4, 4), (40 - (vx - projectile.Center).Length()) / 40f * (1 + (X % 3) / 3f - (Y % 2) / 3f) * Main.rand.NextFloat(0.4f,2f), SpriteEffects.None, 0f);
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/PIXELEFFECT"), new Vector2(X, Y), new Rectangle(X + (int)player.position.X % 2048 - 2040, Y + (int)(player.position.Y / 24f), 8, 8), new Color(150, 150, 150, 50), 0f, new Vector2(4, 4), (40 - (vx - projectile.Center).Length()) / 40f * (1 + (X % 3) / 3f - (Y % 2) / 3f) * Main.rand.NextFloat(0.4f, 2f), SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            return false;
        }
    }
}