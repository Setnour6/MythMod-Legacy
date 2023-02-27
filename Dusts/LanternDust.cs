using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
    public class LanternDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.1f;
			dust.noGravity = true;
            dust.noLight = false ;
			dust.scale *= 1f;
			dust.alpha = 0;
		}
        protected bool Inteliz = true;
        protected float Leng = 10000;
        protected int Ppoi = -1;
        public override bool Update(Dust dust)
		{
            for (int t = 0; t < 1000; t++)
            {
                if (Main.projectile[t].type == Mod.Find<ModProjectile>("ExplodeLantern").Type && Main.projectile[t].active)
                {
                    float L = (dust.position - Main.projectile[t].Center).Length();
                    if (L < Leng)
                    {
                        Leng = L;
                        Ppoi = t;
                        if (Leng < 5)
                        {
                            dust.active = false;
                        }
                    }
                }
            }
            if (Ppoi != -1)
            {
                dust.position += (Main.projectile[Ppoi].Center - dust.position) / (Main.projectile[Ppoi].Center - dust.position).Length() * 2;
                dust.scale += 0.05f;
            }
            else
            {
                dust.active = false;
            }
            if ((dust.position - Main.projectile[Ppoi].Center).Length() < 5)
            {
                dust.active = false;
            }
            dust.rotation += 0.1f;
			float scale = dust.scale;
			return false;
		}
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color?(new Color(0.3f, 0.3f, 0.3f, 1f));
        }
    }
}
