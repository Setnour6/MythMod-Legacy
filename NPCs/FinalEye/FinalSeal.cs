using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.FinalEye
{
	// Token: 0x020004EB RID: 1259
	        [AutoloadBossHead]
    public class FinalSeal : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("末日封印");
			Main.npcFrameCount[base.npc.type] = 4;
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.npc.knockBackResist = 0f;
			base.npc.damage = 0;
			base.npc.width = 166;
			base.npc.height = 166;
			base.npc.defense = 600;
			base.npc.lifeMax = 2500000;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.alpha = 100;
			base.npc.noTileCollide = true;
		}
		public override void BossHeadRotation(ref float rotation)
		{
			rotation = base.npc.rotation;
		}
        private bool canDespawn;
		private float num62 = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
			Player player = Main.player[base.npc.target];
			Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if (npc.life > 1000000 && npc.life < 5000001)
			{
			    npc.defense = (int)num3 * 10;
			}
			if (npc.life > 0 && npc.life < 1000001)
			{
			    npc.defense = (int)num3 * 50;
			}
			canDespawn = false;
            base.npc.rotation += 0.02f + ((float)npc.lifeMax - (float)npc.life) / 20000000f;
			base.npc.localAI[0] += 2;
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("FlameStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(2 / 7f * Math.PI) * 400f, (float)Math.Cos(2 / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("FlameStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("TerraStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(4 / 7f * Math.PI) * 400f, (float)Math.Cos(4 / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("TerraStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("WeatherStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(6 / 7f * Math.PI) * 400f, (float)Math.Cos(6 / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("WeatherStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("JungleStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(8 / 7f * Math.PI) * 400f, (float)Math.Cos(8 / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("JungleStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("FreezingStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(10f / 7f * Math.PI) * 400f, (float)Math.Cos(10f / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("FreezingStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("StarStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(12 / 7f * Math.PI) * 400f, (float)Math.Cos(12 / 7f * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("StarStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] == 2f && NPC.CountNPCS(mod.NPCType("LaserStone")) < 1)
            {
                Vector2 vector4 = npc.Center + new Vector2((float)Math.Sin(2 * Math.PI) * 400f, (float)Math.Cos(2 * Math.PI) * 400f);
                NPC.NewNPC((int)vector4.X, (int)vector4.Y, mod.NPCType("LaserStone"), 0, 0f, 0f, 0f, 0f, 255);
			}
			if (base.npc.localAI[0] % 12== 0)
            {
				if (NPC.CountNPCS(mod.NPCType("FlameStone")) < 1 && NPC.CountNPCS(mod.NPCType("TerraStone")) < 1 && NPC.CountNPCS(mod.NPCType("WeatherStone")) < 1 && NPC.CountNPCS(mod.NPCType("JungleStone")) < 1 && NPC.CountNPCS(mod.NPCType("LaserStone")) < 1 && NPC.CountNPCS(mod.NPCType("FreezingStone")) < 1 &&NPC.CountNPCS(mod.NPCType("StarStone")) < 1)
                {
					if (npc.life > 4000000 && npc.life < 5000001)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (float)Math.Sin(num62 / 100f * Math.PI);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (float)Math.Cos(num62 / 100f * Math.PI);         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 3000000 && npc.life < 4000000)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 2000000 && npc.life < 3000000)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f);      
						Vector2 K = new Vector2(num60 ,num61) * (float)(Math.Sin(num62 / 100f * Math.PI) + 1.4f) / 1.6f;
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, K.X,  K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 1000000 && npc.life < 2000000 && base.npc.localAI[0] % 24 == 0)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.15f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 1000000 && npc.life < 2000000 && base.npc.localAI[0] % 24 == 12)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.4f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.4f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 750000 && npc.life < 1000000 && base.npc.localAI[0] % 72 == 0)
					{
						for (int i = 0; i < 40; i++)
			            {
			    	    	float num60 = (float)Math.Sin((float)i / 20 * Math.PI) * 4.5f;
                            float num61 = (float)Math.Cos((float)i / 20 * Math.PI) * 4.5f; 
							Vector2 K = new Vector2(num60 ,num61) + new Vector2((float)Math.Sin(((float)base.npc.localAI[0]) / 600 * 3.14159265359f) * 4f,(float)Math.Cos(((float)base.npc.localAI[0]) / 600 * 3.14159265359f) * 4f);        
			            	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, K.X, K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 210;
			            	Main.projectile[num34].velocity *= 1.05f;
                            Main.projectile[num34].tileCollide = false;
						}
						for (int i = 0; i < 40; i++)
			            {
			    	    	float num60 = (float)Math.Sin((float)i / 20 * Math.PI) * 4.5f;
                            float num61 = (float)Math.Cos((float)i / 20 * Math.PI) * 4.5f; 
							Vector2 K = new Vector2(num60 ,num61) + new Vector2((float)Math.Sin(((float)base.npc.localAI[0]) / 600 * 3.14159265359f) * 4f,(float)Math.Cos(((float)base.npc.localAI[0]) / 600 * 3.14159265359f) * 4f);        
			            	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -K.X, -K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 210;
			            	Main.projectile[num34].velocity *= 1.05f;
                            Main.projectile[num34].tileCollide = false;
						}
					}
					if (npc.life > 500000 && npc.life < 750000)
					{
						float num63 = (float)Math.Sin(((float)base.npc.localAI[0] + 75) / 51 * Math.PI) / 2f;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (1.4f + num63);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (1.4f + num63);         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
						Main.projectile[num34].velocity *= 1.1f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 250000 && npc.life < 500000 && base.npc.localAI[0] % 36 == 0)
					{
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.2f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.2f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
						Main.projectile[num34].velocity *= 1.1f;
                        Main.projectile[num34].tileCollide = false;
						int num35 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num35].timeLeft = 640;
						Main.projectile[num35].velocity *= 1.1f;
						Main.projectile[num35].velocity = Main.projectile[num35].velocity.RotatedBy(Math.PI / 20f);
                        Main.projectile[num35].tileCollide = false;
						int num36 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num36].timeLeft = 640;
						Main.projectile[num36].velocity *= 1.1f;
						Main.projectile[num36].velocity = Main.projectile[num35].velocity.RotatedBy(Math.PI / -20f);
                        Main.projectile[num36].tileCollide = false;
					}
					if (npc.life > 250000 && npc.life < 500000 && base.npc.localAI[0] % 144 == 0)
					{
						for (int i = 0; i < 30; i++)
			            {
			    	    	float num60 = (float)Math.Sin((float)i / 15 * Math.PI) * 4.5f;
                            float num61 = (float)Math.Cos((float)i / 15 * Math.PI) * 4.5f; 
							Vector2 K = new Vector2(num60 ,num61);        
			            	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, K.X, K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 210;
			            	Main.projectile[num34].velocity *= 0.95f;
                            Main.projectile[num34].tileCollide = false;
						}
					}
					if (npc.life > 0 && npc.life < 250000)
					{
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 90f * 3.14159265359f) * 9f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 90f * 3.14159265359f) * 3f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.2f;
                        Main.projectile[num34].tileCollide = false;
						int num35 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num35].timeLeft = 480;
			        	Main.projectile[num35].velocity *= 1.2f;
                        Main.projectile[num35].tileCollide = false;
					}
					if (npc.life > 0 && npc.life < 250000 && base.npc.localAI[0] % 120 == 0)
					{
						for (int i = 0; i < 30; i++)
			            {
			    	    	float num60 = (float)Math.Sin((float)i / 15 * Math.PI) * 4.5f;
                            float num61 = (float)Math.Cos((float)i / 15 * Math.PI) * 4.5f; 
							Vector2 K = new Vector2(num60 ,num61);        
			            	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, K.X, K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 300;
			            	Main.projectile[num34].velocity *= 0.95f;
                            Main.projectile[num34].tileCollide = false;
						}
						for (int i = 0; i < 30; i++)
			            {
			    	    	float num60 = (float)Math.Sin((float)i / 15f * Math.PI) * 4.5f;
                            float num61 = (float)Math.Cos((float)i / 15f * Math.PI) * 2.5f; 
							Vector2 K = new Vector2(num60 ,num61).RotatedBy(Math.PI * (base.npc.localAI[0] % 1200) / 600f);        
			            	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, K.X, K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 300;
			            	Main.projectile[num34].velocity *= 0.95f;
                            Main.projectile[num34].tileCollide = false;
						}
					}
				}
				else
				{
			    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 2;
                    float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 2;         
			    	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 640;
			    	Main.projectile[num34].velocity *= 1.05f;
                    Main.projectile[num34].tileCollide = false;
				}
			}
			if ((base.npc.localAI[0] + 6) % 12== 0)
            {
			    if (NPC.CountNPCS(mod.NPCType("烈焰封印石")) < 1 && NPC.CountNPCS(mod.NPCType("大地封印石")) < 1 && NPC.CountNPCS(mod.NPCType("天气封印石")) < 1 && NPC.CountNPCS(mod.NPCType("丛林封印石")) < 1 && NPC.CountNPCS(mod.NPCType("激光封印石")) < 1 && NPC.CountNPCS(mod.NPCType("寒冰封印石")) < 1 &&NPC.CountNPCS(mod.NPCType("星辰封印石")) < 1)
                {
					if (npc.life > 4000000 && npc.life < 5000001)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (float)Math.Sin(num62 / 100f * Math.PI);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (float)Math.Cos(num62 / 100f * Math.PI);         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 3000000 && npc.life < 4000000)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 2000000 && npc.life < 3000000)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f);      
						Vector2 K = new Vector2(num60 ,num61) * (float)(Math.Sin(num62 / 100f * Math.PI) + 1.4f) / 1.6f;
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -K.X,  -K.Y, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 1000000 && npc.life < 2000000 && base.npc.localAI[0] % 24 == 6)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 0.5f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.15f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 1000000 && npc.life < 2000000 && base.npc.localAI[0] % 24 == 18)
					{
				    	num62 += 1;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.4f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 1.4f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
			        	Main.projectile[num34].velocity *= 1.05f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 500000 && npc.life < 750000)
					{	
						float num63 = (float)Math.Sin(((float)base.npc.localAI[0] + 75) / 51 * Math.PI) / 2f;
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (1.4f + num63);
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * (1.4f + num63);         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 640;
						Main.projectile[num34].velocity *= 1.1f;
                        Main.projectile[num34].tileCollide = false;
					}
					if (npc.life > 0 && npc.life < 250000)
					{
				    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 90 * 3.14159265359f) * 3f;
                        float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 90 * 3.14159265359f) * 9f;         
			        	int num34 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 480;
			        	Main.projectile[num34].velocity *= 1.2f;
                        Main.projectile[num34].tileCollide = false;
						int num35 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, num60, num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num35].timeLeft = 480;
			        	Main.projectile[num35].velocity *= 1.2f;
                        Main.projectile[num35].tileCollide = false;

					}
			    }
				else
				{
			    	float num60 = (float)Math.Sin(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 2;
                    float num61 = (float)Math.Cos(((float)base.npc.localAI[0]) / 240 * 3.14159265359f) * 2;   
			    	int num35 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -num60, -num61, base.mod.ProjectileType("灭世火光团"), 1000, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].timeLeft = 640;
			    	Main.projectile[num35].velocity *= 1.05f;
                    Main.projectile[num35].tileCollide = false;
				}
			}
			if (NPC.CountNPCS(mod.NPCType("烈焰封印石")) < 1 && NPC.CountNPCS(mod.NPCType("大地封印石")) < 1 && NPC.CountNPCS(mod.NPCType("天气封印石")) < 1 && NPC.CountNPCS(mod.NPCType("丛林封印石")) < 1 && NPC.CountNPCS(mod.NPCType("激光封印石")) < 1 && NPC.CountNPCS(mod.NPCType("寒冰封印石")) < 1 &&NPC.CountNPCS(mod.NPCType("星辰封印石")) < 1)
            {
				base.npc.dontTakeDamage = false;
			}
			else
			{
				base.npc.dontTakeDamage = true;
			}
		}
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.npc.alpha));
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.npcTexture[base.npc.type];
            int num = Main.npcTexture[base.npc.type].Height;
			Main.spriteBatch.Draw(texture2D, base.npc.Center - Main.screenPosition + new Vector2(0f, base.npc.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.npc.GetAlpha(lightColor), base.npc.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.npc.scale, SpriteEffects.None, 1f);
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				Vector2 vector = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
				NPC.NewNPC((int)base.npc.Center.X, (int)base.npc.Center.Y, mod.NPCType("FinalEye"), 0, 0f, 0f, 0f, 0f, 255);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.mod.ProjectileType("终天灭世眼HiaHiaHiaHia"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
		}
		public override bool CheckActive()
		{
			return this.canDespawn;
		}
	}
}
