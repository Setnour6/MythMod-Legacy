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
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "顽童僵尸");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 3;
			base.npc.damage = 60;
			base.npc.width = 34;
			base.npc.height = 48;
			base.npc.defense = 5;
			base.npc.lifeMax = 1000;
			base.npc.knockBackResist = 0.8f;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 2000;
            //this.banner = base.npc.type;
            //this.bannerItem = base.mod.ItemType("吉祥僵尸Banner");
        }
        private int y = 0;
        private int x = 0;
        public override void AI()
		{
            int num5 = (int)Player.FindClosest(base.npc.Center, 1, 1);
            if ((npc.Center - Main.player[num5].Center).Length() >= 200)
            {
                y += 1;
                if (npc.velocity.Y != 0)
                {
                    npc.frame.Y = 96;
                }
                else
                {
                    if (y % 30 >= 15)
                    {
                        npc.frame.Y = 0;
                    }
                    else
                    {
                        npc.frame.Y = 48;
                    }
                }
                if (npc.life < npc.lifeMax * 0.5f)
                {
                    npc.aiStyle = 3;
                }
                npc.spriteDirection = npc.velocity.X > 0 ? 1 : -1;
                if (Main.dayTime)
                {
                    npc.noTileCollide = true;
                    npc.velocity.Y += 1;
                }
            }
            else
            {
                npc.frame.Y = 144;
                x += 1;
                npc.velocity.X *= 0f;
                npc.spriteDirection = -(int)((npc.Center.X - Main.player[num5].Center.X) / Math.Abs((npc.Center.X - Main.player[num5].Center.X)));
                if (x % 180 == 3 && npc.collideY)
                {
                    npc.velocity *= 0f;
                    Vector2 v = Main.player[num5].Center - npc.Center;
                    v = v / v.Length();
                    Projectile.NewProjectile(npc.Center.X + npc.spriteDirection * 12, npc.Center.Y, v.X, v.Y, mod.ProjectileType("MonkeyFly"), 50, 0);
                }
            }
        }
        public override bool PreNPCLoot()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/吉祥僵尸碎块"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, 4, 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, 5, 1f);
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
