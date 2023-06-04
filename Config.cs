using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace MythMod
{
	// Token: 0x0200000B RID: 11
	public static class Config
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x000026A0 File Offset: 0x000008A0
		public static void Load()
		{
			if (!Config.ReadConfig())
			{
				Config.SetDefaults();
				ErrorLogger.Log("The Myth Mod's config file could not be found. Creating config...");
			}
			Config.SaveConfig();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00040300 File Offset: 0x0003E500
		public static void SetDefaults()
		{
			Config.AdrenalineAndRage = true;
			Config.ExpertDebuffDurationReduction = true;
			Config.ExpertChilledWaterRemoval = true;
			Config.ProficiencyEnabled = true;
			Config.MiningSpeedBoost = false;
			Config.DisableExpertEnemySpawnsNearHouse = false;
			Config.ExpertPillarEnemyKillCountReduction = true;
			Config.LethalLava = true;
			Config.BossRushAccessoryCurse = false;
			Config.BossRushHealthCurse = false;
			Config.BossRushDashCurse = false;
			Config.BossRushXerocCurse = false;
			Config.BossRushImmunityFrameCurse = false;
			Config.RageMeterXPos = 500;
			Config.RageMeterYPos = 30;
			Config.AdrenalineMeterXPos = 650;
			Config.AdrenalineMeterYPos = 30;
			Config.BossHealthPercentageBoost = 0;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00040384 File Offset: 0x0003E584
		public static bool ReadConfig()
		{
			if (Config.Configuration.Load())
			{
				Config.Configuration.Get<bool>("AdrenalineAndRage", ref Config.AdrenalineAndRage);
				Config.Configuration.Get<bool>("ExpertDebuffDurationReduction", ref Config.ExpertDebuffDurationReduction);
				Config.Configuration.Get<bool>("ExpertChilledWaterRemoval", ref Config.ExpertChilledWaterRemoval);
				Config.Configuration.Get<bool>("ProficiencyEnabled", ref Config.ProficiencyEnabled);
				Config.Configuration.Get<bool>("MiningSpeedBoost", ref Config.MiningSpeedBoost);
				Config.Configuration.Get<bool>("DisableExpertEnemySpawnsNearHouse", ref Config.DisableExpertEnemySpawnsNearHouse);
				Config.Configuration.Get<bool>("ExpertPillarEnemyKillCountReduction", ref Config.ExpertPillarEnemyKillCountReduction);
				Config.Configuration.Get<bool>("LethalLava", ref Config.LethalLava);
				Config.Configuration.Get<bool>("BossRushAccessoryCurse", ref Config.BossRushAccessoryCurse);
				Config.Configuration.Get<bool>("BossRushHealthCurse", ref Config.BossRushHealthCurse);
				Config.Configuration.Get<bool>("BossRushDashCurse", ref Config.BossRushDashCurse);
				Config.Configuration.Get<bool>("BossRushXerocCurse", ref Config.BossRushXerocCurse);
				Config.Configuration.Get<bool>("BossRushImmunityFrameCurse", ref Config.BossRushImmunityFrameCurse);
				Config.Configuration.Get<int>("RageMeterXPos", ref Config.RageMeterXPos);
				Config.Configuration.Get<int>("RageMeterYPos", ref Config.RageMeterYPos);
				Config.Configuration.Get<int>("AdrenalineMeterXPos", ref Config.AdrenalineMeterXPos);
				Config.Configuration.Get<int>("AdrenalineMeterYPos", ref Config.AdrenalineMeterYPos);
				Config.Configuration.Get<int>("BossHealthPercentageBoost", ref Config.BossHealthPercentageBoost);
				return true;
			}
			return false;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0004050C File Offset: 0x0003E70C
		public static void SaveConfig()
		{
			Config.Configuration.Clear();
			Config.Configuration.Put("AdrenalineAndRage", Config.AdrenalineAndRage);
			Config.Configuration.Put("ExpertDebuffDurationReduction", Config.ExpertDebuffDurationReduction);
			Config.Configuration.Put("ExpertChilledWaterRemoval", Config.ExpertChilledWaterRemoval);
			Config.Configuration.Put("ProficiencyEnabled", Config.ProficiencyEnabled);
			Config.Configuration.Put("MiningSpeedBoost", Config.MiningSpeedBoost);
			Config.Configuration.Put("DisableExpertEnemySpawnsNearHouse", Config.DisableExpertEnemySpawnsNearHouse);
			Config.Configuration.Put("ExpertPillarEnemyKillCountReduction", Config.ExpertPillarEnemyKillCountReduction);
			Config.Configuration.Put("LethalLava", Config.LethalLava);
			Config.Configuration.Put("BossRushAccessoryCurse", Config.BossRushAccessoryCurse);
			Config.Configuration.Put("BossRushHealthCurse", Config.BossRushHealthCurse);
			Config.Configuration.Put("BossRushDashCurse", Config.BossRushDashCurse);
			Config.Configuration.Put("BossRushXerocCurse", Config.BossRushXerocCurse);
			Config.Configuration.Put("BossRushImmunityFrameCurse", Config.BossRushImmunityFrameCurse);
			Config.Configuration.Put("RageMeterXPos", Config.RageMeterXPos);
			if (Config.RageMeterXPos < 0)
			{
				Config.RageMeterXPos = 0;
			}
			Config.Configuration.Put("RageMeterYPos", Config.RageMeterYPos);
			if (Config.RageMeterYPos < 0)
			{
				Config.RageMeterYPos = 0;
			}
			Config.Configuration.Put("AdrenalineMeterXPos", Config.AdrenalineMeterXPos);
			if (Config.AdrenalineMeterXPos < 0)
			{
				Config.AdrenalineMeterXPos = 0;
			}
			Config.Configuration.Put("AdrenalineMeterYPos", Config.AdrenalineMeterYPos);
			if (Config.AdrenalineMeterYPos < 0)
			{
				Config.AdrenalineMeterYPos = 0;
			}
			Config.Configuration.Put("BossHealthPercentageBoost", Config.BossHealthPercentageBoost);
			if (Config.BossHealthPercentageBoost < 0)
			{
				Config.BossHealthPercentageBoost = 0;
			}
			if (Config.BossHealthPercentageBoost > 900)
			{
				Config.BossHealthPercentageBoost = 900;
			}
			Config.Configuration.Save(true);
		}

		// Token: 0x040002A1 RID: 673
		public static bool AdrenalineAndRage = true;

		// Token: 0x040002A2 RID: 674
		public static bool ExpertDebuffDurationReduction = true;

		// Token: 0x040002A3 RID: 675
		public static bool ExpertChilledWaterRemoval = true;

		// Token: 0x040002A4 RID: 676
		public static bool ProficiencyEnabled = true;

		// Token: 0x040002A5 RID: 677
		public static bool MiningSpeedBoost = false;

		// Token: 0x040002A6 RID: 678
		public static bool DisableExpertEnemySpawnsNearHouse = false;

		// Token: 0x040002A7 RID: 679
		public static bool ExpertPillarEnemyKillCountReduction = true;

		// Token: 0x040002A8 RID: 680
		public static bool LethalLava = true;

		// Token: 0x040002A9 RID: 681
		public static bool BossRushAccessoryCurse = false;

		// Token: 0x040002AA RID: 682
		public static bool BossRushHealthCurse = false;

		// Token: 0x040002AB RID: 683
		public static bool BossRushDashCurse = false;

		// Token: 0x040002AC RID: 684
		public static bool BossRushXerocCurse = false;

		// Token: 0x040002AD RID: 685
		public static bool BossRushImmunityFrameCurse = false;

		// Token: 0x040002AE RID: 686
		public static int RageMeterXPos = 500;

		// Token: 0x040002AF RID: 687
		public static int RageMeterYPos = 30;

		// Token: 0x040002B0 RID: 688
		public static int AdrenalineMeterXPos = 650;

		// Token: 0x040002B1 RID: 689
		public static int AdrenalineMeterYPos = 30;

		// Token: 0x040002B2 RID: 690
		public static int BossHealthPercentageBoost = 0;

		// Token: 0x040002B3 RID: 691
		private static readonly string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "MythConfig.json");

		// Token: 0x040002B4 RID: 692
		private static Preferences Configuration = new Preferences(Config.ConfigPath, false, false);

		// Token: 0x0200000C RID: 12
		private class MultiplayerSyncWorld : ModSystem
		{
			// Token: 0x060000A7 RID: 167 RVA: 0x00040800 File Offset: 0x0003EA00
			public override void NetSend(BinaryWriter writer)
			{
				BitsByte bitsByte;
				bitsByte = new BitsByte(Config.AdrenalineAndRage, Config.ExpertDebuffDurationReduction, Config.ExpertChilledWaterRemoval, Config.ProficiencyEnabled, Config.MiningSpeedBoost, Config.DisableExpertEnemySpawnsNearHouse, Config.ExpertPillarEnemyKillCountReduction, Config.LethalLava);
				writer.Write(bitsByte);
				writer.Write(Config.RageMeterXPos);
				writer.Write(Config.RageMeterYPos);
				writer.Write(Config.AdrenalineMeterXPos);
				writer.Write(Config.AdrenalineMeterYPos);
				writer.Write(Config.BossHealthPercentageBoost);
			}

			// Token: 0x060000A8 RID: 168 RVA: 0x000408B0 File Offset: 0x0003EAB0
			public override void NetReceive(BinaryReader reader)
			{
				Config.SaveConfig();
				BitsByte bitsByte = reader.ReadByte();
				Config.AdrenalineAndRage = bitsByte[0];
				Config.ExpertDebuffDurationReduction = bitsByte[1];
				Config.ExpertChilledWaterRemoval = bitsByte[2];
				Config.ProficiencyEnabled = bitsByte[3];
				Config.MiningSpeedBoost = bitsByte[4];
				Config.DisableExpertEnemySpawnsNearHouse = bitsByte[5];
				Config.ExpertPillarEnemyKillCountReduction = bitsByte[6];
				Config.LethalLava = bitsByte[7];
				BitsByte bitsByte2 = reader.ReadByte();
				Config.BossRushAccessoryCurse = bitsByte2[0];
				Config.BossRushHealthCurse = bitsByte2[1];
				Config.BossRushDashCurse = bitsByte2[2];
				Config.BossRushXerocCurse = bitsByte2[3];
				Config.BossRushImmunityFrameCurse = bitsByte2[4];
				Config.RageMeterXPos = reader.ReadInt32();
				Config.RageMeterYPos = reader.ReadInt32();
				Config.AdrenalineMeterXPos = reader.ReadInt32();
				Config.AdrenalineMeterYPos = reader.ReadInt32();
				Config.BossHealthPercentageBoost = reader.ReadInt32();
			}
		}

		// Token: 0x0200000D RID: 13
		private class MultiplayerSyncPlayer : ModPlayer
		{
			// Token: 0x060000AA RID: 170 RVA: 0x000026BD File Offset: 0x000008BD
			public override void PlayerDisconnect()
			{
				Config.ReadConfig();
			}
		}
	}
}
