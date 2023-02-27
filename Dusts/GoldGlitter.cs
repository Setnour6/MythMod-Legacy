using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
	// Token: 0x0200006D RID: 109
    public class GoldGlitter : ModDust
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x00002B3A File Offset: 0x00000D3A
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 0.85f;
            dust.alpha = 15;
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.05f;
			dust.scale *= 0.9f;
            dust.alpha = (int)(15 + (0.25 / (float)dust.scale) * 240f);
			float scale = dust.scale;
            Lighting.AddLight(dust.position, 0.6196f * (float)dust.scale / 1.8f, 0.4855f * (float)dust.scale / 1.8f, 0.0758f * (float)dust.scale / 1.8f);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
