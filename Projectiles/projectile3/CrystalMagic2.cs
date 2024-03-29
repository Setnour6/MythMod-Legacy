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
    public class CrystalMagic2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("水晶魔法");
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
            projectile.timeLeft = 150;
            projectile.penetrate = 5;
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
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            if (timeLeft != 0 && timeLeft < 140)
            {
                for (int a = 0; a < 10; a++)
                {
                    Vector2 vector = base.projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.15f, 0.05f) * 0.1f;
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (projectile.timeLeft > 60)
            {
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 200), base.projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            }
            else
            {
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, new Color(projectile.timeLeft / 60f, projectile.timeLeft / 60f, projectile.timeLeft / 60f, projectile.timeLeft / 60f * 200f / 255f), base.projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}