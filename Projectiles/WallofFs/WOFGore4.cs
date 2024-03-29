﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.WallofFs
{
    public class WOFGore4 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("被诅咒的肉碎片");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
            projectile.hostile = true;
            projectile.friendly = false;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 3600000;
        }
        public float scal = 0f;
        public float scalMax = 1f;
        public float scalx = 1f;
        public Vector2 v = new Vector2(0,0);
        public override void AI()
		{
            projectile.velocity *= 0;
            if (projectile.timeLeft >= 3600000)
            {
                v = projectile.position;
                projectile.rotation = Main.rand.NextFloat(0, (float)(Math.PI * 2));
            }
            Vector2 vk = new Vector2(0,Main.rand.NextFloat(0,6f)).RotatedByRandom(Math.PI * 2);
            projectile.position = v + vk;
            if(NPC.CountNPCS(113) <= 0)
            {
                projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 120; i++)
            {
                Vector2 vz = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 5, 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = vz;
            }
        }
    }
}
