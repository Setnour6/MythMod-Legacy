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
using Terraria.ID;

namespace MythMod.Projectiles.projectile3
{
    public class SolarKnife : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("日炎双刀");
            Main.projFrames[Projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 76;
            base.Projectile.height = 74;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 24;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
            Projectile.frame = 0;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        private int lz = 0;
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player p = Main.player[Main.myPlayer];
            lz += 1;
            if(lz % 3 == 0)
            {
                if(Projectile.frame < 6)
                {
                    Projectile.frame++;
                }
                else
                {
                    Projectile.frame = 3;
                }
            }
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.position - Projectile.velocity - new Vector2(28,27);
            Projectile.spriteDirection = -p.direction;
            if (Projectile.frame < 6)
            {
                base.Projectile.rotation = 0.25f;
            }
            //p.ChangeDir(-base.projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            if (Projectile.timeLeft == 1 && Main.mouseLeft && mplayer.Ry > 0)
            {
                base.Projectile.timeLeft = 24;
            }
            if(Projectile.timeLeft %4 == 1)
            {
                Projectile.friendly = true;
            }
            else
            {
                Projectile.friendly = false;
            }
            for(int i = 0;i < 1000;i++)
            {
                if(Main.projectile[i].hostile && (Main.projectile[i].Center - p.Center).Length() < 50)
                {
                    Main.projectile[i].friendly = true;
                    Main.projectile[i].hostile = false;
                    Main.projectile[i].damage *= 10;
                    Main.projectile[i].position -= Main.projectile[i].velocity * 2;
                    Main.projectile[i].velocity = -Main.projectile[i].velocity;
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 0.3f, 0.5f, 0.2f));
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(189, 900, false);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            if (Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Player p = Main.player[Main.myPlayer];
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(38, 37), Projectile.scale, effects, 0f);
            for (int i = 0; i < 8; i++)
            {
                Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                Main.spriteBatch.Draw(texture, drawPos, new Rectangle?(new Rectangle(0, y, texture.Width, num)), new Color(1f - 1f / 8f * (float)i, 0.3f - 0.3f / 8f * (float)i, 0.5f - 0.5f / 8f * (float)i, (0.8f - 0.8f / 8f * (float)i) * Projectile.alpha / 255f), Projectile.rotation, new Vector2(38, 37), Projectile.scale * (32 - i) / 32f, effects, 0f);
            }
            return false;
        }
    }
}
