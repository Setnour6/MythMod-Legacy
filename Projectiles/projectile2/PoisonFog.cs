using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
    // Token: 0x0200058D RID: 1421
    public class PoisonFog : ModProjectile
    {
        // Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("毒雾");
        }

        // Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
        public override void SetDefaults()
        {
            base.projectile.width = 210;
            base.projectile.height = 210;
            base.projectile.hostile = true;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.penetrate = -1;
            base.projectile.tileCollide = true;
            base.projectile.timeLeft = 300;
            base.projectile.friendly = false;
            this.cooldownSlot = 1;
            base.projectile.scale = 1f;

        }
        private bool boom = false;
        // Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
        public override void AI()
        {
            projectile.velocity = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.01f, 0.01f));
            projectile.velocity *= 0.995f;
            base.projectile.width = (int)(210 * projectile.scale) / 15 * 10;
            base.projectile.height = (int)(210 * projectile.scale) / 15 * 10;
            if (projectile.wet)
            {
                projectile.timeLeft -= 4;
            }
            for (int o = 0; o < 200; o++)
            {
                if(Main.npc[o].type == 262 && Main.npc[o].active && (Main.npc[o].Center - projectile.Center).Length() <= 200 && Main.npc[o].life < Main.npc[o].lifeMax)
                {
                    Main.npc[o].life += 1;
                }
            }
            base.projectile.scale += 0.008f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * projectile.timeLeft / 640f, (float)(255 - base.projectile.alpha) * 1f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * projectile.timeLeft / 120f);
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.projectile.timeLeft > 60)
            {
                if (base.projectile.timeLeft > 250)
                {
                    return new Color?(new Color((300 - base.projectile.timeLeft) / 500f, (300 - base.projectile.timeLeft) / 500f, (300 - base.projectile.timeLeft) / 500f, 0)) * 0.3f;
                }
                else
                {
                    return new Color?(new Color(0.1f, 0.1f, 0.1f, 0)) * 0.3f;
                }
            }
            else
            {
                if (base.projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.projectile.timeLeft - 25) / 350f, 0.1f, (base.projectile.timeLeft - 25) / 350f, 0)) * 0.3f;
                }
                else
                {
                    return new Color?(new Color(base.projectile.timeLeft / 2100f, base.projectile.timeLeft / 300f, base.projectile.timeLeft / 2100f, 0)) * 0.3f;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            return false;
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(20, projectile.timeLeft * 2, true);
            target.AddBuff(70, projectile.timeLeft / 2, true);
        }
    }
}
