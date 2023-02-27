using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Dusts
{
    public class WhiteEffect2 : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 1f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.alpha = 0;
		}
        private int I = 0;
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            if(Main.rand.Next(100) > 2)
            {
                I += 1;
            }
            if(I % 3 == 0)
            {
                if (Main.rand.Next(100) > 2)
                {
                    return new Color?(new Color(dust.scale / 4.7f, dust.scale / 4.7f, dust.scale / 1.5f, 1 - dust.scale));
                }
                else
                {
                    return new Color?(new Color(1f, 1f, 1f, 0));
                }
            }
            else if (I % 3 == 1)
            {
                if (Main.rand.Next(100) > 2)
                {
                    return new Color?(new Color(dust.scale / 4.7f, dust.scale / 3.5f, dust.scale / 4.7f, 1 - dust.scale));
                }
                else
                {
                    return new Color?(new Color(1f, 1f, 1f, 0));
                }
            }
            else
            {
                if (Main.rand.Next(100) > 2)
                {
                    return new Color?(new Color(dust.scale / 1.5f, dust.scale / 4.7f, dust.scale / 4.7f, 1 - dust.scale));
                }
                else
                {
                    return new Color?(new Color(1f, 1f, 1f, 0));
                }
            }
        }
        private float po = 0;
		public override bool Update(Dust dust)
		{
            dust.position += dust.velocity;
            dust.rotation += 0.1f;
            dust.scale *= 0.96f;
            dust.velocity *= 0.95f;
            float scale = dust.scale;
            Lighting.AddLight(dust.position, 0.4f, 0.4f, 0.4f);
            if (dust.scale < 0.15f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
