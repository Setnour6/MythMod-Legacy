using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class StubbronChildZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("顽童僵尸");
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "顽童僵尸");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 3;
			base.NPC.damage = 60;
			base.NPC.width = 34;
			base.NPC.height = 48;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 1000;
			base.NPC.knockBackResist = 0.8f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 2000;
            //this.banner = base.npc.type;
            //this.bannerItem = base.mod.ItemType("吉祥僵尸Banner");
        }
        private int y = 0;
        private int x = 0;
        public override void AI()
		{
            int num5 = (int)Player.FindClosest(base.NPC.Center, 1, 1);
            if ((NPC.Center - Main.player[num5].Center).Length() >= 200)
            {
                y += 1;
                if (NPC.velocity.Y != 0)
                {
                    NPC.frame.Y = 96;
                }
                else
                {
                    if (y % 30 >= 15)
                    {
                        NPC.frame.Y = 0;
                    }
                    else
                    {
                        NPC.frame.Y = 48;
                    }
                }
                if (NPC.life < NPC.lifeMax * 0.5f)
                {
                    NPC.aiStyle = 3;
                }
                NPC.spriteDirection = NPC.velocity.X > 0 ? 1 : -1;
                if (Main.dayTime)
                {
                    NPC.noTileCollide = true;
                    NPC.velocity.Y += 1;
                }
            }
            else
            {
                NPC.frame.Y = 144;
                x += 1;
                NPC.velocity.X *= 0f;
                NPC.spriteDirection = -(int)((NPC.Center.X - Main.player[num5].Center.X) / Math.Abs((NPC.Center.X - Main.player[num5].Center.X)));
                if (x % 180 == 3 && NPC.collideY)
                {
                    NPC.velocity *= 0f;
                    Vector2 v = Main.player[num5].Center - NPC.Center;
                    v = v / v.Length();
                    Projectile.NewProjectile(NPC.Center.X + NPC.spriteDirection * 12, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("MonkeyFly").Type, 50, 0);
                }
            }
        }
        public override bool PreKill()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/吉祥僵尸碎块"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, 4, 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, 5, 1f);
                if (mplayer.LanternMoonWave != 35)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 30;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 30;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 15;
                    }
                }
            }
        }
	}
}
