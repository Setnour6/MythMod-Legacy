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
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 3600;
			base.Projectile.alpha = 0;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
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
                Projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, Mod.Find<ModProjectile>("TuskDamage").Type, Projectile.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                }

            }
            if(stick && !m.active)
            {
                Projectile.active = false;
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = Projectile.position - target.position;
            Projectile.friendly = false;
            m = target;
            if(!target.boss)
            {
                target.defense /= 2;
            }
        }
    }
}
