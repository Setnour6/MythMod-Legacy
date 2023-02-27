using System;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Dusts
{
	// Token: 0x0200006D RID: 109
    public class MoonLight : ModDust
	{
		// Token: 0x060001C5 RID: 453 RVA: 0x00002B3A File Offset: 0x00000D3A
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.1f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 0.5f;
			dust.alpha = 50;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0003162C File Offset: 0x0002F82C
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.05f;
			dust.scale *= 0.99f;
			float scale = dust.scale;
			Lighting.AddLight(dust.position, 0.4f, 0.8f, 1f);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
