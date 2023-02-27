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

namespace MythMod.Projectiles.projectile4
{
    public class CrowSickle : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "凶鸦夺命镰");
        }
		public override void SetDefaults()
		{
			Projectile.width = 44;
			Projectile.height = 44;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 4;
			Projectile.timeLeft = 720;
			Projectile.localNPCHitCooldown = 0;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 0;
		}
        private float Omega = 0.8f;
		public override void AI()
		{
            Projectile.alpha = (int)(55 + (float)(400 - (float)Projectile.timeLeft) / 2);
            Omega *= 0.994f;
            Projectile.rotation += Omega;
            Projectile.velocity.X *= 0.99f;
            Projectile.velocity.Y *= 0.99f;
            if (Main.rand.Next((int)((720 - Projectile.timeLeft) / 60) + 1) == 0 && Projectile.timeLeft < 700)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4) + new Vector2(-15, -15).RotatedBy(Projectile.rotation), 4, 4, Mod.Find<ModDust>("Crow").Type, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f,2.5f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(-1.5f, -1.5f).RotatedBy(Projectile.rotation) * Omega;
            }
            //Lighting.AddLight(projectile.Center, (float)projectile.timeLeft / 1200f * 114 / 255f, (float)projectile.timeLeft / 1200f * 37 / 255f, (float)projectile.timeLeft / 1200f * 105 / 255f);
            float num2 = Projectile.Center.X;
            float num3 = Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(Projectile, false) && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num5) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num6);
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
                Vector2 vector1 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                Projectile.velocity.X = (Projectile.velocity.X * 20f + num9) / 21f;
                Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num10) / 21f;
                Projectile.velocity *= 0.65f;
            }
        }
		public override void Kill(int timeLeft)
		{
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(Projectile.timeLeft > 180)
            {
                return new Color?(new Color(255, 255, 255, 255));
            }
            else
            {
                return new Color?(new Color((float)Projectile.timeLeft / 180f, (float)Projectile.timeLeft / 180f, (float)Projectile.timeLeft / 180f, (float)Projectile.timeLeft / 180f));
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - new Vector2(4, 4), 4, 4, Mod.Find<ModDust>("Crow").Type, 0f, 0f, 100, default(Color), Main.rand.NextFloat(1.8f, 4f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
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
                    Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i / im, null, new Color(i / im * Omega * 2.5f, i / im * Omega * 2.5f, i / im * Omega * 2.5f, i / im * Projectile.alpha / 255f * Omega * 2.5f), Projectile.rotation + Omega * i * 0.4f, new Vector2(22, 22), Projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}