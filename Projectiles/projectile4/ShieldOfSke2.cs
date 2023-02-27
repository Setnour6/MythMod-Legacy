using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class ShieldOfSke2 : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
            base.projectile.width = 100;
            base.projectile.height = 100;
            base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 360000000;
            base.projectile.usesLocalNPCImmunity = false;
            base.projectile.tileCollide = false;
        }
		public override void AI()
		{
            int K = 0;
            for(int i = 0;i < 200;i++)
            {
                if(Main.npc[i].type ==127)
                {
                    K = i;
                    break;
                }
            }
            projectile.position = Main.npc[K].Center - new Vector2(50, 50) + new Vector2(0, 100).RotatedBy(Main.npc[K].rotation + Math.PI * 0.6666666667);
            projectile.rotation = Main.npc[K].rotation + (float)(Math.PI * 0.6666666667);
        }
    }
}
