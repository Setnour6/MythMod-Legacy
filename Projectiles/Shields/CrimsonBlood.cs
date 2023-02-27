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

namespace MythMod.Projectiles.Shields
{
    public class CrimsonBlood : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("猩红之躯");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 30;
            base.projectile.height = 30;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 2;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private int D = 0;
        private float num4;
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
            projectile.position = p.Center + v - new Vector2(15, 15);
            projectile.spriteDirection = p.direction;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction) + (float)Math.PI / 4f * projectile.spriteDirection;
            if(mplayer.SD2 > 0 && mplayer.SD == 5)
            {
                base.projectile.timeLeft = 2;
            }
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            //p.direction = projectile.spriteDirection;
            for(int i = 0;i < 1000;i++)
            {
                if(Main.projectile[i].hostile)
                {
                    if(Math.Abs(Math.Atan2((Main.projectile[i].Center - p.Center).X, (Main.projectile[i].Center - p.Center).Y) - Math.Atan2((projectile.Center - p.Center).X, (projectile.Center - p.Center).Y)) < 0.8)
                    {
                        if ((Main.projectile[i].Center + Main.projectile[i].velocity - p.Center).Length() > 0 && (Main.projectile[i].Center + Main.projectile[i].velocity - p.Center).Length() <= 48)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                }
            }
        }
    }
}
