using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile3
{
    public class TangerineBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("桔之锋");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                X = (float)Math.Sqrt((double)projectile.velocity.X * (double)projectile.velocity.X + (double)projectile.velocity.Y * (double)projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Sin(-(double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 580 && projectile.timeLeft >= 100 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 100+ (float)b)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft < 800)
            {
                projectile.velocity.Y += 0.01f;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int u = 0; u < 8; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Tangerine2"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
                v = new Vector2(0, Main.rand.NextFloat(2f, 3.5f)).RotatedByRandom(Math.PI * 2f);
                int tg = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("TangerineLeaf"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[tg].hostile = false;
                Main.projectile[tg].friendly = true;
            }
            for (int u = 0; u < 5; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("TangerineRay"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 60;
            }
            for (int u = 0; u < 5; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("TenderGreenRay"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 60;
            }
        }
    }
}