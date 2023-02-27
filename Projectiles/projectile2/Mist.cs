using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            if (Projectile.Center.Y > mplayer.Cloud - 600)
            {
                Projectile.velocity.Y -= 0.1f;
            }
            base.Projectile.scale += 0.008f;
            if (Main.rand.Next(1500) == 1 && player.Center.Y <= mplayer.Cloud - 400)
            {
                Vector2 v = new Vector2(0, 1.2f).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("CthulhuLight").Type, 40, 0.5f, Main.myPlayer, 10f, 25f);
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.Projectile.timeLeft > 60)
            {
                if (base.Projectile.timeLeft > 250)
                {
                    return new Color?(new Color((300 - base.Projectile.timeLeft) / 500f, (300 - base.Projectile.timeLeft) / 500f, (300 - base.Projectile.timeLeft) / 500f,0));
                }
                else
                {
                    return new Color?(new Color(0.1f, 0.1f, 0.1f, 0));
                }
            }
            else
            {
                if (base.Projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.Projectile.timeLeft - 25) / 350f, (base.Projectile.timeLeft - 25) / 350f, (base.Projectile.timeLeft - 25) / 350f, 0));
                }
                else
                {
                    return new Color?(new Color(base.Projectile.timeLeft / 2100f, base.Projectile.timeLeft / 2100f, base.Projectile.timeLeft / 2100f, 0));
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            //target.AddBuff(31, projectile.timeLeft / 4, true);
        }
    }
}
