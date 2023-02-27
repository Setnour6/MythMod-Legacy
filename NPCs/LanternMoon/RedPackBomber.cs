using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.LanternMoon
{

    public class RedPackBomber : ModNPC
	{
        private bool A = true;
        private int num10;
        private int num11;
        private int num12;
        private int num13;
        private int num14;
        private int num15;
        private int num16;
        private int num17;
        private int num18;
        private int num19;
        private int num20;
        private int num21;
        private int num22;
        private int num23;
        private int num24;
		// Token: 0x0600163F RID: 5695 RVA: 0x00008D5D File Offset: 0x00006F5D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("封包轰炸机");
			Main.npcFrameCount[base.npc.type] = 1;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "封包轰炸机");

        }
        public override void NPCLoot()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 2, false, 0, false, false);
        }
        // Token: 0x06001640 RID: 5696 RVA: 0x000E2920 File Offset: 0x000E0B20
        public override void SetDefaults()
		{
			base.npc.damage = 100;
            base.npc.lifeMax = 300;
			base.npc.npcSlots = 14f;
			base.npc.width = 62;
			base.npc.height = 74;
			base.npc.defense = 0;
			base.npc.value = 4000;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.knockBackResist = 0.6f;
            base.npc.dontTakeDamage = false;
            base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit3;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("RedpackBanner");
        }
        private int A2 = 0;
        // Token: 0x02000413 RID: 1043
        // Token: 0x06002314 RID: 8980 RVA: 0x0000D3C9 File Offset: 0x0000B5C9

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            npc.rotation = npc.velocity.X / 30f;
            A2 += 1;
            Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 60f) * 1000f, (float)Math.Sin((A2 + 200) / 60f) * 50f - 300) - npc.Center;
            if (npc.velocity.Length() < 14f)
            {
                npc.velocity += v / v.Length() * 0.5f;
            }
            npc.velocity *= 0.96f;
            npc.spriteDirection = npc.velocity.X > 0 ? -1 : 1;
            if(Math.Abs(npc.velocity.X) > 5 && A2 % 32 == 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 30f, npc.velocity.X / 3f, npc.velocity.Y * 0.25f + 1.5f, mod.ProjectileType("红包"), 45, 0f, Main.myPlayer, 0f, 0f);
            }
            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y += 1;
            }
        }
        // Token: 0x02000413 RID: 1043
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/封包轰炸机碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/封包轰炸机碎块2"), 1f);
                if (mplayer.LanternMoonWave != 15)
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
        // Token: 0x02000413 RID: 1043
        public int dustTimer = 60;
		// Token: 0x06001646 RID: 5702 RVA: 0x000E4084 File Offset: 0x000E2284
	}
}
