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
    public class BubblsChi : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("泡泡剑气");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
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
            if(projectile.timeLeft % 5 == 0)
            {
                Vector2 v = new Vector2(0, 3).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X + v.X, projectile.velocity.Y + v.Y, 405, base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
    }
}
