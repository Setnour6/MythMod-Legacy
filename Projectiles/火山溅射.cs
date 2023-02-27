using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
    public class 火山溅射 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("火山溅射");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 34;
			base.projectile.height = 34;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 5;
			base.projectile.timeLeft = 240;
            base.projectile.friendly = true;
			this.cooldownSlot = 0;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}
        public override void AI()
        {
            int num = Dust.NewDust(projectile.Center - new Vector2(6, 6), 12, 12, mod.DustType("Flame"), 0f, 0f, 100, Color.White, 2f);
            if (projectile.wet)
            {
                projectile.timeLeft = 0;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.45f * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0.1f * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
            base.projectile.velocity.Y += 0.15f;
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 400f;
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
                        if(projectile.penetrate == 0)
                        {
                            projectile.Kill();
                        }
                    }
                }
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(1f, 1f, 1f, base.projectile.alpha / 255f));
		}
		public override void Kill(int timeLeft)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int i = 0; i < 65; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, 4f);
                Main.dust[num5].velocity = v;
            }
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            return true;
		}
	}
}
