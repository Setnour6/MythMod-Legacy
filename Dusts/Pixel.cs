using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
    public class Pixel : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.1f;
			dust.noGravity = true;
            dust.noLight = false ;
			dust.scale *= 1f;
			dust.alpha = 255;
		}
        private float St = 0;
		public override bool Update(Dust dust)
		{
            Player player = Main.player[Main.myPlayer];
            dust.position += dust.velocity;
            dust.rotation += 0.1f;
			dust.scale *= 0.98f;
			float scale = dust.scale;
			Lighting.AddLight(dust.position, 1 * (255 - dust.alpha) / 255f, 1 * (255 - dust.alpha) / 255f, 1 * (255 - dust.alpha) / 255f);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
            if(!dust.noGravity)
            {
                dust.velocity.Y += 0.05f;
            }

            //for(int i = 0; i < 200;i++)
            //{
            //    if((Main.npc[i].Center - dust.position).Length() < 10 && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
            //    {
            //        Main.npc[i].StrikeNPC((int)(20000 * Main.rand.NextFloat(0.8f, 1.2f)) / 3 * 2, 0, (int)(Main.npc[i].velocity.X / Math.Abs(Main.npc[i].velocity.X)), false, false, false);
            //    }
            //}
            return false;
		}
    }
}
