using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Dusts
{
    public class WhiteEffect : ModDust
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
            return new Color?(new Color(dust.velocity.Length() / 10f, dust.velocity.Length() / 10f, dust.velocity.Length() / 10f, 0));
        }
        private float po = 0;
		public override bool Update(Dust dust)
		{
            dust.position += dust.velocity;
            dust.rotation += 0.1f;
            dust.scale *= 0.95f;
            dust.velocity *= 0.95f;
            float scale = dust.scale;
            Lighting.AddLight(dust.position, 1f, 1f, 1f);
            if (dust.scale < 0.15f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
