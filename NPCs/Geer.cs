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

    public class Geer : ModNPC
	{
        private bool A = true;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 40;
            base.NPC.lifeMax = 2500;
			base.NPC.npcSlots = 14f;
			base.NPC.width = 90;
			base.NPC.height = 90;
			base.NPC.defense = 200000;
			base.NPC.value = 0f;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.knockBackResist = 0f;
            base.NPC.dontTakeDamage = true;
            base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
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
                NPC.rotation += 0.4f;
                if (base.NPC.localAI[0] > 45)
                {
                    NPC.position = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - new Vector2(34, 0);
                }
                else
                {
                    NPC.velocity = (Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - NPC.Center) * (25f / ((Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - NPC.Center).Length() + 0.01f));
                }
                Vector2 vector3 = new Vector2(num, num2) / num3;
                if (base.NPC.localAI[0] % 30 == 0 && base.NPC.localAI[0] > 45)
                {
                    Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y + 16, 10, 0, 100, 70, 0f, Main.myPlayer, 0f, 0f);
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
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            return true;
        }
        public int dustTimer = 60;
	}
}
