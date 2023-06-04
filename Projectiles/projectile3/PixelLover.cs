using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class PixelLover : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("像素之恋");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1000;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + Math.PI * 0.25);
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(Projectile.damage, Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                    }
                }
            }
            Vector2 vector = base.Projectile.Center;
            if(Main.rand.Next(3) == 1)
            {
                int num = Dust.NewDust(vector - new Vector2(10, 10), 20, 20, Mod.Find<ModDust>("Pixel").Type, 0, 0, 0, default(Color), 1.2f);
                Main.dust[num].noGravity = true;
                Main.dust[num].velocity *= 0;
            }
            if (Main.rand.Next(3) == 1)
            {
                int num2 = Dust.NewDust(vector - new Vector2(25, 25), 50, 50, Mod.Find<ModDust>("Pixel2").Type, 0, 0, 0, default(Color), 2f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0;
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(15f, 17f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Pixel").Type, v.X, v.Y, 0, default(Color), 1.2f);
                Main.dust[num].noGravity = false;
            }
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(15f, 17f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("Pixel2").Type, v.X, v.Y, 0, default(Color), 4f);
                Main.dust[num].noGravity = false;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Player player = Main.player[Main.myPlayer];
            for (int X = (int)(Projectile.Center.X - Main.screenPosition.X - 50); X <= (int)(Projectile.Center.X - Main.screenPosition.X + 50); X += 8)
            {
                for (int Y = (int)(Projectile.Center.Y - Main.screenPosition.Y - 50); Y <= (int)(Projectile.Center.Y - Main.screenPosition.Y + 50); Y += 8)
                {
                    Vector2 vx = new Vector2(X, Y) + Main.screenPosition;
                    if ((vx - Projectile.Center).Length() < 40)
                    {
                        if (X + (int)player.position.X % 2048 <= 2040)
                        {
                            spriteBatch.Draw(Mod.GetTexture("UIImages/PIXELEFFECT"), new Vector2(X, Y), new Rectangle(X + (int)player.position.X % 2048, Y + (int)(player.position.Y / 24f), 8, 8), new Color(150, 150, 150, 50), 0f, new Vector2(4, 4), (40 - (vx - Projectile.Center).Length()) / 40f * (1 + (X % 3) / 3f - (Y % 2) / 3f) * Main.rand.NextFloat(0.4f,2f), SpriteEffects.None, 0f);
                        }
                        else
                        {
                            spriteBatch.Draw(Mod.GetTexture("UIImages/PIXELEFFECT"), new Vector2(X, Y), new Rectangle(X + (int)player.position.X % 2048 - 2040, Y + (int)(player.position.Y / 24f), 8, 8), new Color(150, 150, 150, 50), 0f, new Vector2(4, 4), (40 - (vx - Projectile.Center).Length()) / 40f * (1 + (X % 3) / 3f - (Y % 2) / 3f) * Main.rand.NextFloat(0.4f, 2f), SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            return false;
        }
    }
}