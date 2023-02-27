using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class ShieldOfSke1 : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
            base.Projectile.width = 100;
            base.Projectile.height = 100;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 360000000;
            base.Projectile.usesLocalNPCImmunity = false;
            base.Projectile.tileCollide = false;
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
            Projectile.position = Main.npc[K].Center - new Vector2(50, 50) + new Vector2(0, 100).RotatedBy(Main.npc[K].rotation);
            Projectile.rotation = Main.npc[K].rotation;
        }
    }
}
