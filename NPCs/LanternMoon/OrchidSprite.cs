using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class OrchidSprite : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("兰花精灵");
			Main.npcFrameCount[base.NPC.type] = 9;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "兰花精灵");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 3;
			base.NPC.damage = 125;
			base.NPC.width = 52;
			base.NPC.height = 58;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 6000;
			base.NPC.knockBackResist = 0.15f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 10000;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("FlowerSpriteBanner").Type;
        }
        private int y = 0;
        private int l = 0;
        private bool N = true;
        private bool M = true;
        public override void AI()
		{
            Player p = Main.player[Main.myPlayer];
            y += 1;
            if(N)
            {
                l = Main.rand.Next(100, 450);
                N = false;
            }
            if ((NPC.Center - p.Center).Length() > l)
            {
                NPC.spriteDirection = NPC.velocity.X > 0 ? 1 : -1;
                NPC.aiStyle = 3;
                if (NPC.velocity.Y != 0)
                {
                    NPC.frame.Y = 0;
                }
                else
                {
                    if (y % 30 >= 15)
                    {
                        NPC.frame.Y = 58;
                    }
                    else
                    {
                        NPC.frame.Y = 116;
                    }
                }
                M = true;
            }
            else
            {
                if (M)
                {
                    y = 0;
                    M = false;
                }
                NPC.spriteDirection = NPC.Center.X - p.Center.X > 0 ? -1 : 1;
                NPC.aiStyle = -1;
                NPC.velocity.X *= 0.9f;
                if (y % 30 < 5)
                {
                    NPC.frame.Y = 174;
                }
                if (y % 30 >= 5 && y % 30 < 10)
                {
                    NPC.frame.Y = 232;
                }
                if (y % 30 >= 10 && y % 30 < 15)
                {
                    NPC.frame.Y = 290;
                    Vector2 v = ((NPC.Center - p.Center) / (NPC.Center - p.Center).Length() * 15f).RotatedBy(((y % 30) - 12) / 6f * Math.PI);
                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -v.X, -v.Y, Mod.Find<ModProjectile>("兰花剑气").Type, 150, 0f, Main.myPlayer, 0f, 0f);
                }
                if (y % 30 >= 15 && y % 30 < 20)
                {
                    NPC.frame.Y = 348;
                }
                if (y % 30 >= 20 && y % 30 < 25)
                {
                    NPC.frame.Y = 406;
                }
                if (y % 30 >= 25 && y % 30 < 30)
                {
                    NPC.frame.Y = 464;
                }
            }
            if (Main.dayTime)
            {
                NPC.noTileCollide = true;
                NPC.velocity.Y += 1;
            }
        }
        public override bool PreKill()
		{
			return false;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.NPC.alpha, 97 - base.NPC.alpha, 97 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow"), vector2, new Rectangle(0, NPC.frame.Y, 52, 58), new Color(150, 150, 150, 0), base.NPC.rotation, vector, 1f, effects, 0f);
        }
        // Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/兰花精灵碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/兰花精灵碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/兰花精灵碎块3"), 1f);
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 60;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 60;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 30;
                    }
                }
            }
        }
        public override void OnKill()
        {
            Player player = Main.player[Main.myPlayer];
            if(Main.rand.Next(20) == 1)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, base.Mod.Find<ModItem>("PhalaenopsisStaff").Type, 1, false, 0, false, false);
            }
        }
        // Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
    }
}
