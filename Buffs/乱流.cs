using System;
using Terraria;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 乱流 : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("乱流");
            // base.Description.SetDefault("强劲力场混乱");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
        private Vector2 v = new Vector2(0, 0);
		public override void Update(Player player, ref int buffIndex)
		{
            if(v == new Vector2(0, 0))
            {
                v = new Vector2(Main.rand.NextFloat(-1f,1f), Main.rand.NextFloat(-1f, 1f));
            }
            if(v.Length() < 0.05f)
            {
                v *= 1.05f;
            }
            if (v.Length() > 1f)
            {
                v *= 0.95f;
            }
            v = v.RotatedBy(Main.rand.NextFloat(-0.1f, 0.1f)) * Main.rand.NextFloat(0.99f, 1.01f);
            player.velocity += v;
            if(player.velocity.Length() > 10)
            {
                player.velocity *= 0.95f;
            }
        }
	}
}
