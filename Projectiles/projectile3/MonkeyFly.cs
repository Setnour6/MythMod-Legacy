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
    public class MonkeyFly : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("窜天猴");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.projectile.width = 48;
            base.projectile.height = 48;
            base.projectile.friendly = false;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 300;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.tileCollide = false;
        }
        private float omega = 0;
        private float num4;
        private int ML = 0;
        private int MR = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + (float)Math.PI / 4f;
            if(projectile.timeLeft > 120)
            {
                if(projectile.velocity.Length() > 0.0000000000001f)
                {
                    projectile.velocity *= 0.1f;
                }
                Dust.NewDust(projectile.Center + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2d), 0, 0, 6);
            }
            else
            {
                if(projectile.timeLeft == 40)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花冲天"), (int)projectile.Center.X, (int)projectile.Center.Y);
                }
                if (projectile.velocity.Length() < 10f)
                {
                    projectile.velocity *= 1.5f;
                }
                Dust.NewDust(projectile.Center + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2d), 0, 0, 6);
                int u = Dust.NewDust(projectile.Center + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 0.5f);
                Main.dust[u].velocity *= 0;
                if (projectile.velocity.Length() > 1f)
                {
                    projectile.hostile = true;
                    if (Math.Abs(omega) < 0.1f)
                    {
                        omega += Main.rand.NextFloat(-0.015f, 0.015f);
                    }
                    else
                    {
                        omega *= 0.99f;
                    }
                }
                projectile.velocity = projectile.velocity.RotatedBy(omega);
            }
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(base.projectile.Center.X + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2).X, base.projectile.Center.Y + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2).Y, 0, 0, mod.ProjectileType("爆炸鞭炮"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Gore.NewGore(projectile.position, new Vector2(0, 0), mod.GetGoreSlot("Gores/窜天猴放完"), 1f);
            Dust.NewDust(projectile.Center + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 4f);
            Dust.NewDust(projectile.Center + new Vector2(12, 12).RotatedBy(projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 5f);
            base.Kill(timeLeft);
        }
    }
}
