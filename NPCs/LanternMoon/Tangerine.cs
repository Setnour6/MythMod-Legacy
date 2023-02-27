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
			base.npc.aiStyle = -1;
			base.npc.damage = 182;
			base.npc.width = 40;
			base.npc.height = 40;
			base.npc.defense = 0;
			base.npc.lifeMax = 1;
			base.npc.knockBackResist = 0f;
            base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.npc.alpha = 0;
            base.npc.scale = 1;
            base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
        }
        public override void AI()
        {
            npc.rotation += npc.ai[0];
            if (npc.velocity.Y < 9)
            {
                npc.velocity.Y += 0.15f;
            }
            if (base.npc.collideX || base.npc.collideY)
            {
                npc.active = false;
                for (int i = 0; i < 25; i++)
                {
                    int num3 = Dust.NewDust(npc.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
                }
            }
            if((npc.velocity - npc.oldVelocity).Length() > 0.8f)
            {
                npc.active = false;
                for (int i = 0; i < 25; i++)
                {
                    int num3 = Dust.NewDust(npc.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            npc.active = false;
            for (int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(npc.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
            }
        }
        public override void NPCLoot()
        {
        }
    }
}
