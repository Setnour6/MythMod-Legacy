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
			base.npc.damage = 0;
            base.npc.lifeMax = 2500;
			base.npc.npcSlots = 14f;
			base.npc.width = 40;
			base.npc.height = 62;
			base.npc.defense = 200000;
			base.npc.value = 0f;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.knockBackResist = 0f;
			base.npc.boss = true;
            base.npc.dontTakeDamage = true;
            base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit3;
			this.music = 12;
		}
        private bool A2 = true;
        public override void AI()
        {
            bool dayTime = Main.dayTime;
            Player player = Main.player[base.npc.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            base.npc.TargetClosest(true);
            Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            int num4 = (base.npc.ai[0] == 2f) ? 2 : 1;
            int num5 = (base.npc.ai[0] == 2f) ? 50 : 35;
            float num6 = expertMode ? 5f : 4.5f;
            base.npc.localAI[0] += 1;
            Vector2 vector6 = base.npc.Center + new Vector2(1200, 0);
            if(A)
            {
                A = false;
                Vector2 vector4 = base.npc.Center;
                Vector2 vector7 = vector4 + new Vector2(1200, 0).RotatedBy((double)(Math.PI / 15f) * 2);
                for(int u = 0; u < 25; u++)
                {
                    Dust.NewDust(new Vector2((float)base.npc.Center.X, (float)base.npc.Center.Y), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
                }
            }
            if(dayTime)
            {
                npc.velocity += new Vector2(0 ,-0.8f);
            }
            if (!player.active || player.dead)
            {
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.velocity = new Vector2(0f, -15f);
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    return;
                }
            }
            if (!dayTime)
            {
                Dust.NewDust(new Vector2((float)base.npc.Center.X, (float)base.npc.Center.Y - 24f), 8, 8, 6, 0f, 0f, 0, default(Color), 1f);
                base.npc.rotation = 0;
                if (base.npc.localAI[0] > 45)
                {
                    npc.position = Main.screenPosition + new Vector2(Main.mouseX, 0);
                }
                else
                {
                    npc.velocity = (Main.screenPosition + new Vector2(Main.mouseX, 0) - npc.Center) * (25f / ((Main.screenPosition + new Vector2(Main.mouseX, 0) - npc.Center).Length() + 0.01f));
                }
                Vector2 vector3 = new Vector2(num, num2) / num3;
                if (base.npc.localAI[0] % 60 == 0 && base.npc.localAI[0] > 45)
                {
                    Projectile.NewProjectile(base.npc.Center.X - 22, base.npc.Center.Y + 55f, 0, 1f, 102, 70, 0f, Main.myPlayer, 0f, 0f);
                }
                if (NPC.CountNPCS(127) > 0)
                {
                    npc.dontTakeDamage = true;
                }
                else
                {
                    npc.life = 0;
                }
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public int dustTimer = 60;
	}
}
