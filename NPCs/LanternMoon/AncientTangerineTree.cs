﻿using System;
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
    public class AncientTangerineTree : ModNPC
	{
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.npc.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树妖");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 0;
			base.npc.width = 720;
			base.npc.height = 1008;
			base.npc.defense = 90;
            if (Main.expertMode)
            {
                base.npc.lifeMax = 450000;
                if (MythWorld.Myth)
                {
                    base.npc.lifeMax = 300000;
                }
            }
            else
            {
                base.npc.lifeMax = 600000;
            }
            npc.behindTiles = true;
            base.npc.dontTakeDamage = true;
            base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.npc.alpha = 0;
            base.npc.scale = 1;
            base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
            }
        }
        private int o = 0;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (!Main.dayTime)
            {
                npc.velocity += (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 0.3f;
                npc.velocity *= 0.95f;
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
            o += 1;
            if (NPC.CountNPCS(mod.NPCType("AncientTangerineTreeEye")) < 1 && o >= 10)
            {
                npc.active = false;
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/千年桔树妖碎块2"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor2, base.mod.GetGoreSlot("Gores/千年桔树妖碎块3"), 1f);
                for (int i = 0; i < 5; i++)
                {
                    float scaleFactor4 = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.npc.position + new Vector2(Main.rand.Next(0, 720), Main.rand.Next(0, 658)), base.npc.velocity * scaleFactor4, base.mod.GetGoreSlot("Gores/青翠年桔木碎块4"), 1f);
                }
            }
        }
        public override void NPCLoot()
		{
		}
    }
}