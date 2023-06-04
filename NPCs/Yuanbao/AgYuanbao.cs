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
	public class AgYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("银元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "银元宝");
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.NPC.position.X, base.NPC.position.Y));
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.NPC.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 11, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)base.NPC.Center.X, (int)base.NPC.Center.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("AgYuanbao").Type, 1, false, 0, false, false);
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
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/银元宝碎块3"), 1f);
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
		public override bool PreKill()
		{
			return false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
		}
	}
}
