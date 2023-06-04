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
namespace MythMod.Projectiles
{
    public class PoisonArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("剧毒箭");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 21;
            Projectile.timeLeft = 1300;
            Projectile.alpha = 0;
            Projectile.penetrate = 2;
            Projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 500;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        public override void AI()
        {
            Projectile.rotation = (float)
            System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;

            Vector2 vector = Projectile.Center - new Vector2(4, 4);
            if(Projectile.timeLeft % 6 == 2)
            {
                int num13 = Dust.NewDust(vector, 3, 3, 262, 0f, 0f, 200, Color.Yellow, 0.7f);
                Main.dust[num13].velocity *= 0.0f;
                Main.dust[num13].noGravity = true;
            }
            if(Projectile.timeLeft % 6 == 5)
            {
                int num13 = Dust.NewDust(vector, 3, 3, Mod.Find<ModDust>("GoldGlitter").Type, 0f, 0f, 200, Color.Yellow, 1.68f);
                Main.dust[num13].velocity *= 0.0f;
                Main.dust[num13].noGravity = true;
            }
            float num2 = base.Projectile.Center.X;
			float num3 = base.Projectile.Center.Y;
			float num4 = 500f;
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
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 14500f);
                        base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 14500f);
                    }
                    else
                    {
                        base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 14500f);
                        base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 14500f);
                    }
                }
			}
			if (flag && Projectile.timeLeft % 120 > 80)
			{
				float num8 = 20f;
				Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 40f + num9) / 41f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 40f + num10) / 41f;
			}
            if (Projectile.timeLeft < 120)
			{
                Projectile.tileCollide = true;
            }
            if (!flag)
			{
                Projectile.velocity.Y += 0.000675f;
            }
            if(Projectile.velocity.Length() > 3.3f)
            {
                Projectile.velocity *= 3.3f / Projectile.velocity.Length();
            }
            if (Projectile.velocity.Length() < 1.6f)
            {
                Projectile.velocity *= 1.6f / Projectile.velocity.Length();
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 15; i++)
            {
                int num1 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 262, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2.4f, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 2.4f, 150, Color.Yellow, 2f);
                Main.dust[num1].noGravity = true;
                int num2 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 262, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 8, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 8, 150, Color.Purple, 1f);
                Main.dust[num2].noGravity = true;
            }
            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D t = Mod.GetTexture("Projectiles/SulfurFlame");
            Vector2 drawOrigin = new Vector2(10, 10);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + new Vector2(8, -8).RotatedBy(Math.Atan2(Projectile.velocity.Y,Projectile.velocity.X));
                Color color = (new Color(1f, 1f, 1f, 0) * 0.1f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale * 0.08f, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}