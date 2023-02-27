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

namespace MythMod.NPCs
{

    public class MachineGun : ModNPC
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
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("机械炮");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "机械炮");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
            base.NPC.lifeMax = 2500;
			base.NPC.npcSlots = 14f;
			base.NPC.width = 40;
			base.NPC.height = 62;
			base.NPC.defense = 200000;
			base.NPC.value = 0f;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.knockBackResist = 0f;
			base.NPC.boss = true;
            base.NPC.dontTakeDamage = true;
            base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
			this.Music = 12;
		}
        private bool A2 = true;
        public override void AI()
        {
            bool dayTime = Main.dayTime;
            Player player = Main.player[base.NPC.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            base.NPC.TargetClosest(true);
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            int num4 = (base.NPC.ai[0] == 2f) ? 2 : 1;
            int num5 = (base.NPC.ai[0] == 2f) ? 50 : 35;
            float num6 = expertMode ? 5f : 4.5f;
            base.NPC.localAI[0] += 1;
            Vector2 vector6 = base.NPC.Center + new Vector2(1200, 0);
            if(A)
            {
                A = false;
                Vector2 vector4 = base.NPC.Center;
                Vector2 vector7 = vector4 + new Vector2(1200, 0).RotatedBy((double)(Math.PI / 15f) * 2);
                for(int u = 0; u < 25; u++)
                {
                    Dust.NewDust(new Vector2((float)base.NPC.Center.X, (float)base.NPC.Center.Y), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
                }
            }
            if(dayTime)
            {
                NPC.velocity += new Vector2(0 ,-0.8f);
            }
            if (!player.active || player.dead)
            {
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.velocity = new Vector2(0f, -15f);
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    return;
                }
            }
            if (!dayTime)
            {
                Dust.NewDust(new Vector2((float)base.NPC.Center.X, (float)base.NPC.Center.Y - 24f), 8, 8, 6, 0f, 0f, 0, default(Color), 1f);
                base.NPC.rotation = 0;
                if (base.NPC.localAI[0] > 45)
                {
                    NPC.position = Main.screenPosition + new Vector2(Main.mouseX, 0);
                }
                else
                {
                    NPC.velocity = (Main.screenPosition + new Vector2(Main.mouseX, 0) - NPC.Center) * (25f / ((Main.screenPosition + new Vector2(Main.mouseX, 0) - NPC.Center).Length() + 0.01f));
                }
                Vector2 vector3 = new Vector2(num, num2) / num3;
                if (base.NPC.localAI[0] % 60 == 0 && base.NPC.localAI[0] > 45)
                {
                    Projectile.NewProjectile(base.NPC.Center.X - 22, base.NPC.Center.Y + 55f, 0, 1f, 102, 70, 0f, Main.myPlayer, 0f, 0f);
                }
                if (NPC.CountNPCS(127) > 0)
                {
                    NPC.dontTakeDamage = true;
                }
                else
                {
                    NPC.life = 0;
                }
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public int dustTimer = 60;
	}
}
