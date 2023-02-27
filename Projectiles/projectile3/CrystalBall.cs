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
    public class CrystalBall : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("CrystalBall");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 48;
            base.projectile.height = 48;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            projectile.magic = true;
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
        private int ud = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            ud += 1;
            Player p = Main.player[Main.myPlayer];
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            projectile.velocity = v * 15f;
            projectile.position = p.position + v - new Vector2(12, 0);
            if (projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.projectile.timeLeft = 24;
            }
            if (p.dead)
            {
                projectile.Kill();
            }
            if (projectile.timeLeft % 4 == 1)
            {
                projectile.friendly = true;
            }
            else
            {
                projectile.friendly = false;
            }
            if(ud % 3 == 1)
            {
                Projectile.NewProjectile(base.projectile.Center.X + Main.rand.Next(-900, 900), base.projectile.Center.Y + Main.rand.Next(-1500, -1100), Main.rand.NextFloat(-2f, 2f), 30f, base.mod.ProjectileType("CrystalSword10"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            if(p.statMana <= 2)
            {
                projectile.Kill();
                p.statMana = 2;
            }
            p.statMana -= 2;
            p.ChangeDir(base.projectile.direction);
            p.heldProj = base.projectile.whoAmI;
            p.itemTime = 2;
            p.itemAnimation = 2;
            p.itemRotation = (float)Math.Atan2((double)(base.projectile.velocity.Y * (float)base.projectile.direction), (double)(base.projectile.velocity.X * (float)base.projectile.direction));
        }
    }
}
