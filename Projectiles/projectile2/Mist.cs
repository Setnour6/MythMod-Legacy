using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
    public class Mist : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("雾气");
        }
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
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            if (projectile.Center.Y > mplayer.Cloud - 600)
            {
                projectile.velocity.Y -= 0.1f;
            }
            base.projectile.scale += 0.008f;
            if (Main.rand.Next(1500) == 1 && player.Center.Y <= mplayer.Cloud - 400)
            {
                Vector2 v = new Vector2(0, 1.2f).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("CthulhuLight"), 40, 0.5f, Main.myPlayer, 10f, 25f);
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.projectile.timeLeft > 60)
            {
                if (base.projectile.timeLeft > 250)
                {
                    return new Color?(new Color((300 - base.projectile.timeLeft) / 500f, (300 - base.projectile.timeLeft) / 500f, (300 - base.projectile.timeLeft) / 500f,0));
                }
                else
                {
                    return new Color?(new Color(0.1f, 0.1f, 0.1f, 0));
                }
            }
            else
            {
                if (base.projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.projectile.timeLeft - 25) / 350f, (base.projectile.timeLeft - 25) / 350f, (base.projectile.timeLeft - 25) / 350f, 0));
                }
                else
                {
                    return new Color?(new Color(base.projectile.timeLeft / 2100f, base.projectile.timeLeft / 2100f, base.projectile.timeLeft / 2100f, 0));
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            return false;
        }
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
            //target.AddBuff(31, projectile.timeLeft / 4, true);
        }
    }
}
