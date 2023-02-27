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
    public class CrystalKnife : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("晶状体短刃");
            Main.projFrames[projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 24;
            base.projectile.height = 26;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 24;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            projectile.frame = (int)((24 - projectile.timeLeft) / 2f);
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.position + v + new Vector2(0, 10);
            projectile.spriteDirection = p.direction;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y * p.direction, (double)base.projectile.velocity.X * p.direction);
            if(projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.projectile.timeLeft = 24;
            }
            if(p.dead)
            {
                projectile.Kill();
            }
            if(projectile.timeLeft %4 == 1)
            {
                projectile.friendly = true;
            }
            else
            {
                projectile.friendly = false;
            }
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0));
        }
    }
}
