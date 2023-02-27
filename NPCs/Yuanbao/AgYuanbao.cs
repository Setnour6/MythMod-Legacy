using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	public class AgYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("银元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "银元宝");
		}
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 80;
			base.npc.height = 44;
			base.npc.defense = 0;
			base.npc.lifeMax = 1000;
			base.npc.knockBackResist = 0;
			base.npc.alpha = 0;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
            base.npc.aiStyle = -1;
        }
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
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 37, 1f, 0f);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.npc.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)base.npc.Center.X, (int)base.npc.Center.Y, base.npc.width, base.npc.height, base.mod.ItemType("AgYuanbao"), 1, false, 0, false, false);
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
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/银元宝碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/银元宝碎块3"), 1f);
                if (mplayer.GoldTime > 0)
                {
                    if (Main.expertMode)
                    {
                        mplayer.GoldPoint += 12;
                    }
                    else
                    {
                        mplayer.GoldPoint += 6;
                    }
                    if (mplayer.Double > 0)
                    {
                        if (Main.expertMode)
                        {
                            mplayer.GoldPoint += 12;
                        }
                        else
                        {
                            mplayer.GoldPoint += 6;
                        }
                    }
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.Silver;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreNPCLoot()
		{
			return false;
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		}
	}
}
