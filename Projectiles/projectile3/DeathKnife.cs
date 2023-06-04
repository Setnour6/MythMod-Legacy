using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class DeathKnife : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("死灵");
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 80;
			base.Projectile.height = 80;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 8;
			base.Projectile.timeLeft = 720;
			base.Projectile.localNPCHitCooldown = 0;
            base.Projectile.extraUpdates = 1;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.alpha = 55;
		}
        private float Omega = 0.8f;
		public override void AI()
		{
            base.Projectile.alpha = (int)(55 + (float)(400 - (float)Projectile.timeLeft) / 2);
            base.Projectile.rotation += Omega;
            Omega *= 0.994f;
            base.Projectile.velocity.X *= 0.99f;
            base.Projectile.velocity.Y *= 0.99f;
            Lighting.AddLight(base.Projectile.Center, (float)Projectile.timeLeft / 1200f * 114 / 255f, (float)Projectile.timeLeft / 1200f * 37 / 255f, (float)Projectile.timeLeft / 1200f * 105 / 255f);
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
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(Projectile.damage, Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                        NPC target = Main.npc[j];
                    }
                }
            }
            if (flag)
            {
                float num8 = 50f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num9) / 21f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num10) / 21f;
                Projectile.velocity *= 0.65f;
            }
        }
		public override void Kill(int timeLeft)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            if(Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((float)Projectile.timeLeft / 60f, (float)Projectile.timeLeft / 60f, (float)Projectile.timeLeft / 60f, 0));
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //target.AddBuff(24, 600);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            float im = Omega * 50;
            if (im >= 1)
            {
                for (int i = 0; i < im; i++)
                {
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / im, null, new Color(i / im * (float)Math.Log(Omega * 4 + 1) * 0.5f, i / im * (float)Math.Log(Omega * 4 + 1) * 0.5f, i / im * (float)Math.Log(Omega * 4 + 1) * 0.5f, i / im * Projectile.alpha / 255f * (float)Math.Log(Omega * 4 + 1)) * 0.5f, Projectile.rotation + Omega * i * 0.4f, new Vector2(38, 34), Projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}