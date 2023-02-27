using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
	public class LanternMoonScreenShaderData : ScreenShaderData
	{
		public LanternMoonScreenShaderData(string passName) : base(passName)
		{
		}
		private void UpdateDoGIndex()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.LanternMoon)
			{
				return;
			}
		}
		public override void Apply()
		{
			this.UpdateDoGIndex();
			base.Apply();
		}
		private int DoGIndex;
	}
}
