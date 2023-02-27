using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	// Token: 0x020004EB RID: 1259
	public class CuYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铜元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铜元宝");
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 80;
			base.npc.height = 44;
			base.npc.defense = 0;
			base.npc.lifeMax = 180;
			base.npc.knockBackResist = 0;
			base.npc.alpha = 0;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
            base.npc.aiStyle = -1;
        }

		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.GoldTime == 0)
            {
                npc.alpha += 5;
            }
            if (npc.alpha >= 250)
            {
                npc.active = false;
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
            Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 37, 1f, 0f);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.npc.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 12, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                if(Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)base.npc.Center.X, (int)base.npc.Center.Y, base.npc.width, base.npc.height, base.mod.ItemType("CuYuanbao"), 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 30 && mplayer.GoldPoint < 800)
                {
                    Item.NewItem((int)base.npc.Center.X, (int)base.npc.Center.Y, base.npc.width, base.npc.height, base.mod.ItemType("CoinI"), 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 800 && mplayer.GoldPoint < 2400)
                {
                    Item.NewItem((int)base.npc.Center.X, (int)base.npc.Center.Y, base.npc.width, base.npc.height, base.mod.ItemType("CoinII"), 1, false, 0, false, false);
                }
                if (Main.rand.Next(100) == 0 && mplayer.GoldPoint > 2400)
                {
                    Item.NewItem((int)base.npc.Center.X, (int)base.npc.Center.Y, base.npc.width, base.npc.height, base.mod.ItemType("CoinIII"), 1, false, 0, false, false);
                }
                float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/铜元宝碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/铜元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/铜元宝碎块3"), 1f);
                if (mplayer.GoldTime > 0)
                {
                    if (Main.expertMode)
                    {
                        mplayer.GoldPoint += 2;
                    }
                    else
                    {
                        mplayer.GoldPoint += 1;
                    }
                    if (mplayer.Double > 0)
                    {
                        if (Main.expertMode)
                        {
                            mplayer.GoldPoint += 2;
                        }
                        else
                        {
                            mplayer.GoldPoint += 1;
                        }
                    }
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.Brown;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreNPCLoot()
		{
			return false;
		}
		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		}
	}
}
