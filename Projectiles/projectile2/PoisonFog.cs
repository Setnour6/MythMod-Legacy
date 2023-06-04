﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("毒雾");
        }

        // Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
        public override void SetDefaults()
        {
            base.Projectile.width = 210;
            base.Projectile.height = 210;
            base.Projectile.hostile = true;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.penetrate = -1;
            base.Projectile.tileCollide = true;
            base.Projectile.timeLeft = 300;
            base.Projectile.friendly = false;
            this.CooldownSlot = 1;
            base.Projectile.scale = 1f;

        }
        private bool boom = false;
        // Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
        public override void AI()
        {
            Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.01f, 0.01f));
            Projectile.velocity *= 0.995f;
            base.Projectile.width = (int)(210 * Projectile.scale) / 15 * 10;
            base.Projectile.height = (int)(210 * Projectile.scale) / 15 * 10;
            if (Projectile.wet)
            {
                Projectile.timeLeft -= 4;
            }
            for (int o = 0; o < 200; o++)
            {
                if(Main.npc[o].type == 262 && Main.npc[o].active && (Main.npc[o].Center - Projectile.Center).Length() <= 200 && Main.npc[o].life < Main.npc[o].lifeMax)
                {
                    Main.npc[o].life += 1;
                }
            }
            base.Projectile.scale += 0.008f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale * Projectile.timeLeft / 640f, (float)(255 - base.Projectile.alpha) * 1f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.Projectile.timeLeft > 60)
            {
                if (base.Projectile.timeLeft > 250)
                {
                    return new Color?(new Color((300 - base.Projectile.timeLeft) / 500f, (300 - base.Projectile.timeLeft) / 500f, (300 - base.Projectile.timeLeft) / 500f, 0)) * 0.3f;
                }
                else
                {
                    return new Color?(new Color(0.1f, 0.1f, 0.1f, 0)) * 0.3f;
                }
            }
            else
            {
                if (base.Projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.Projectile.timeLeft - 25) / 350f, 0.1f, (base.Projectile.timeLeft - 25) / 350f, 0)) * 0.3f;
                }
                else
                {
                    return new Color?(new Color(base.Projectile.timeLeft / 2100f, base.Projectile.timeLeft / 300f, base.Projectile.timeLeft / 2100f, 0)) * 0.3f;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            return false;
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(20, Projectile.timeLeft * 2, true);
            target.AddBuff(70, Projectile.timeLeft / 2, true);
        }
    }
}
