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
			// base.DisplayName.SetDefault("骷髅王判伤");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "机械骷髅王");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 40;
			base.NPC.height = 80;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 31500;
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 255;
            base.NPC.boss = false;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.dontTakeDamage = false;
		}
		public override void AI()
        {
		}
	}
}
