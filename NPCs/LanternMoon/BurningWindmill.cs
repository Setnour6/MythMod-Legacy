using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class BurningWindmill : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("火焰风车");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火焰风车");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 90;
			base.npc.width = 100;
			base.npc.height = 100;
			base.npc.defense = 5;
			base.npc.lifeMax = 9000;
			base.npc.knockBackResist = 0.8f;
			base.npc.alpha = 0;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
            base.npc.noTileCollide = true;
            base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
		}
        private float Omega = 0;
        private int G = 0;
        private int T = 0;
        private float D = 0;
        public override void AI()
		{
            if(G == 0)
            {
                T = Main.rand.Next(5);
            }
            G += 1;
            npc.rotation += Omega;
            Omega = (float)((Math.Sin(G / 20f) + 1) / 3f);
            Player player = Main.player[Main.myPlayer];
            Vector2 v = player.Center + new Vector2((float)Math.Sin(G / 40f) * 500f, (float)Math.Sin((G + 200) / 40f) * 10f - 750) - npc.Center;
            if (npc.velocity.Length() < 9f)
            {
                npc.velocity += v / v.Length() * 0.35f;
            }
            npc.velocity *= 0.96f;
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
            if(Omega > 0.2f)
            {
                D += Omega;
                if(D > 1)
                {
                    D -= 1;
                    Vector2 vi = new Vector2(0, 5).RotatedBy(npc.rotation);
                    int Ty = base.mod.ProjectileType("烟花火球棕色尾迹2");
                    if (T == 0)
                    {
                        Ty = base.mod.ProjectileType("烟花火球棕色尾迹2");
                    }
                    if (T == 1)
                    {
                        Ty = base.mod.ProjectileType("烟花火球金闪2");
                    }
                    if (T == 2)
                    {
                        Ty = base.mod.ProjectileType("烟花火球绿2");
                    }
                    if (T == 3)
                    {
                        Ty = base.mod.ProjectileType("烟花火球紫2");
                    }
                    if (T == 4)
                    {
                        Ty = base.mod.ProjectileType("烟花火球红2");
                    }
                    int p = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, vi.X, vi.Y, Ty, base.npc.damage / 4, 2, 255, 0f, 0f);
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
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
            if (Main.netMode != 1 && base.npc.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/火焰风车碎块"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/火焰风车碎块"), 1f);
                Vector2 vector = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
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
}
