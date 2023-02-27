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
            base.Projectile.width = 28;
            base.Projectile.height = 28;
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
            if(Projectile.timeLeft % 5 == 0)
            {
                Vector2 v = new Vector2(0, 3).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Projectile.velocity.X + v.X, Projectile.velocity.Y + v.Y, 405, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
    }
}
