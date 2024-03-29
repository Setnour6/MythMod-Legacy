﻿using System;
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
    public class Flashlight2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("手电筒");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 42;
            base.projectile.height = 42;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 2;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private float num4;
        private int ML = 0;
        private int MR = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            projectile.frame = (int)((24 - projectile.timeLeft) / 2f);
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.Center + v - new Vector2(21, 21);
            projectile.spriteDirection = p.direction;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            if(mplayer.SD2 > 0 && mplayer.SD == 17)
            {
                base.projectile.timeLeft = 2;
            }
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            if (projectile.ai[0] == 0)
            {
                float Lig = 1;
                projectile.frame = 1;
                for (int step = 1; step < 30; step++)
                {
                    Lighting.AddLight(base.projectile.Center + step * projectile.velocity, (float)(255 - base.projectile.alpha) * 1.2f / 255f * (30 - (float)step) / 30f * Lig, (float)(255 - base.projectile.alpha) * 1.2f / 255f * (30 - (float)step) / 30f * Lig, (float)(255 - base.projectile.alpha) * 0.6f / 255f * (30 - (float)step) / 30f * Lig);
                }
            }
            if(Main.mouseLeft)
            {
                ML = 1;
            }
            else
            {
                if(ML >= 0)
                {
                    projectile.ai[0] += 1;
                    if (projectile.ai[0] > 2)
                    {
                        projectile.ai[0] = 0;
                    }
                    ML -= 1;
                }
            }
            if (Main.mouseRight)
            {
                MR = 1;
            }
            else
            {
                if (MR >= 0)
                {
                    projectile.ai[0] -= 1;
                    if (projectile.ai[0] < 0)
                    {
                        projectile.ai[0] = 2;
                    }
                    MR -= 1;
                }
            }
            if (projectile.ai[0] == 1)
            {
                projectile.frame = 0;
            }
            if (projectile.ai[0] == 2)
            {
                if(Main.time % 30 > 15)
                {
                    projectile.frame = 0;
                }
                else
                {
                    float Lig = 1;
                    projectile.frame = 1;
                    for (int step = 1; step < 30; step++)
                    {
                        Lighting.AddLight(base.projectile.Center + step * projectile.velocity, (float)(255 - base.projectile.alpha) * 1.2f / 255f * (30 - (float)step) / 30f * Lig, (float)(255 - base.projectile.alpha) * 1.2f / 255f * (30 - (float)step) / 30f * Lig, (float)(255 - base.projectile.alpha) * 0.6f / 255f * (30 - (float)step) / 30f * Lig);
                    }
                }
            }
            p.direction = projectile.spriteDirection;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num17 = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num17 * base.projectile.frame;
            Vector2 origin = new Vector2(10.5f, 10.5f);
            //spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/手电筒Glow"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num17)), new Color(255, 255, 255, 0), base.projectile.rotation, origin, base.projectile.scale, effects, 0f);
        }
    }
}
