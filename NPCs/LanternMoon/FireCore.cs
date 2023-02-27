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
    //[AutoloadBossHead]
    public class FireCore : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("FireCore");
			Main.npcFrameCount[base.NPC.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "焰火幻之心");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 0;
			base.NPC.width = 200;
			base.NPC.height = 200;
			base.NPC.defense = 90;
            if (Main.expertMode)
            {
                base.NPC.lifeMax = 750000;
                if (MythWorld.Myth)
                {
                    base.NPC.lifeMax = 500000;
                }
            }
            else
            {
                base.NPC.lifeMax = 1000000;
            }
            base.NPC.dontTakeDamage = false;
            base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.scale = 1;
            base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
            base.NPC.boss = true;
            this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Powerless-Eclipse橘子树");
        }
        private int i0 = 0;
        public static bool canai = false;
        private bool can2ai = false;
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (i0 == 0)
            {
            }            
        }
        public static float AI0 = 0;
        public static Vector2 ReliPos;
        public static Vector2 DeltaPos;
        public static Vector2 Center0;
        private int K = -1;
        private int K0 = -1;
        private int K1 = -1;
        private int[] M = new int[6];
        public override void OnKill()
		{
            
        }
    }
}
