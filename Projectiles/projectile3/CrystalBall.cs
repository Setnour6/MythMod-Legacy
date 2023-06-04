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
            // base.DisplayName.SetDefault("CrystalBall");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 48;
            base.Projectile.height = 48;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
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
        private int ud = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            ud += 1;
            Player p = Main.player[Main.myPlayer];
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.position + v - new Vector2(12, 0);
            if (Projectile.timeLeft == 1 && Main.mouseLeft && !p.dead)
            {
                base.Projectile.timeLeft = 24;
            }
            if (p.dead)
            {
                Projectile.Kill();
            }
            if (Projectile.timeLeft % 4 == 1)
            {
                Projectile.friendly = true;
            }
            else
            {
                Projectile.friendly = false;
            }
            if(ud % 3 == 1)
            {
                Projectile.NewProjectile(base.Projectile.Center.X + Main.rand.Next(-900, 900), base.Projectile.Center.Y + Main.rand.Next(-1500, -1100), Main.rand.NextFloat(-2f, 2f), 30f, base.Mod.Find<ModProjectile>("CrystalSword10").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            if(p.statMana <= 2)
            {
                Projectile.Kill();
                p.statMana = 2;
            }
            p.statMana -= 2;
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            p.itemTime = 2;
            p.itemAnimation = 2;
            p.itemRotation = (float)Math.Atan2((double)(base.Projectile.velocity.Y * (float)base.Projectile.direction), (double)(base.Projectile.velocity.X * (float)base.Projectile.direction));
        }
    }
}
