using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class WindSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("风史莱姆");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "风史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            if (spawnInfo.playerSafe)
            {
                return 0f;
            }
            if (spawnInfo.player.GetModPlayer<MythPlayer>().ZoneOcean && spawnInfo.sky)
            {
                return 5f;
            }
            else
            {
                return 0f;
            }
        }
		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			base.npc.damage = 120;
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 5;
			base.npc.lifeMax = 1500;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.alpha = 75;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
		}
		public override void AI()
		{

		}
		public override void HitEffect(int hitDirection, double damage)
		{
		}
        public override void NPCLoot()
        {
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("WindFragment"), 1, false, 0, false, false);
        }
    }
}
