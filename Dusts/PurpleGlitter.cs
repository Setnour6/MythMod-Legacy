using System;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
	// Token: 0x0200006D RID: 109
    public class PurpleGlitter : ModDust
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x00002B3A File Offset: 0x00000D3A
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			dust.noLight = false;
			dust.scale *= 0.85f;
			dust.alpha = 20;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0003162C File Offset: 0x0002F82C
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.05f;
			dust.scale *= 0.985f;
            dust.alpha = (int)(15 + (0.25 / (float)dust.scale) * 240f);
			float scale = dust.scale;
            Lighting.AddLight(dust.position, 0.12f * (float)dust.scale, 0.05f * (float)dust.scale, 0.16f * (float)dust.scale);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
