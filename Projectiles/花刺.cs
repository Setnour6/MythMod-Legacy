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
            projectile.width = 6;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = (int)1.5f;
            projectile.timeLeft = 180;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
        }
        public override void AI()
        {
            base.projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (projectile.timeLeft % 45 == 0 && projectile.hostile)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector2 v = new Vector2(0, 100).RotatedByRandom(Math.PI * 2) * 0.01f;
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, (Main.rand.Next(0, 200) > 180 ? 275 : 276), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, base.projectile.ai[0] + 1, 0f);
                }
            }
        }
    }
}