using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
	[AutoloadBossHead]
    public class BloodTusk : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("鲜血獠牙");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "鲜血獠牙");
        }
		private bool X = true;
		private int num10;
		private float num13;
		private bool T = false;
        private Vector2[] V = new Vector2[9];
        private Vector2[] VMax = new Vector2[9];
        private int[] I = new int[9];
        public override void SetDefaults()
		{
            npc.behindTiles = true;
            base.npc.damage = 0;
			base.npc.width = 110;
			base.npc.height = 132;
			base.npc.defense = 15;
			base.npc.lifeMax = (Main.expertMode ? 5500 : 3300);
			if(MythWorld.Myth)
			{
				base.npc.lifeMax = 6050;
			}
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 255;
			base.npc.aiStyle = -1;
			this.aiType = -1;
            base.npc.boss = true;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
		}
        public override void AI()
        {
            base.npc.TargetClosest(false);
            Player player = Main.player[base.npc.target];
            bool flag2 = (double)base.npc.life <= (double)base.npc.lifeMax * 0.8;
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            float num6 = expertMode ? 5f : 3f;
            base.npc.localAI[0] += 2;
            VMax[0] = new Vector2(14, 18);
            VMax[1] = new Vector2(-8, 24);
            VMax[2] = new Vector2(0, 38);
            VMax[3] = new Vector2(6, 30);
            VMax[4] = new Vector2(-30, 30);
            VMax[5] = new Vector2(-10, 34);
            VMax[6] = new Vector2(12, 48);
            VMax[7] = new Vector2(16, 32);
            for (int n = 0;n <= 7;n++)
            {
                if (I[n] == 0)
                {
                    if ((V[n]).Length() > 0.5f)
                    {
                        V[n] = V[n] * 0.95f;
                    }
                    else
                    {
                        if (Main.rand.Next(600) == 0)

                        {
                            I[n] = 1;
                        }
                    }
                }
                if (I[n] == 1)
                {
                    if ((V[n] - VMax[n]).Length() > 0.5f)
                    {
                        V[n] = V[n] * 0.95f + VMax[n] * 0.05f;
                    }
                    else
                    {
                        if (Main.rand.Next(240) == 0)
                        {
                            I[n] = 0;
                        }
                    }
                }
            }           
            if (!player.active || player.dead)
            {
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.alpha += 5;
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    if (base.npc.alpha >= 254)
                    {
                        base.npc.velocity = new Vector2(0f, 1000f);
                    }
                    return;
                }
            }
            if (expertMode && !MythWorld.Myth)
            {
                base.npc.defense = 10 + (int)(Math.Abs(num) / 10f);
            }
            if (num2 - 35 <= -55 || Math.Abs(num) >= 800f || !player.ZoneCrimson)
            {
                base.npc.dontTakeDamage = true;
            }
            else
            {
                base.npc.dontTakeDamage = false;
            }
            if (base.npc.collideY)
            {
                if (X)
                {
                    base.npc.localAI[0] = 0;
                    X = false;
                    T = true;
                }
                if (base.npc.ai[0] == 0f)
                {
                    base.npc.chaseable = true;
                    if (Main.netMode != 1)
                    {
                        base.npc.noTileCollide = true;
                        if (base.npc.localAI[0] > 6)
                        {
                            base.npc.noGravity = true;
                            base.npc.velocity.Y = 0;
                        }
                    }
                }
            }
            if (T && base.npc.localAI[0] >= 0f && base.npc.localAI[0] <= 81 && base.npc.localAI[0] % 1 == 0)
            {
                base.npc.alpha -= 5;
            }
            if (T && base.npc.localAI[0] > 81f && base.npc.localAI[0] <= 100f && base.npc.localAI[0] % 1 == 0)
            {
                base.npc.alpha += 2;
            }
            if (T && base.npc.localAI[0] > 100f && base.npc.localAI[0] <= 140f && base.npc.localAI[0] % 1 == 0)
            {
                base.npc.alpha -= 6;
            }
            if (T && base.npc.localAI[0] > 140f)
            {
                T = false;
            }
            if (base.npc.life > base.npc.lifeMax * 0.7f && base.npc.life < base.npc.lifeMax)
            {
                if (MythWorld.Myth)
                {
                    base.npc.damage = 80;
                }
                else
                {
                    base.npc.damage = 40;
                }
                if (base.npc.localAI[0] >= 0f && base.npc.localAI[0] <= 12f)
                {
                    num13 = Main.rand.Next(-1000, 1000) / 40f;
                }
                if (base.npc.localAI[0] >= 15f && base.npc.localAI[0] <= 320f && base.npc.localAI[0] % 40 == 0)
                {
                    NPC.NewNPC((int)(base.npc.Center.X + base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulp"), 0, 0f, 0f, 0f, 0f, 255);
                    NPC.NewNPC((int)(base.npc.Center.X - base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulp"), 0, 0f, 0f, 0f, 0f, 255);
                }
                if (base.npc.localAI[0] >= 340f)
                {
                    base.npc.localAI[0] = 0;
                }
            }
            if (base.npc.life <= base.npc.lifeMax * 0.7f)
            {
                if (MythWorld.Myth)
                {
                    base.npc.damage = 100;
                }
                else
                {
                    base.npc.damage = 50;
                }
                if (base.npc.localAI[0] == 0f && base.npc.localAI[0] <= 12f)
                {
                    num13 = Main.rand.Next(-1000, 1000) / 40f;
                }
                if (base.npc.localAI[0] >= 15f && base.npc.localAI[0] <= 320f && base.npc.localAI[0] % 30 == 0)
                {
                    int type = 0;
                    int type2 = 0;
                    if (MythWorld.Myth)
                    {
                        NPC.NewNPC((int)(base.npc.Center.X + base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulpplus"), 0, 0f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)(base.npc.Center.X - base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulpplus"), 0, 0f, 0f, 0f, 0f, 255);
                    }
                    else
                    {
                        NPC.NewNPC((int)(base.npc.Center.X + base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulp"), 0, 0f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)(base.npc.Center.X - base.npc.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), mod.NPCType("DentalPulp"), 0, 0f, 0f, 0f, 0f, 255);
                    }
                }
                if (base.npc.localAI[0] >= 340f)
                {
                    base.npc.localAI[0] = 0;
                }
                if (base.npc.localAI[0] % 48 == 0 && base.npc.life <= base.npc.lifeMax * 0.4f && expertMode && !MythWorld.Myth)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 16f;
                    int num11 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, num12, -num13, base.mod.ProjectileType("CrimsonTusk7"), 32, 2f, Main.myPlayer, 0f, 0f);
                }
                if (base.npc.localAI[0] % 24 == 0 && base.npc.life <= base.npc.lifeMax * 0.3f && MythWorld.Myth)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 16f;
                    int num11 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, num12, -num13, base.mod.ProjectileType("CrimsonTusk7"), 32, 2f, Main.myPlayer, 0f, 0f);
                }
                if (base.npc.localAI[0] % 288 == 0 && base.npc.life <= base.npc.lifeMax * 0.6f && MythWorld.Myth)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        float num12 = Main.rand.Next(-10000, 10000) / 700f;
                        int num11 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, num12, (float)(-Math.Sqrt(1000 - (num12 * num12))), base.mod.ProjectileType("CrimsonTusk7"), 32, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
                for (int u = 0; u < 45; u++)
                {
                    float vX = (float)Main.rand.Next(-2000, 2000) / 1000f;
                    float vY = (float)(Math.Cos(vX / 4d * Math.PI)) * 12f;
                    int r = Dust.NewDust(new Vector2(npc.Center.X, npc.Center.Y + 22f), 0, 0, 117, vX, -vY, 0, default(Color), 1.1f);
                    Main.dust[r].noGravity = false;
                }
                for (int u = 0; u < 150; u++)
                {
                    float vX = (float)Main.rand.Next(-2000, 2000) / 6000f;
                    float vY = (float)(Math.Cos(vX * Math.PI)) * 2f;
                    int r = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 110f), npc.width, 30, 117, vX, -vY, 0, default(Color), 3f);
                    Main.dust[r].noGravity = false;
                }
                for (int u = 0; u < 12; u++)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 24f * Main.rand.NextFloat(0.6f,1.8f);
                    int num11 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, num12, -num13, base.mod.ProjectileType("BrokenTusk"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                Vector2 vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块1"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块2"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块3"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块4"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块5"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.npc.position, vF, base.mod.GetGoreSlot("Gores/鲜血獠牙碎块6"), 1f);
                /*NPC.NewNPC((int)(base.npc.position.X + 55f), (int)(base.npc.position.Y + 66f), mod.NPCType("BloodTuskBroken"), 0, 0f, 0f, 0f, 0f, 255);*/
            }
		}
        public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe || NPC.AnyNPCs(base.mod.NPCType("BloodTusk")))
			{
				return 0f;
			}
			return SpawnCondition.Crimson.Chance * (Main.hardMode ? 0.01f : 0.02f);
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color color = Lighting.GetColor((int)(npc.Center.X / 16d), (int)(npc.Center.Y / 16d));
            color = npc.GetAlpha(color) * ((255 - npc.alpha) / 255f);

            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS3b"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[2], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS4b"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[3], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskFleshBack"), npc.position - Main.screenPosition + new Vector2(30, 60), new Rectangle(0, 0, 220, 250), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskTeeth"), npc.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS1"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[0], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS2"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[1], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS5"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[4], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS6"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[5], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS7"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[6], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskS8"), npc.position - Main.screenPosition + new Vector2(30, 60) + V[7], new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/BloodTuskFlesh"), npc.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.npc.frame), color, base.npc.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            return false;
        }
        private int Dead = 0;
        /*public override bool CheckDead()
        {
            if(Dead == 0)
            {
                return false;
            }
            return base.CheckDead();
        }*/
        public override void NPCLoot()
        {
			bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BoneLiquid"), 15, false, 0, false, false);
			Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenTooth"), 15, false, 0, false, false);
			if(expertMode)
			{
                Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BoneLiquid"), 15, false, 0, false, false);
                Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenTooth"), 15, false, 0, false, false);
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("BloodyTuskTreasureBag"), 1, false, 0, false, false);
                if(MythWorld.Myth)
                {
                    Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BoneLiquid"), 15, false, 0, false, false);
                    Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenTooth"), 15, false, 0, false, false);
                    Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("XXLYChest"), 1, false, 0, false, false);
                }
			}
			else
			{
				int type = 0;
	    		switch (Main.rand.Next(1 , 7))
	    		{
	    		case 1:
                   type = base.mod.ItemType("BoneKnife");
	    		    break;
	    		case 2:
                   type = base.mod.ItemType("SpineGun");
	    		    break;
		    	case 3:
                    type = base.mod.ItemType("TuskBow");
		   	        break;
		    	case 4:
                    type = base.mod.ItemType("TuskStaff");
		    	    break;
                case 5:
                    type = base.mod.ItemType("ToothBlade");
		    	    break;
	    		case 6:
                   type = base.mod.ItemType("BloodyBoneYoyo");
		    	    break;
		    	}
				Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
                if (Main.rand.Next(10) == 1)
                {
                    Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("BloodyTuskPlatfo"), 1, false, 0, false, false);
                }
            }
            if (!MythWorld.downedXXLY)
            {
                MythWorld.downedXXLY = true;
            }
        }
	}
}
