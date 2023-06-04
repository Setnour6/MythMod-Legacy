using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	// Token: 0x020004EB RID: 1259
	public class BoomYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("爆炸元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "爆炸元宝");
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/Yuanbao/爆炸元宝Glow").Width, (float)(base.Mod.GetTexture("NPCs/Yuanbao/爆炸元宝Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/Yuanbao/爆炸元宝Glow"), vector2, new Rectangle?(base.NPC.frame), new Color(0.3f * (255 - NPC.alpha) / 255f, 0.3f * (255 - NPC.alpha) / 255f, 0.3f * (255 - NPC.alpha) / 255f, 0), base.NPC.rotation, vector, 1f, effects, 0f);
        }
        public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 80;
			base.NPC.height = 44;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 1000;
			base.NPC.knockBackResist = 0;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
            base.NPC.aiStyle = -1;
        }

		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.GoldTime == 0)
            {
                NPC.alpha += 5;
            }
            if(NPC.alpha >= 250)
            {
                NPC.active = false;
            }
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		// Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
		public override void HitEffect(NPC.HitInfo hit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();

            if (base.NPC.life <= 0)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)NPC.Center.X, (int)NPC.Center.Y);
                for (int k = 0; k <= 10; k++)
                {
                    float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                    float m = (float)Main.rand.Next(0, 50000);
                    float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                    int num4 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("火山溅射").Type, 1000, 0, Main.myPlayer, 0f, 0f);
                    Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
                }
                for (int k = 0; k <= 10; k++)
                {
                    Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(base.NPC.Center.X + v.X, base.NPC.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("爆炸效果光").Type, 100000, 0, Main.myPlayer, 0f, 0f);
                }
                float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块3"), 1f);
                if (mplayer.GoldTime > 0)
                {
                    if (Main.expertMode)
                    {
                        mplayer.GoldPoint += 1;
                    }
                    else
                    {
                        mplayer.GoldPoint += 1;
                    }
                    if(mplayer.Double > 0)
                    {
                        if (Main.expertMode)
                        {
                            mplayer.GoldPoint += 1;
                        }
                        else
                        {
                            mplayer.GoldPoint += 1;
                        }
                    }
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.RosyBrown;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreKill()
		{
			return false;
		}
		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
		}
	}
}
