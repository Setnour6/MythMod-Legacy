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
            // base.DisplayName.SetDefault("火焰风车");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火焰风车");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 90;
			base.NPC.width = 100;
			base.NPC.height = 100;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 9000;
			base.NPC.knockBackResist = 0.8f;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
            base.NPC.noTileCollide = true;
            base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
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
            NPC.rotation += Omega;
            Omega = (float)((Math.Sin(G / 20f) + 1) / 3f);
            Player player = Main.player[Main.myPlayer];
            Vector2 v = player.Center + new Vector2((float)Math.Sin(G / 40f) * 500f, (float)Math.Sin((G + 200) / 40f) * 10f - 750) - NPC.Center;
            if (NPC.velocity.Length() < 9f)
            {
                NPC.velocity += v / v.Length() * 0.35f;
            }
            NPC.velocity *= 0.96f;
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            if(Omega > 0.2f)
            {
                D += Omega;
                if(D > 1)
                {
                    D -= 1;
                    Vector2 vi = new Vector2(0, 5).RotatedBy(NPC.rotation);
                    int Ty = base.Mod.Find<ModProjectile>("烟花火球棕色尾迹2").Type;
                    if (T == 0)
                    {
                        Ty = base.Mod.Find<ModProjectile>("烟花火球棕色尾迹2").Type;
                    }
                    if (T == 1)
                    {
                        Ty = base.Mod.Find<ModProjectile>("烟花火球金闪2").Type;
                    }
                    if (T == 2)
                    {
                        Ty = base.Mod.Find<ModProjectile>("烟花火球绿2").Type;
                    }
                    if (T == 3)
                    {
                        Ty = base.Mod.Find<ModProjectile>("烟花火球紫2").Type;
                    }
                    if (T == 4)
                    {
                        Ty = base.Mod.Find<ModProjectile>("烟花火球红2").Type;
                    }
                    int p = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, vi.X, vi.Y, Ty, base.NPC.damage / 4, 2, 255, 0f, 0f);
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                }
            }
        }

		public override bool PreKill()
		{
			return false;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (Main.netMode != 1 && base.NPC.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/火焰风车碎块"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/火焰风车碎块"), 1f);
                Vector2 vector = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
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
