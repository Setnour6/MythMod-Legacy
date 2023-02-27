using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class PriSkeHurt : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("骷髅王判伤");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "机械骷髅王");
		}
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 40;
			base.npc.height = 80;
			base.npc.defense = 0;
			base.npc.lifeMax = 31500;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 255;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.dontTakeDamage = false;
		}
		public override void AI()
        {
		}
	}
}
