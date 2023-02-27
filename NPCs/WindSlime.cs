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
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "风史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            if (spawnInfo.PlayerSafe)
            {
                return 0f;
            }
            if (spawnInfo.Player.GetModPlayer<MythPlayer>().ZoneOcean && spawnInfo.Sky)
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
			base.NPC.aiStyle = 14;
			base.NPC.damage = 120;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 1500;
			base.NPC.knockBackResist = 0.8f;
			this.AnimationType = 121;
			base.NPC.alpha = 75;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
		}
		public override void AI()
		{

		}
		public override void HitEffect(int hitDirection, double damage)
		{
		}
        public override void OnKill()
        {
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("WindFragment").Type, 1, false, 0, false, false);
        }
    }
}
