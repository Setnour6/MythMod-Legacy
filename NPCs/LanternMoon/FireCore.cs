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
			Main.npcFrameCount[base.npc.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "焰火幻之心");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 0;
			base.npc.width = 200;
			base.npc.height = 200;
			base.npc.defense = 90;
            if (Main.expertMode)
            {
                base.npc.lifeMax = 750000;
                if (MythWorld.Myth)
                {
                    base.npc.lifeMax = 500000;
                }
            }
            else
            {
                base.npc.lifeMax = 1000000;
            }
            base.npc.dontTakeDamage = false;
            base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.npc.alpha = 0;
            base.npc.scale = 1;
            base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            base.npc.boss = true;
            this.music = mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Powerless-Eclipse橘子树");
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
        public override void NPCLoot()
		{
            
        }
    }
}
