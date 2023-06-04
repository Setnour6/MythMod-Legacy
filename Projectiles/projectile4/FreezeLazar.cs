using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
    public class FreezeLazar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("冷冻射线");
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.hostile = false;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			base.Projectile.spriteDirection = 1;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f);
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            Projectile.ai[1] = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0));
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(47, 300);
            target.AddBuff(46, 300);
            if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
            {
                target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                target.AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
            }
            if (target.type == 113)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                        Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
                    }
                }
            }
            if (target.type == 114)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze").Type, (int)Projectile.ai[1]);
                        Main.npc[i].AddBuff(Mod.Find<ModBuff>("Freeze2").Type, (int)Projectile.ai[1] + 2);
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 88, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num].velocity *= 0.2f;
            }
        }
    }
}
