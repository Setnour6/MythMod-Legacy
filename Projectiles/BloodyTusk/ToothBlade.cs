using System;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.BloodyTusk
{
    public class ToothBlade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("ToothBlade");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 3600;
			base.projectile.alpha = 0;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
        private bool stick = false;
        private int u = 0;
        private NPC m = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        private int r = 0;
        private float r2 = 0;
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            if(stick && m.active)
            {
                r += 1;
                float yz = m.Hitbox.Width * m.Hitbox.Width + m.Hitbox.Height * m.Hitbox.Height;
                yz = (float)(Math.Sqrt(yz)) / 3f;
                projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, mod.ProjectileType("TuskDamage"), projectile.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                }

            }
            if(stick && !m.active)
            {
                projectile.active = false;
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = projectile.position - target.position;
            projectile.friendly = false;
            m = target;
            if(!target.boss)
            {
                target.defense /= 2;
            }
        }
    }
}
