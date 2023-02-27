using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
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
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 48;
            base.Projectile.height = 48;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 300;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
        }
        private float omega = 0;
        private float num4;
        private int ML = 0;
        private int MR = 0;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + (float)Math.PI / 4f;
            if(Projectile.timeLeft > 120)
            {
                if(Projectile.velocity.Length() > 0.0000000000001f)
                {
                    Projectile.velocity *= 0.1f;
                }
                Dust.NewDust(Projectile.Center + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2d), 0, 0, 6);
            }
            else
            {
                if(Projectile.timeLeft == 40)
                {
                    SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花冲天"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                }
                if (Projectile.velocity.Length() < 10f)
                {
                    Projectile.velocity *= 1.5f;
                }
                Dust.NewDust(Projectile.Center + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2d), 0, 0, 6);
                int u = Dust.NewDust(Projectile.Center + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 0.5f);
                Main.dust[u].velocity *= 0;
                if (Projectile.velocity.Length() > 1f)
                {
                    Projectile.hostile = true;
                    if (Math.Abs(omega) < 0.1f)
                    {
                        omega += Main.rand.NextFloat(-0.015f, 0.015f);
                    }
                    else
                    {
                        omega *= 0.99f;
                    }
                }
                Projectile.velocity = Projectile.velocity.RotatedBy(omega);
            }
        }
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(base.Projectile.Center.X + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2).X, base.Projectile.Center.Y + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2).Y, 0, 0, Mod.Find<ModProjectile>("爆炸鞭炮").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Gore.NewGore(Projectile.position, new Vector2(0, 0), Mod.GetGoreSlot("Gores/窜天猴放完"), 1f);
            Dust.NewDust(Projectile.Center + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 4f);
            Dust.NewDust(Projectile.Center + new Vector2(12, 12).RotatedBy(Projectile.rotation - Math.PI / 2d), 0, 0, 188, 0, 0, 200, default(Color), 5f);
            base.Kill(timeLeft);
        }
    }
}
