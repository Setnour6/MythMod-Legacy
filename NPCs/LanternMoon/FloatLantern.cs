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

    public class FloatLantern : ModNPC
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
            base.DisplayName.SetDefault("鬼灯笼");
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "鬼灯笼");
		}
		public override void SetDefaults()
		{
			base.npc.damage = 100;
            base.npc.lifeMax = 500;
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
            this.bannerItem = base.mod.ItemType("LanternghostBanner");
        }
        private int A2 = 0;
        public override void NPCLoot()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 2, false, 0, false, false);
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            npc.rotation = npc.velocity.X / 30f;
            A2 += 1;
            if(A2 % 45 < 15)
            {
                npc.frame.Y = 0;
            }
            if (A2 % 45 >= 15 && A2 % 45 < 30)
            {
                npc.frame.Y = 74;
            }
            if (A2 % 45 >= 30 && A2 % 45 < 45)
            {
                npc.frame.Y = 148;
            }
            Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 150) - npc.Center;
            if(npc.velocity.Length() < 9f)
            {
                npc.velocity += v / v.Length() * 0.35f;
            }
            npc.velocity *= 0.96f;
            if (Math.Abs(npc.Center.X - player.Center.X) < 200 && A2 % 25 == 1)
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 30f, npc.velocity.X / 3f, npc.velocity.Y * 0.25f + 1.5f, mod.ProjectileType("LanternBoomLi"), 25, 0f, Main.myPlayer, 0f, 0f);
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/鬼灯笼碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/鬼灯笼碎块2"), 1f);
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
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow"), vector2, new Rectangle(0, npc.frame.Y, 62, 74), new Color(50, 50, 50, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
        public int dustTimer = 60;
	}
}
