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
    public class EvilFlashlight : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("恶魔手电筒");
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 42;
            base.Projectile.height = 42;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 2;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
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
            Projectile.frame = (int)((24 - Projectile.timeLeft) / 2f);
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.Center + v - new Vector2(21, 21);
            Projectile.spriteDirection = p.direction;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            if(mplayer.SD2 > 0 && mplayer.SD == 8)
            {
                base.Projectile.timeLeft = 2;
            }
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            if (Projectile.ai[0] == 0)
            {
                float Lig = 1;
                Projectile.frame = 1;
                for (int step = 1; step < 30; step++)
                {
                    Lighting.AddLight(base.Projectile.Center + step * Projectile.velocity, (float)(255 - base.Projectile.alpha) * 1f / 255f * (25 - (float)step) / 30f * Lig, (float)(255 - base.Projectile.alpha) * 4f / 255f * (7 - (float)step) / 30f * Lig, (float)(255 - base.Projectile.alpha) * 1.5f / 255f * (30 - (float)step) / 30f * Lig);
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
                    Projectile.ai[0] += 1;
                    if (Projectile.ai[0] > 2)
                    {
                        Projectile.ai[0] = 0;
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
                    Projectile.ai[0] -= 1;
                    if (Projectile.ai[0] < 0)
                    {
                        Projectile.ai[0] = 2;
                    }
                    MR -= 1;
                }
            }
            if (Projectile.ai[0] == 1)
            {
                Projectile.frame = 0;
            }
            if (Projectile.ai[0] == 2)
            {
                if(Main.time % 30 > 15)
                {
                    Projectile.frame = 0;
                }
                else
                {
                    float Lig = 1;
                    Projectile.frame = 1;
                    for (int step = 1; step < 30; step++)
                    {
                        Lighting.AddLight(base.Projectile.Center + step * Projectile.velocity, (float)(255 - base.Projectile.alpha) * 1f / 255f * (25 - (float)step) / 30f * Lig, (float)(255 - base.Projectile.alpha) * 4f / 255f * (7 - (float)step) / 30f * Lig, (float)(255 - base.Projectile.alpha) * 1.5f / 255f * (30 - (float)step) / 30f * Lig);
                    }
                }
            }
            p.direction = Projectile.spriteDirection;
        }
    }
}
