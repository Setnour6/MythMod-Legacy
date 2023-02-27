using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Dusts
{
    public class PurpleFlame : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 1f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.alpha = 0;
		}
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color?(new Color(0,0,0, 0));
        }
        private float po = 0;
		public override bool Update(Dust dust)
		{
            dust.position += dust.velocity;
            dust.scale *= 0.95f;
            dust.velocity *= 0.95f;
            float scale = dust.scale;
            /*if(dust.velocity.Y > -1f)
            {
                dust.velocity.Y -= 0.05f;
            }*/
            Lighting.AddLight(dust.position, 0.2f * dust.scale, 0f, 0.4f * dust.scale);
            if (dust.scale < 0.15f)
			{
				dust.active = false;
			}
			return false;
		}
    }
}
