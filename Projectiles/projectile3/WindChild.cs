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
    public class WindChild : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("风之子");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 54;
            base.projectile.height = 54;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 26;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private float num4;
        private float Dx = 0;
        private int k = 0;
        private int l = 0;
        private int D = -1;
        private Vector2 v = new Vector2(1, 0);
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            p.AddBuff(mod.BuffType("WindSprite1"), 3600, true);
            if (projectile.timeLeft == 16)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("WindSprite1"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (projectile.timeLeft == 14)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("WindSprite2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            if (Main.time % 8 == 1)
            {
                if (projectile.frame < 5)
                {
                    projectile.frame += 1;
                }
                else
                {
                    projectile.frame = 0;
                }
            }
            if (k == 0)
            {
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                k += 1;
            }
            v = v / v.Length();
            projectile.velocity = v * 20f;
            projectile.position = p.Center + v - new Vector2(27, 27);
            projectile.spriteDirection = D;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            //p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            projectile.alpha = 0;
            k = 1;
            l += 1;
            if (l <= 27)
            {
                v = v.RotatedBy(0.1011f * D);
            }
            else
            {
                if (Main.mouseX > Main.screenWidth / 2)
                {
                    p.direction = 1;
                }
                else
                {
                    p.direction = -1;
                }
                D = p.direction;
                v = new Vector2(-D * 15f, -75);
                l = 0;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
                int y = num * base.projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255, 255, 255, 0), base.projectile.rotation + (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
            }
            else
            {
                Texture2D texture2D = Main.projectileTexture[base.projectile.type];
                int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
                int y = num * base.projectile.frame;
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/WindChildGlow"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), new Color(255,255,255,0), base.projectile.rotation - (float)Math.PI / 2f, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, effects, 0f);
            }
            return false;
        }
    }
}
