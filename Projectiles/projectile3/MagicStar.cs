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
    public class MagicStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("魔星");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.tileCollide = false;
        }
        public override void AI()
        {
            projectile.rotation += 0.15f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 3f / 255f);
            Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 3.5f)).RotatedByRandom(Math.PI * 2);
            Dust.NewDust(projectile.Center, 2, 2, 132, 0f, 0f, 0, default(Color), (float)projectile.scale * 1.2f);
            if(projectile.timeLeft == 550)
            {
                projectile.tileCollide = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 12; i++)
            {
                int num = Dust.NewDust(projectile.Center, 2, 2, 191, 0f, 0f, 0, default(Color), (float)projectile.scale * 1.2f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 3.5f)).RotatedByRandom(Math.PI * 2);
;               Dust.NewDust(projectile.Center, 2, 2, 132, 0f, 0f, 0, default(Color), (float)projectile.scale * 1.2f);
            }
            for (int k = 0; k <= 15; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360f * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.08f, (float)((float)l * Math.Sin((float)a)) * 0.08f, base.mod.ProjectileType("MagicLightBullet2"), base.projectile.damage / 6, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
        }
    }
}
