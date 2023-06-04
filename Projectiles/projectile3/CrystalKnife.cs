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
            // base.DisplayName.SetDefault("晶状体短刃");
            Main.projFrames[Projectile.type] = 12;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 24;
            base.Projectile.height = 26;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 24;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            Projectile.frame = (int)((24 - Projectile.timeLeft) / 2f);
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.position + v + new Vector2(0, 10);
            Projectile.spriteDirection = p.direction;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction);
            if(Projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.Projectile.timeLeft = 24;
            }
            if(p.dead)
            {
                Projectile.Kill();
            }
            if(Projectile.timeLeft %4 == 1)
            {
                Projectile.friendly = true;
            }
            else
            {
                Projectile.friendly = false;
            }
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0));
        }
    }
}
