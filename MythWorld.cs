using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MythMod.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using Terraria.Map;
namespace MythMod
{
    public class MythWorld : ModWorld
	{
		public static int 玄武岩礁石 = 0;
		public static bool downedMoonLoad = false;
        public static bool downedHYFY = false;
        public static bool downedVol = false;
        public static bool downedBottle = false;
        public static bool downedXXLY = false;
        public static bool downedFTJE = false;
        public static bool downedDLGW = false;
        public static bool downedXYSM = false;
        public static bool downedQDEG = false;
        public static bool downedBZSJ = false;
        public static bool downedQNGSY = false;
        public static bool downedZTMSY = false;
        public static int 菊花海葵 = 0;
        public static int 紫点海葵 = 0;
        public static bool typhoon = false;
        public static int typhoonTime = 0;
        public static int typhoonTimeLeft = 0;
        public static float typhoonStrenth = 0;
        public static bool LanternMoon = false;
        public static int WorldCount = 1;
        public static int[,] World2Tile;
        public static int[,] World2Liquid;
        public static int[,] World2Wall;
        public static int[,] WorldTile;
        public static int[,] WorldLiquid;
        public static int[,] WorldWall;
        public static int WorldType = 0;
        public static int MythIndex = 1;
        private int LfX = 0;
        private int LfY = 0;
        public override void Initialize()
		{
            MythWorld.downedMoonLoad = false;
            MythWorld.downedHYFY = false;
            MythWorld.downedVol = false;
            MythWorld.downedBottle = false;
            MythWorld.downedXXLY= false;
            MythWorld.downedFTJE = false;
            MythWorld.downedDLGW = false;
            MythWorld.downedBZSJ = false;
            MythWorld.downedQDEG = false;
            MythWorld.downedQNGSY = false;
            MythWorld.downedXYSM = false;
            MythWorld.downedZTMSY = false;
            MythWorld.Myth = false;
            MythWorld.Onew = false;
        }
        public override TagCompound Save()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            List<string> list = new List<string>();
            if (MythWorld.Myth)
            {
                list.Add("Myth");
            }
            if (MythWorld.Onew)
            {
                list.Add("Onew");
            }
            if (MythWorld.downedMoonLoad)
            {
                list.Add("downedMoonLoad");
            }
            if (MythWorld.downedHYFY)
            {
                list.Add("downedHYFY");
            }
            if (MythWorld.downedVol)
            {
                list.Add("downedVol");
            }
            if (MythWorld.downedBottle)
            {
                list.Add("downedBottle");
            }
            if (MythWorld.downedBZSJ)
            {
                list.Add("downedBZSJ");
            }
            if (MythWorld.downedDLGW)
            {
                list.Add("downedDLGW");
            }
            if (MythWorld.downedFTJE)
            {
                list.Add("downedFTJE");
            }
            if (MythWorld.downedQDEG)
            {
                list.Add("downedQDEG");
            }
            if (MythWorld.downedQNGSY)
            {
                list.Add("downedQNGSY");
            }
            if (MythWorld.downedXXLY)
            {
                list.Add("downedXXLY");
            }
            if (MythWorld.downedXYSM)
            {
                list.Add("downedXYSM");
            }
            if (MythWorld.downedZTMSY)
            {
                list.Add("downedZTMSY");
            }
            MapHelper.SaveMap();
            TagCompound tagCompound = new TagCompound();
			tagCompound.Add("downed", list);
			return tagCompound;
        }
        public void autoCreate(string worldSize)
        {
            if (WorldType == 1)
            {
                Main.autoGen = false;
                return;
            }
        }
		public override void TileCountsAvailable(int[] tileCounts)
		{
            菊花海葵 = tileCounts[mod.TileType("菊花海葵")];
            紫点海葵 = tileCounts[mod.TileType("紫点海葵")];
        }
        public override void PostWorldGen()
        {
            NPC.NewNPC(Main.maxTilesX * 8, 200, mod.NPCType("Yasitaya"), 0, 0f, 0f, 0f, 0f, 255);
            int Xd = 2000;
            int Yd = 600;
            if (Main.maxTilesX == 6400)
            {
                Xd = 3000;
                Yd = 900;
            }
            if (Main.maxTilesX == 8400)
            {
                Xd = 4000;
                Yd = 1200;
            }
            Texture2D tex = mod.GetTexture("UIImages/World/大理石遗迹Kill");
            Color[] colorTex = new Color[tex.Width * tex.Height];
            tex.GetData(colorTex);

            for (int y = 0; y < tex.Height; y += 1)
            {
                for (int x = 0; x < tex.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex.Width].R, colorTex[x + y * tex.Width].G, colorTex[x + y * tex.Width].B) == new Color(255, 0, 0))
                    {
                        //WorldGen.PlaceTile(x + 2000, y + 100, mod.TileType("朽木"));
                        Main.tile[x + Xd, y + Yd].ClearEverything();
                    }
                }
            }
            Texture2D tex1 = mod.GetTexture("UIImages/World/大理石遗迹Wall");
            Color[] colorTex1 = new Color[tex1.Width * tex1.Height];
            tex1.GetData(colorTex);

            for (int y = 0; y < tex1.Height; y += 1)
            {
                for (int x = 0; x < tex1.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex1.Width].R, colorTex[x + y * tex1.Width].G, colorTex[x + y * tex1.Width].B) == new Color(111, 117, 135))
                    {
                        Main.tile[x + Xd, y + Yd].wall = 179;
                        Main.tile[x + Xd, y + Yd].active(false);
                    }
                }
            }
            Texture2D tex2 = mod.GetTexture("UIImages/World/大理石遗迹Tile");
            Color[] colortex2 = new Color[tex2.Width * tex2.Height];
            tex2.GetData(colorTex);

            for (int y = 0; y < tex2.Height; y += 1)
            {
                for (int x = 0; x < tex2.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(168, 178, 204))
                    {
                        Main.tile[x + Xd, y + Yd].type = 357;
                        Main.tile[x + Xd, y + Yd].active(true);
                    }
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(63, 89, 255))
                    {
                        Main.tile[x + Xd, y + Yd].type = (ushort)mod.TileType("GiantMarbalClock");
                        Main.tile[x + Xd, y + Yd].active(true);
                    }
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(226, 109, 140))
                    {
                        Main.tile[x + Xd, y + Yd].type = 19;
                        Main.tile[x + Xd, y + Yd].active(true);
                        Main.tile[x + Xd, y + Yd].frameY = 522;
                        WorldGen.SlopeTile(x + Xd, y + Yd, 1);
                    }
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(226, 109, 70))
                    {
                        Main.tile[x + Xd, y + Yd].type = 19;
                        Main.tile[x + Xd, y + Yd].active(true);
                        Main.tile[x + Xd, y + Yd].frameY = 522;
                        WorldGen.SlopeTile(x + Xd, y + Yd, 2);
                    }
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(204, 99, 127))
                    {
                        Main.tile[x + Xd, y + Yd].type = 19;
                        Main.tile[x + Xd, y + Yd].active(true);
                        Main.tile[x + Xd, y + Yd].frameY = 522;
                    }
                }
            }
            for (int y = 0; y < tex2.Height; y += 1)
            {
                for (int x = 0; x < tex2.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(255, 13, 5))
                    {
                        WorldGen.PlaceTile(x + Xd, y + Yd, mod.TileType("MarbleFragment"), false, true, -1, 0);
                    }
                    if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(255, 162, 22))
                    {
                        WorldGen.PlaceTile(x + Xd, y + Yd, 34, false, true, -1, 37);
                        Main.tile[x + Xd - 1, y + Yd - 1].frameX += 54;
                        Main.tile[x + Xd, y + Yd - 1].frameX += 54;
                        Main.tile[x + Xd + 1, y + Yd - 1].frameX += 54;
                        Main.tile[x + Xd - 1, y + Yd].frameX += 54;
                        Main.tile[x + Xd, y + Yd].frameX += 54;
                        Main.tile[x + Xd + 1, y + Yd].frameX += 54;
                        Main.tile[x + Xd - 1, y + Yd + 1].frameX += 54;
                        Main.tile[x + Xd, y + Yd + 1].frameX += 54;
                        Main.tile[x + Xd + 1, y + Yd + 1].frameX += 54;
                    }
                }
            }
            Texture2D tex3 = mod.GetTexture("UIImages/World/大理石遗迹Liquid");
            Color[] colortex3 = new Color[tex3.Width * tex3.Height];
            tex3.GetData(colorTex);

            for (int y = 0; y < tex3.Height; y += 1)
            {
                for (int x = 0; x < tex3.Width; x += 1)
                {
                    if (new Color(colorTex[x + y * tex3.Width].R, colorTex[x + y * tex3.Width].G, colorTex[x + y * tex3.Width].B) == new Color(0, 13, 204))
                    {
                        Main.tile[x + Xd, y + Yd].liquid = byte.MaxValue;
                    }
                }
            }
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int num = tasks.FindIndex((GenPass genpass) => genpass.Name.Equals("Shinies"));
			if (num != -1)
			{
				tasks.Insert(num + 1, new PassLegacy("生成矿石中……", delegate(GenerationProgress progress)
				{
                    progress.Message = "生成矿石中……";
                    if (WorldGen.crimson)
                    {
                        for (double num4 = 0.0; num4 < (double)((Main.maxTilesX - 201) * (int)((float)Main.maxTilesY * 0.3f)) / 7250.0; num4 += 1.0)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)((float)Main.maxTilesY * 0.35f), Main.maxTilesY - 300), (double)WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(3, 5), base.mod.TileType("绿松石"), false, 0f, 0f, false, true);
                        }
                    }
                    else
                    {
                        for (double num4 = 0.0; num4 < (double)((Main.maxTilesX - 201) * (int)((float)Main.maxTilesY * 0.3f)) / 7250.0; num4 += 1.0)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)((float)Main.maxTilesY * 0.35f), Main.maxTilesY - 300), (double)WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(3, 5), base.mod.TileType("石榴石"), false, 0f, 0f, false, true);
                        }
                    }
                    if (LfX == 0)
                    {
                        LfX = Main.rand.Next(60, Main.maxTilesX - 60);
                    }
                    if (LfY == 0)
                    {
                        LfY = Main.rand.Next(Main.maxTilesY / 30, Main.maxTilesY / 15);
                    }
                    for (int i = 0; Main.tile[LfX, LfY].active() || Main.tile[LfX + 15, LfY].active() || Main.tile[LfX - 15, LfY].active(); i++)
                    {
                        LfX = Main.rand.Next(60, Main.maxTilesX - 60);
                        LfY = Main.rand.Next(Main.maxTilesY / 30, Main.maxTilesY / 15);
                    }
                    for (int x = -5; x < 5; x++)
                    {
                        for (int y = -5; y < 5; y++)
                        {
                            if (new Vector2(x, y).Length() > 2 && new Vector2(x, y).Length() < 5)
                            {
                                Main.tile[LfX + x, LfY + y].type = 189;
                                Main.tile[LfX + x, LfY + y].active(true);
                            }
                        }
                    }
                    WorldGen.PlaceTile(LfX, LfY + 1, mod.TileType("光之花"));
                    /*int Xd = 2000;
                    int Yd = 600;
                    if (Main.maxTilesX == 6400)
                    {
                        Xd = 3000;
                        Yd = 900;
                    }
                    if (Main.maxTilesX == 8400)
                    {
                        Xd = 4000;
                        Yd = 1200;
                    }
                    Texture2D tex = mod.GetTexture("UIImages/World/大理石遗迹Kill");
                    Color[] colorTex = new Color[tex.Width * tex.Height];
                    tex.GetData(colorTex);

                    for (int y = 0; y < tex.Height; y += 1)
                    {
                        for (int x = 0; x < tex.Width; x += 1)
                        {
                            if (new Color(colorTex[x + y * tex.Width].R, colorTex[x + y * tex.Width].G, colorTex[x + y * tex.Width].B) == new Color(255, 0, 0))
                            {
                                //WorldGen.PlaceTile(x + 2000, y + 100, mod.TileType("朽木"));
                                Main.tile[x + Xd, y + Yd].ClearEverything();
                            }
                        }
                    }
                    Texture2D tex1 = mod.GetTexture("UIImages/World/大理石遗迹Wall");
                    Color[] colorTex1 = new Color[tex1.Width * tex1.Height];
                    tex1.GetData(colorTex);

                    for (int y = 0; y < tex1.Height; y += 1)
                    {
                        for (int x = 0; x < tex1.Width; x += 1)
                        {
                            if (new Color(colorTex[x + y * tex1.Width].R, colorTex[x + y * tex1.Width].G, colorTex[x + y * tex1.Width].B) == new Color(111, 117, 135))
                            {
                                Main.tile[x + Xd, y + Yd].wall = 179;
                                Main.tile[x + Xd, y + Yd].active(false);
                            }
                        }
                    }
                    Texture2D tex2 = mod.GetTexture("UIImages/World/大理石遗迹Tile");
                    Color[] colortex2 = new Color[tex2.Width * tex2.Height];
                    tex2.GetData(colorTex);

                    for (int y = 0; y < tex2.Height; y += 1)
                    {
                        for (int x = 0; x < tex2.Width; x += 1)
                        {
                            if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(168, 178, 204))
                            {
                                Main.tile[x + Xd, y + Yd].type = 357;
                                Main.tile[x + Xd, y + Yd].active(true);
                            }
                            if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(226, 109, 140))
                            {
                                Main.tile[x + Xd, y + Yd].type = 19;
                                Main.tile[x + Xd, y + Yd].active(true);
                                Main.tile[x + Xd, y + Yd].frameY = 522;
                                WorldGen.SlopeTile(x + Xd, y + Yd, 1);
                            }
                            if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(226, 109, 70))
                            {
                                Main.tile[x + Xd, y + Yd].type = 19;
                                Main.tile[x + Xd, y + Yd].active(true);
                                Main.tile[x + Xd, y + Yd].frameY = 522;
                                WorldGen.SlopeTile(x + Xd, y + Yd, 2);
                            }
                        }
                        for (int x = 0; x < tex2.Width; x += 1)
                        {
                            if (new Color(colorTex[x + y * tex2.Width].R, colorTex[x + y * tex2.Width].G, colorTex[x + y * tex2.Width].B) == new Color(255, 13, 5))
                            {
                                WorldGen.PlaceTile(x + Xd, y + Yd, mod.TileType("MarbleFragment"), false, true, -1, 0);
                            }
                        }
                    }
                    Texture2D tex3 = mod.GetTexture("UIImages/World/大理石遗迹Liquid");
                    Color[] colortex3 = new Color[tex3.Width * tex3.Height];
                    tex3.GetData(colorTex);

                    for (int y = 0; y < tex3.Height; y += 1)
                    {
                        for (int x = 0; x < tex3.Width; x += 1)
                        {
                            if (new Color(colorTex[x + y * tex3.Width].R, colorTex[x + y * tex3.Width].G, colorTex[x + y * tex3.Width].B) == new Color(0, 13, 204))
                            {
                                Main.tile[x + Xd, y + Yd].liquid = byte.MaxValue;
                            }
                        }
                    }*/
                }));
            }
            //tasks.Add(new PassLegacy("Planetoid Test", new WorldGenLegacyMethod(WorldGenerationMethods.Planetoids)));
        }
		private void MythModOres(GenerationProgress progress)
		{

		}
		private static void Oceanworld(GenerationProgress progress)
		{
		}
        public override void Load(TagCompound tag)
        {
            IList<string> list = tag.GetList<string>("downed");
            MythWorld.Myth = list.Contains("Myth");
            MythWorld.Onew = list.Contains("Onew");
            MythWorld.downedMoonLoad = list.Contains("downedMoonLoad");
            MythWorld.downedHYFY = list.Contains("downedHYFY");
            MythWorld.downedVol = list.Contains("downedVol");
            MythWorld.downedBottle = list.Contains("downedBottle");
            MythWorld.downedBZSJ = list.Contains("downedBZSJ");
            MythWorld.downedDLGW = list.Contains("downedDLGW");
            MythWorld.downedFTJE = list.Contains("downedFTJE");
            MythWorld.downedQDEG = list.Contains("downedQDEG");
            MythWorld.downedQNGSY = list.Contains("downedQNGSY");
            MythWorld.downedXXLY = list.Contains("downedXXLY");
            MythWorld.downedXYSM = list.Contains("downedXYSM");
            MythWorld.downedZTMSY = list.Contains("downedZTMSY");
            var downed = tag.GetList<string>("downed");
        }
        public override void LoadLegacy(BinaryReader reader)
	    {
			int num = reader.ReadInt32();
			if (num == 0)
            {
                BitsByte bitsByte4 = reader.ReadByte();
                MythWorld.downedVol = bitsByte4[3];
                MythWorld.Onew = bitsByte4[4];
                MythWorld.downedHYFY = bitsByte4[5];
                MythWorld.downedMoonLoad = bitsByte4[6];
                MythWorld.Myth = bitsByte4[7];
                MythWorld.downedBottle = bitsByte4[8];
                MythWorld.downedBZSJ = bitsByte4[9];
                MythWorld.downedDLGW = bitsByte4[10];
                MythWorld.downedFTJE = bitsByte4[11];
                MythWorld.downedQDEG = bitsByte4[12];
                MythWorld.downedQNGSY = bitsByte4[13];
                MythWorld.downedXXLY = bitsByte4[14];
                MythWorld.downedXYSM = bitsByte4[15];
                MythWorld.downedZTMSY = bitsByte4[16];
                return;
            }
			
            ErrorLogger.Log("MythMod: Unknown loadVersion: " + num);
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte bitsByte4 = default(BitsByte);
            bitsByte4[3] = MythWorld.downedVol;
            bitsByte4[4] = MythWorld.Onew;
            bitsByte4[5] = MythWorld.downedHYFY;
            bitsByte4[6] = MythWorld.downedMoonLoad;
            bitsByte4[7] = MythWorld.Myth;
            bitsByte4[8] = MythWorld.downedBottle;
            bitsByte4[9] = MythWorld.downedBZSJ;
            bitsByte4[10] = MythWorld.downedDLGW;
            bitsByte4[11] = MythWorld.downedFTJE;
            bitsByte4[12] = MythWorld.downedQDEG;
            bitsByte4[13] = MythWorld.downedQNGSY;
            bitsByte4[14] = MythWorld.downedXXLY;
            bitsByte4[15] = MythWorld.downedXYSM;
            bitsByte4[16] = MythWorld.downedZTMSY;
            writer.Write(bitsByte4);
            BitsByte flags = new BitsByte();
            flags[0] = downedMoonLoad;
            flags[1] = downedHYFY;
            flags[2] = downedVol;
            flags[3] = downedBottle;
            flags[4] = downedBZSJ;
            flags[5] = downedDLGW;
            flags[6] = downedFTJE;
            flags[7] = downedQDEG;
            flags[8] = downedQNGSY;
            flags[9] = downedXXLY;
            flags[10] = downedXYSM;
            flags[11] = downedZTMSY;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
		{
            BitsByte bitsByte4 = reader.ReadByte();
            MythWorld.Myth = bitsByte4[7];
            MythWorld.downedMoonLoad = bitsByte4[6];
            MythWorld.downedHYFY = bitsByte4[5];
            MythWorld.downedVol = bitsByte4[3];
            MythWorld.Onew = bitsByte4[4];
            MythWorld.downedBottle = bitsByte4[8];
            MythWorld.downedBZSJ = bitsByte4[8];
            MythWorld.downedDLGW = bitsByte4[8];
            MythWorld.downedFTJE = bitsByte4[8];
            MythWorld.downedQDEG = bitsByte4[8];
            MythWorld.downedQNGSY = bitsByte4[8];
            MythWorld.downedXXLY = bitsByte4[8];
            MythWorld.downedXYSM = bitsByte4[8];
            MythWorld.downedZTMSY = bitsByte4[8];
        }
		public static bool Myth = false;
        public static bool Onew = false;
        private const int ExpandWorldBy = 457;
		public static int fehX = 0;
		public static int fehY = 0;

	}
}
