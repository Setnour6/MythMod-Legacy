using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class FireFeather : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("火羽");
        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1080;
            Projectile.alpha = 0;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
            Projectile.velocity *= 1.01f;
            int num90 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(12, 12) - base.Projectile.velocity, 16, 16, 6, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num90].noGravity = true;
            Main.dust[num90].velocity *= 0.5f;
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 200f + num9) / 201f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 200f + num10) / 201f;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0 && timeLeft < 1050)
            {
                int uo = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, 164, Projectile.damage, 1, Main.myPlayer, 0f, 0f);
                Main.projectile[uo].friendly = true;
                Main.projectile[uo].hostile = false;
            }
            for (int j = 0; j < 15; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 6, 0f, 0f, 100, default(Color), 1.8f);
                Main.dust[num2].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 600);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(17, 7), Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}