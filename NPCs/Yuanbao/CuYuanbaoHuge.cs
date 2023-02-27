using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	// Token: 0x020004EB RID: 1259
	public class CuYuanbaoHuge : ModNPC
	{
		private int num1 = 0;
		private int num2;
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巨大铜元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "巨大铜元宝");
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 80;
			base.NPC.height = 44;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 1800;
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
            if (NPC.alpha >= 250)
            {
                NPC.active = false;
            }
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		// Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
		public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.NPC.position.X, base.NPC.position.Y));
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.NPC.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                if(Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)base.NPC.Center.X, (int)base.NPC.Center.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CuYuanbao").Type, 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 30 && mplayer.GoldPoint < 800)
                {
                    Item.NewItem((int)base.NPC.Center.X, (int)base.NPC.Center.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CoinI").Type, 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 800 && mplayer.GoldPoint < 2400)
                {
                    Item.NewItem((int)base.NPC.Center.X, (int)base.NPC.Center.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CoinII").Type, 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 2400)
                {
                    Item.NewItem((int)base.NPC.Center.X, (int)base.NPC.Center.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CoinIII").Type, 1, false, 0, false, false);
                }
                float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块3"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/铜元宝碎块3"), 1f);
                if (mplayer.GoldTime > 0)
                {
                    if (Main.expertMode)
                    {
                        mplayer.GoldPoint += 20;
                    }
                    else
                    {
                        mplayer.GoldPoint += 10;
                    }
                    if (mplayer.Double > 0)
                    {
                        if (Main.expertMode)
                        {
                            mplayer.GoldPoint += 20;
                        }
                        else
                        {
                            mplayer.GoldPoint += 10;
                        }
                    }
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.Brown;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreKill()
		{
			return false;
		}
		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		}
	}
}
