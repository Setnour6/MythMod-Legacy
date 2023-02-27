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
using Terraria.ID;

namespace MythMod.Projectiles.projectile3
{
    public class SolarKnife : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("日炎双刀");
            Main.projFrames[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 76;
            base.projectile.height = 74;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 24;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
            projectile.frame = 0;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        private int lz = 0;
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player p = Main.player[Main.myPlayer];
            lz += 1;
            if(lz % 3 == 0)
            {
                if(projectile.frame < 6)
                {
                    projectile.frame++;
                }
                else
                {
                    projectile.frame = 3;
                }
            }
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.position - projectile.velocity - new Vector2(28,27);
            projectile.spriteDirection = -p.direction;
            if (projectile.frame < 6)
            {
                base.projectile.rotation = 0.25f;
            }
            //p.ChangeDir(-base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            if (projectile.timeLeft == 1 && Main.mouseLeft && mplayer.Ry > 0)
            {
                base.projectile.timeLeft = 24;
            }
            if(projectile.timeLeft %4 == 1)
            {
                projectile.friendly = true;
            }
            else
            {
                projectile.friendly = false;
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(189, 900, false);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            Texture2D texture = Main.projectileTexture[projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Player p = Main.player[Main.myPlayer];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture.Width, num)), base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(38, 37), projectile.scale, effects, 0f);
            for (int i = 0; i < 8; i++)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                Main.spriteBatch.Draw(texture, drawPos, new Rectangle?(new Rectangle(0, y, texture.Width, num)), new Color(1f - 1f / 8f * (float)i, 0.3f - 0.3f / 8f * (float)i, 0.5f - 0.5f / 8f * (float)i, (0.8f - 0.8f / 8f * (float)i) * projectile.alpha / 255f), projectile.rotation, new Vector2(38, 37), projectile.scale * (32 - i) / 32f, effects, 0f);
            }
            return false;
        }
    }
}
