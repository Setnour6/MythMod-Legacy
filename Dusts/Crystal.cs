using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Dusts
{
    public class Crystal : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
            //dust.velocity = new Vector2(0, Main.rand.NextFloat(0, 1.5f)).RotatedByRandom(Math.PI * 2);
			dust.noGravity = true;
            dust.noLight = false ;
			dust.scale *= 1f;
			dust.alpha = 0;
		}
        private int iy = 0;
        private float T = 0;
        private bool fad = true;
        public override bool Update(Dust dust)
		{
            if(iy == 0)
            {
                iy = (int)(Math.Sin(dust.fadeIn) * 1000);
            }
            iy++;
            dust.position += dust.velocity;
            dust.velocity *= 0.98f;
            dust.rotation += 0.1f;
			dust.scale *= (float)(0.98 + Math.Sin(iy / (float)((1.2 + Math.Cos(Math.Sin(dust.fadeIn * 5d)) * 0.55f) * 50d)) * 0.2);
            if (fad)
            {
                if (dust.fadeIn > 0.95f && dust.scale < 0.7f)
                {
                    fad = false;
                }
            }
            if(!fad)
            {
                dust.scale *= dust.fadeIn;
                if (dust.fadeIn > 1)
                {
                    dust.fadeIn *= 0.995f;
                }
            }
            if(dust.scale > 3)
            {
                dust.scale *= 0.6f;
            }
            float scale = dust.scale;
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
            if(!dust.noGravity)
            {
                dust.velocity.Y += 0.025f;
            }
			return false;
		}
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0));
        }
    }
}
