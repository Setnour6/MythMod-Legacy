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
    public class AncientTangerineTreeHat : ModNPC
	{
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.NPC.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树妖");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 0;
			base.NPC.width = 720;
			base.NPC.height = 1008;
			base.NPC.defense = 90;
            if (Main.expertMode)
            {
                base.NPC.lifeMax = 450000;
                if (MythWorld.Myth)
                {
                    base.NPC.lifeMax = 300000;
                }
            }
            else
            {
                base.NPC.lifeMax = 600000;
            }
            NPC.behindTiles = true;
            base.NPC.dontTakeDamage = true;
            base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.scale = 1;
            base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
            }
        }
        private int o = 0;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (!Main.dayTime)
            {
                NPC.velocity += ((player.Center - new Vector2(0, 500)) - NPC.Center) / ((player.Center - new Vector2(0, 500)) - NPC.Center).Length() * 0.3f;
                NPC.velocity *= 0.95f;
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            o += 1;
            if (NPC.CountNPCS(Mod.Find<ModNPC>("AncientTangerineTreeEye").Type) < 1 && o >= 10)
            {
                NPC.active = false;
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position + new Vector2(500,0), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块1"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor2, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块1"), 1f);
                float scaleFactor3 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position - new Vector2(500, 0), base.NPC.velocity * scaleFactor3, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块1"), 1f);
                for(int i = 0; i < 20;i++)
                {
                    float scaleFactor4 = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 2048), Main.rand.Next(0, 1024)), base.NPC.velocity * scaleFactor4, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块5"), 1f);
                }
                for (int i = 0; i < 20; i++)
                {
                    float scaleFactor4 = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 2048), Main.rand.Next(0, 1024)), base.NPC.velocity * scaleFactor4, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块6"), 1f);
                }
                for (int i = 0; i < 50; i++)
                {
                    float scaleFactor4 = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 2048), Main.rand.Next(0, 1024)), base.NPC.velocity * scaleFactor4, base.Mod.GetGoreSlot("Gores/千年桔树妖碎块6"), 1f);
                }
                for (int i = 0; i < 50; i++)
                {
                    float scaleFactor4 = (float)(Main.rand.Next(-200, 200) / 100f);
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 2048), Main.rand.Next(0, 1024)), base.NPC.velocity * scaleFactor4, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块5"), 1f);
                }
            }
        }
        // Token: 0x0600180C RID: 6156 RVA: 0x0010AEF8 File Offset: 0x001090F8
        public override void OnKill()
		{
		}
    }
}
