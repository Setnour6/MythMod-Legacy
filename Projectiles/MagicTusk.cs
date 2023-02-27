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

namespace MythMod.Projectiles
{
    public class MagicTusk : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("附魔獠牙");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 26;
            base.projectile.height = 26;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
        }
        public override void AI()
        {
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 6f, 0, 0, 90, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.0f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(155, 155, 155, 0));
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 2.5f)).RotatedByRandom(Math.PI * 2);
                Dust.NewDust(projectile.Center, 2, 2, 90, v.X,v.Y, 0, default(Color), (float)projectile.scale * 1.2f);
            }
            for (int y = 0; y < 4; y++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(200, 600)).RotatedByRandom(MathHelper.TwoPi);
                Vector2 v2 = new Vector2(-v.X / 7500f, -v.Y / 7500f).RotatedBy(Main.rand.NextFloat(-0.05f, 0.05f));
                Projectile.NewProjectile(projectile.Center.X + v.X, projectile.Center.Y + v.Y, v2.X, v2.Y, mod.ProjectileType("RedCrack2"), projectile.damage / 3, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
