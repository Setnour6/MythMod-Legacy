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
using Terraria.ID;
namespace MythMod.Projectiles
{
    public class 花刺 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("花刺");
        }
        private bool num100 = true;
        private Vector2 v = new Vector2(0, 0);
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = (int)1.5f;
            Projectile.timeLeft = 180;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
        }
        public override void AI()
        {
            base.Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            if (Projectile.timeLeft % 45 == 0 && Projectile.hostile)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector2 v = new Vector2(0, 100).RotatedByRandom(Math.PI * 2) * 0.01f;
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, (Main.rand.Next(0, 200) > 180 ? 275 : 276), base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, base.Projectile.ai[0] + 1, 0f);
                }
            }
        }
    }
}