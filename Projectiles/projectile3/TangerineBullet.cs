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
    public class TangerineBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("桔子弹");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 5;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
        }
        public override void AI()
        {
            if(projectile.timeLeft <= 597)
            {
                int num5 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 1f);
                Main.dust[num5].noGravity = true;
                Main.dust[num5].velocity = new Vector2(0, 0);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 1f);
            }
            projectile.width = 100;
            projectile.height = 100;
            projectile.position = projectile.position - new Vector2(36, 36);
        }
    }
}
