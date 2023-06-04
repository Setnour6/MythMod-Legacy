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
using Terraria.ModLoader.Utilities;

namespace MythMod.NPCs
{
	[AutoloadBossHead]
    public class BloodTusk : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("鲜血獠牙");
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
            NPC.behindTiles = true;
            base.NPC.damage = 0;
			base.NPC.width = 110;
			base.NPC.height = 132;
			base.NPC.defense = 15;
			base.NPC.lifeMax = (Main.expertMode ? 5500 : 3300);
			if(MythWorld.Myth)
			{
				base.NPC.lifeMax = 6050;
			}
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 255;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
            base.NPC.boss = true;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}
        public override void AI()
        {
            base.NPC.TargetClosest(false);
            Player player = Main.player[base.NPC.target];
            bool flag2 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.8;
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            float num6 = expertMode ? 5f : 3f;
            base.NPC.localAI[0] += 2;
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
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.alpha += 5;
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    if (base.NPC.alpha >= 254)
                    {
                        base.NPC.velocity = new Vector2(0f, 1000f);
                    }
                    return;
                }
            }
            if (expertMode && !MythWorld.Myth)
            {
                base.NPC.defense = 10 + (int)(Math.Abs(num) / 10f);
            }
            if (num2 - 35 <= -55 || Math.Abs(num) >= 800f || !player.ZoneCrimson)
            {
                base.NPC.dontTakeDamage = true;
            }
            else
            {
                base.NPC.dontTakeDamage = false;
            }
            if (base.NPC.collideY)
            {
                if (X)
                {
                    base.NPC.localAI[0] = 0;
                    X = false;
                    T = true;
                }
                if (base.NPC.ai[0] == 0f)
                {
                    base.NPC.chaseable = true;
                    if (Main.netMode != 1)
                    {
                        base.NPC.noTileCollide = true;
                        if (base.NPC.localAI[0] > 6)
                        {
                            base.NPC.noGravity = true;
                            base.NPC.velocity.Y = 0;
                        }
                    }
                }
            }
            if (T && base.NPC.localAI[0] >= 0f && base.NPC.localAI[0] <= 81 && base.NPC.localAI[0] % 1 == 0)
            {
                base.NPC.alpha -= 5;
            }
            if (T && base.NPC.localAI[0] > 81f && base.NPC.localAI[0] <= 100f && base.NPC.localAI[0] % 1 == 0)
            {
                base.NPC.alpha += 2;
            }
            if (T && base.NPC.localAI[0] > 100f && base.NPC.localAI[0] <= 140f && base.NPC.localAI[0] % 1 == 0)
            {
                base.NPC.alpha -= 6;
            }
            if (T && base.NPC.localAI[0] > 140f)
            {
                T = false;
            }
            if (base.NPC.life > base.NPC.lifeMax * 0.7f && base.NPC.life < base.NPC.lifeMax)
            {
                if (MythWorld.Myth)
                {
                    base.NPC.damage = 80;
                }
                else
                {
                    base.NPC.damage = 40;
                }
                if (base.NPC.localAI[0] >= 0f && base.NPC.localAI[0] <= 12f)
                {
                    num13 = Main.rand.Next(-1000, 1000) / 40f;
                }
                if (base.NPC.localAI[0] >= 15f && base.NPC.localAI[0] <= 320f && base.NPC.localAI[0] % 40 == 0)
                {
                    NPC.NewNPC((int)(base.NPC.Center.X + base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulp").Type, 0, 0f, 0f, 0f, 0f, 255);
                    NPC.NewNPC((int)(base.NPC.Center.X - base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulp").Type, 0, 0f, 0f, 0f, 0f, 255);
                }
                if (base.NPC.localAI[0] >= 340f)
                {
                    base.NPC.localAI[0] = 0;
                }
            }
            if (base.NPC.life <= base.NPC.lifeMax * 0.7f)
            {
                if (MythWorld.Myth)
                {
                    base.NPC.damage = 100;
                }
                else
                {
                    base.NPC.damage = 50;
                }
                if (base.NPC.localAI[0] == 0f && base.NPC.localAI[0] <= 12f)
                {
                    num13 = Main.rand.Next(-1000, 1000) / 40f;
                }
                if (base.NPC.localAI[0] >= 15f && base.NPC.localAI[0] <= 320f && base.NPC.localAI[0] % 30 == 0)
                {
                    int type = 0;
                    int type2 = 0;
                    if (MythWorld.Myth)
                    {
                        NPC.NewNPC((int)(base.NPC.Center.X + base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulpplus").Type, 0, 0f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)(base.NPC.Center.X - base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulpplus").Type, 0, 0f, 0f, 0f, 0f, 255);
                    }
                    else
                    {
                        NPC.NewNPC((int)(base.NPC.Center.X + base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulp").Type, 0, 0f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)(base.NPC.Center.X - base.NPC.localAI[0] * 3f + num13), (int)(player.Center.Y - 40f), Mod.Find<ModNPC>("DentalPulp").Type, 0, 0f, 0f, 0f, 0f, 255);
                    }
                }
                if (base.NPC.localAI[0] >= 340f)
                {
                    base.NPC.localAI[0] = 0;
                }
                if (base.NPC.localAI[0] % 48 == 0 && base.NPC.life <= base.NPC.lifeMax * 0.4f && expertMode && !MythWorld.Myth)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 16f;
                    int num11 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, num12, -num13, base.Mod.Find<ModProjectile>("CrimsonTusk7").Type, 32, 2f, Main.myPlayer, 0f, 0f);
                }
                if (base.NPC.localAI[0] % 24 == 0 && base.NPC.life <= base.NPC.lifeMax * 0.3f && MythWorld.Myth)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 16f;
                    int num11 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, num12, -num13, base.Mod.Find<ModProjectile>("CrimsonTusk7").Type, 32, 2f, Main.myPlayer, 0f, 0f);
                }
                if (base.NPC.localAI[0] % 288 == 0 && base.NPC.life <= base.NPC.lifeMax * 0.6f && MythWorld.Myth)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        float num12 = Main.rand.Next(-10000, 10000) / 700f;
                        int num11 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, num12, (float)(-Math.Sqrt(1000 - (num12 * num12))), base.Mod.Find<ModProjectile>("CrimsonTusk7").Type, 32, 2f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (base.NPC.life <= 0)
			{
                for (int u = 0; u < 45; u++)
                {
                    float vX = (float)Main.rand.Next(-2000, 2000) / 1000f;
                    float vY = (float)(Math.Cos(vX / 4d * Math.PI)) * 12f;
                    int r = Dust.NewDust(new Vector2(NPC.Center.X, NPC.Center.Y + 22f), 0, 0, 117, vX, -vY, 0, default(Color), 1.1f);
                    Main.dust[r].noGravity = false;
                }
                for (int u = 0; u < 150; u++)
                {
                    float vX = (float)Main.rand.Next(-2000, 2000) / 6000f;
                    float vY = (float)(Math.Cos(vX * Math.PI)) * 2f;
                    int r = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y + 110f), NPC.width, 30, 117, vX, -vY, 0, default(Color), 3f);
                    Main.dust[r].noGravity = false;
                }
                for (int u = 0; u < 12; u++)
                {
                    float num12 = Main.rand.Next(-10000, 10000) / 2000f;
                    float num13 = (float)(Math.Cos(num12 / 16d * Math.PI)) * 24f * Main.rand.NextFloat(0.6f,1.8f);
                    int num11 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, num12, -num13, base.Mod.Find<ModProjectile>("BrokenTusk").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                }
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                Vector2 vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块1"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块2"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 6f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块3"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块4"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块5"), 1f);
                vFX = (float)Main.rand.Next(-2000, 2000) / 5000f;
                vF = new Vector2(vFX, -(float)(Math.Cos(vFX * Math.PI)) * 12f);
                Gore.NewGore(base.NPC.position, vF, base.Mod.GetGoreSlot("Gores/鲜血獠牙碎块6"), 1f);
                /*NPC.NewNPC((int)(base.npc.position.X + 55f), (int)(base.npc.position.Y + 66f), mod.NPCType("BloodTuskBroken"), 0, 0f, 0f, 0f, 0f, 255);*/
            }
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe || NPC.AnyNPCs(base.Mod.Find<ModNPC>("BloodTusk").Type))
			{
				return 0f;
			}
			return SpawnCondition.Crimson.Chance * (Main.hardMode ? 0.01f : 0.02f);
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Color color = Lighting.GetColor((int)(NPC.Center.X / 16d), (int)(NPC.Center.Y / 16d));
            color = NPC.GetAlpha(color) * ((255 - NPC.alpha) / 255f);

            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS3b"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[2], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS4b"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[3], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskFleshBack"), NPC.position - Main.screenPosition + new Vector2(30, 60), new Rectangle(0, 0, 220, 250), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskTeeth"), NPC.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS1"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[0], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS2"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[1], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS5"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[4], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS6"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[5], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS7"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[6], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskS8"), NPC.position - Main.screenPosition + new Vector2(30, 60) + V[7], new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/BloodTuskFlesh"), NPC.position - Main.screenPosition + new Vector2(30, 60), new Rectangle?(base.NPC.frame), color, base.NPC.rotation, new Vector2(110, 156), 1f, SpriteEffects.None, 0f);
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
        public override void OnKill()
        {
			bool expertMode = Main.expertMode;
            Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BoneLiquid").Type, 15, false, 0, false, false);
			Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenTooth").Type, 15, false, 0, false, false);
			if(expertMode)
			{
                Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BoneLiquid").Type, 15, false, 0, false, false);
                Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenTooth").Type, 15, false, 0, false, false);
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BloodyTuskTreasureBag").Type, 1, false, 0, false, false);
                if(MythWorld.Myth)
                {
                    Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BoneLiquid").Type, 15, false, 0, false, false);
                    Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenTooth").Type, 15, false, 0, false, false);
                    Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("XXLYChest").Type, 1, false, 0, false, false);
                }
			}
			else
			{
				int type = 0;
	    		switch (Main.rand.Next(1 , 7))
	    		{
	    		case 1:
                   type = base.Mod.Find<ModItem>("BoneKnife").Type;
	    		    break;
	    		case 2:
                   type = base.Mod.Find<ModItem>("SpineGun").Type;
	    		    break;
		    	case 3:
                    type = base.Mod.Find<ModItem>("TuskBow").Type;
		   	        break;
		    	case 4:
                    type = base.Mod.Find<ModItem>("TuskStaff").Type;
		    	    break;
                case 5:
                    type = base.Mod.Find<ModItem>("ToothBlade").Type;
		    	    break;
	    		case 6:
                   type = base.Mod.Find<ModItem>("BloodyBoneYoyo").Type;
		    	    break;
		    	}
				Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
                if (Main.rand.Next(10) == 1)
                {
                    Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BloodyTuskPlatfo").Type, 1, false, 0, false, false);
                }
            }
            if (!MythWorld.downedXXLY)
            {
                MythWorld.downedXXLY = true;
            }
        }
	}
}
