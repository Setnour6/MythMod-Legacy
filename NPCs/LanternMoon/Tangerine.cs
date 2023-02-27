using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Input;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Skies;


namespace MythMod.NPCs.LanternMoon
{
    public class Tangerine : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("berry Sweat Slime");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "大橘子");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 182;
			base.NPC.width = 40;
			base.NPC.height = 40;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 1;
			base.NPC.knockBackResist = 0f;
            base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.scale = 1;
            base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
        }
        public override void AI()
        {
            NPC.rotation += NPC.ai[0];
            if (NPC.velocity.Y < 9)
            {
                NPC.velocity.Y += 0.15f;
            }
            if (base.NPC.collideX || base.NPC.collideY)
            {
                NPC.active = false;
                for (int i = 0; i < 25; i++)
                {
                    int num3 = Dust.NewDust(NPC.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
                }
            }
            if((NPC.velocity - NPC.oldVelocity).Length() > 0.8f)
            {
                NPC.active = false;
                for (int i = 0; i < 25; i++)
                {
                    int num3 = Dust.NewDust(NPC.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            NPC.active = false;
            for (int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(NPC.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
            }
        }
        public override void OnKill()
        {
        }
    }
}
