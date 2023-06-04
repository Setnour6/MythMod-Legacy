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
	// Token: 0x02000487 RID: 1159
    public class AncientTangerineTreeHatSHadow : ModNPC
	{
        // Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.NPC.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树妖");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
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
			base.NPC.alpha = 160;
            base.NPC.scale = 1;
            base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 50;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 50;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 25;
                    }
                }
            }
        }
        private int o = 0;
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (!Main.dayTime)
            {
                NPC.velocity += ((player.Center - new Vector2(0, 495)) - NPC.Center) / ((player.Center - new Vector2(0, 495)) - NPC.Center).Length() * 0.29f;
                NPC.velocity *= 0.95f;
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            o += 1;
            if(NPC.CountNPCS(Mod.Find<ModNPC>("AncientTangerineTreeEye").Type) < 1 && o >= 10)
            {
                NPC.active = false;
            }
        }
        // Token: 0x0600180C RID: 6156 RVA: 0x0010AEF8 File Offset: 0x001090F8
        public override void OnKill()
		{
		}
    }
}
