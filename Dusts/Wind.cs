using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
    public class Wind : ModDust
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
            dust.position += dust.velocity + player.velocity;
            dust.rotation += 0.1f;
			dust.scale *= 0.99f;
			float scale = dust.scale;
			Lighting.AddLight(dust.position, 1 * (255 - dust.alpha) / 255f, 1 * (255 - dust.alpha) / 255f, 1 * (255 - dust.alpha) / 255f);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            if(Main.mouseRight && St < 800)
            {
                St += 0.005f;
            }
            if(!Main.mouseRight && St > 0)
            {
                St -= 0.002f;
            }
            dust.velocity = ((v - dust.position) / ((v - dust.position).Length() * (v - dust.position).Length()) * St).RotatedBy((Math.PI / 2d) / (v - dust.position).Length() * 50f);
            dust.alpha = (int)(v - dust.position).Length() > 255 ? 255 : (int)(v - dust.position).Length();
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
