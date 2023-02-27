using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
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
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "鬼灯笼");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 100;
            base.NPC.lifeMax = 500;
			base.NPC.npcSlots = 14f;
			base.NPC.width = 62;
			base.NPC.height = 74;
			base.NPC.defense = 0;
			base.NPC.value = 4000;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.knockBackResist = 0.6f;
            base.NPC.dontTakeDamage = false;
            base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("LanternghostBanner").Type;
        }
        private int A2 = 0;
        public override void OnKill()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, 58, 2, false, 0, false, false);
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            NPC.rotation = NPC.velocity.X / 30f;
            A2 += 1;
            if(A2 % 45 < 15)
            {
                NPC.frame.Y = 0;
            }
            if (A2 % 45 >= 15 && A2 % 45 < 30)
            {
                NPC.frame.Y = 74;
            }
            if (A2 % 45 >= 30 && A2 % 45 < 45)
            {
                NPC.frame.Y = 148;
            }
            Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 150) - NPC.Center;
            if(NPC.velocity.Length() < 9f)
            {
                NPC.velocity += v / v.Length() * 0.35f;
            }
            NPC.velocity *= 0.96f;
            if (Math.Abs(NPC.Center.X - player.Center.X) < 200 && A2 % 25 == 1)
            {
                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y + 30f, NPC.velocity.X / 3f, NPC.velocity.Y * 0.25f + 1.5f, Mod.Find<ModProjectile>("LanternBoomLi").Type, 25, 0f, Main.myPlayer, 0f, 0f);
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
        }
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/鬼灯笼碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/鬼灯笼碎块2"), 1f);
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
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.NPC.alpha, 97 - base.NPC.alpha, 97 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/鬼灯笼Glow"), vector2, new Rectangle(0, NPC.frame.Y, 62, 74), new Color(50, 50, 50, 0), base.NPC.rotation, vector, 1f, effects, 0f);
        }
        public int dustTimer = 60;
	}
}
