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
            base.Projectile.width = 26;
            base.Projectile.height = 26;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
        }
        public override void AI()
        {
            int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity * 6f, 0, 0, 90, 0f, 0f, 100, default(Color), 1.2f);
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
                Dust.NewDust(Projectile.Center, 2, 2, 90, v.X,v.Y, 0, default(Color), (float)Projectile.scale * 1.2f);
            }
            for (int y = 0; y < 4; y++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(200, 600)).RotatedByRandom(MathHelper.TwoPi);
                Vector2 v2 = new Vector2(-v.X / 7500f, -v.Y / 7500f).RotatedBy(Main.rand.NextFloat(-0.05f, 0.05f));
                Projectile.NewProjectile(Projectile.Center.X + v.X, Projectile.Center.Y + v.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("RedCrack2").Type, Projectile.damage / 3, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
