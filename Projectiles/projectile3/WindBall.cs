using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class WindBall : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("风之球");
            Main.projFrames[Projectile.type] = 6;
        }
		public override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 58;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
			Projectile.timeLeft = 3600;
            Projectile.localNPCHitCooldown = 0;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.alpha = 55;
		}
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            Projectile.rotation = 0 + Projectile.velocity.X / 25f;
            if (Projectile.timeLeft < 3594)
            {
                Projectile.tileCollide = true;
                int r2 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f)) * 0.15f - new Vector2(Main.rand.NextFloat(0, 24), 0).RotatedByRandom(MathHelper.TwoPi) - new Vector2(8, 8), 0, 0, 99, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            if (Projectile.timeLeft % 6 == 0)
            {
                if (Projectile.frame < 5)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
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
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                Projectile.velocity.X = (Projectile.velocity.X * 20f + num9) / 21f;
                Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num10) / 21f;
            }
        }
		public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 20; i++)
            {
                int r = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - Projectile.velocity * 1.2f - new Vector2(4, 4), 22, 22, 99, 0, 0, 0, default(Color), 1.5f);
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("爆裂音波").Type, Projectile.damage, 0, base.Projectile.owner, 0f, 0f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 150));
        }
	}
}