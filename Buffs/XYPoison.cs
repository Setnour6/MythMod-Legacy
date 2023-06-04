using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Buffs
{
    public class XYPoison : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("");
            // base.Description.SetDefault("");
			Main.debuff[base.Type] = true;
		}
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = -1080;
            Dust.NewDust(npc.position, npc.width, npc.height, 235, 0, 0, 0, default(Color), 1f);
            if(Main.rand.Next(5) == 1)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, Mod.Find<ModDust>("RedEffect").Type, 0, 0, 0, default(Color), 1f);
            }
            Dust.NewDust(npc.position, npc.width, npc.height, 87, 0, 0, 0, default(Color), 1f);
            base.Update(npc, ref buffIndex);
        }
    }
}
