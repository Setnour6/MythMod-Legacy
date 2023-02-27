using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using System.Text;

namespace MythMod.NPCs
{
	[AutoloadBossHead]
    public class CorruptMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("腐檀巨蛾");
			Main.npcFrameCount[base.NPC.type] = 4;
		}
		private float m;
		private bool num4;
		private bool k;
		private bool X = true;
		public override void SetDefaults()
		{
			base.NPC.damage = 40;
			base.NPC.width = 128;
			base.NPC.height = 160;
			base.NPC.defense = 0;
			base.NPC.lifeMax = (Main.expertMode ? 2520 : 4000);
			if(MythWorld.Myth)
			{
				base.NPC.lifeMax = 2650;
			}
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.boss = true;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			NPCID.Sets.TrailCacheLength[base.NPC.type] = 4;
            NPCID.Sets.TrailingMode[base.NPC.type] = 0;
		}
		public override void AI()
		{
			base.NPC.TargetClosest(false);
            Player player = Main.player[base.NPC.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			base.NPC.dontTakeDamage = !player.ZoneCorrupt;
			base.NPC.localAI[0] += 1;
			Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 191, base.NPC.velocity.X * 0.5f,  base.NPC.velocity.Y * 0.5f, 0, default(Color), 0.6f);
			if(Main.rand.Next(10) == 5)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 172, base.NPC.velocity.X * 0.5f,  base.NPC.velocity.Y * 0.5f, 0, default(Color), 0.75f);
			}
            if (!player.active || player.dead)
            {
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.velocity = new Vector2(0f, 10f);
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    return;
                }
            }
			if(base.NPC.life > base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] <= 120)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.NPC.life > base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 120 && base.NPC.localAI[0] < 185)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 12f;
				}
				else
				{
					base.NPC.velocity.X = -12f;
				}
			}
			if(base.NPC.localAI[0] > 200 && base.NPC.life > base.NPC.lifeMax * 0.5)
			{
				base.NPC.localAI[0] = 30;
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && X)
			{
				X = false;
				base.NPC.localAI[0] = 0;
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] <= 120)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 120 && base.NPC.localAI[0] < 160)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 19.5f;
				}
				else
				{
					base.NPC.velocity.X = -19.5f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 170 && base.NPC.localAI[0] <= 220)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 220 && base.NPC.localAI[0] < 260)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 19.5f;
				}
				else
				{
					base.NPC.velocity.X = -19.5f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 290 && base.NPC.localAI[0] <= 340)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 340 && base.NPC.localAI[0] < 400)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 19.5f;
				}
				else
				{
					base.NPC.velocity.X = -19.5f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 410 && base.NPC.localAI[0] <= 460)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 900, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 900, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 460 && base.NPC.localAI[0] < 585)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 12f;
				}
				else
				{
					base.NPC.velocity.X = -12f;
				}
				if(base.NPC.localAI[0] % (Main.expertMode ? 12 : 15) == 0 && base.NPC.localAI[0] > 460 && base.NPC.localAI[0] < 585 && !MythWorld.Myth)
			    {
					int num5 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.2f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
			    }
				if(MythWorld.Myth && base.NPC.localAI[0] % 20 == 10 && base.NPC.localAI[0] > 460 && base.NPC.localAI[0] < 585)
				{
					int num6 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.05f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.NPC.localAI[0] % 20 == 0 && base.NPC.localAI[0] > 460 && base.NPC.localAI[0] < 585)
				{
					int num7 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.4f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.NPC.localAI[0] % 10 == 0 && base.NPC.localAI[0] > 460 && base.NPC.localAI[0] < 585)
				{
					int num8 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.1f, -3f, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 585 && base.NPC.localAI[0] <= 635)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 900, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 900, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] > 635 && base.NPC.localAI[0] < 760)
			{
				if(num4 && num > 0)
				{
					k = true;
					num4 = false;
				}
				if(num4 && num < 0)
				{
					k = false;
					num4 = false;
				}
				if(k)
				{
					base.NPC.velocity.X = 12f;
				}
				else
				{
					base.NPC.velocity.X = -12f;
				}
				if(base.NPC.localAI[0] % (Main.expertMode ? 12 : 15) == 0 && base.NPC.localAI[0] > 635 && base.NPC.localAI[0] < 760 && !MythWorld.Myth)
			    {
					int num5 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.2f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
			    }
				if(MythWorld.Myth && base.NPC.localAI[0] % 20 == 10 && base.NPC.localAI[0] > 635 && base.NPC.localAI[0] < 760)
				{
					int num6 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.05f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.NPC.localAI[0] % 20 == 0 && base.NPC.localAI[0] > 635 && base.NPC.localAI[0] < 760)
				{
					int num7 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.4f, 1, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.NPC.localAI[0] % 10 == 0 && base.NPC.localAI[0] > 635 && base.NPC.localAI[0] < 760)
				{
					int num8 = Projectile.NewProjectile(vector.X, vector.Y, base.NPC.velocity.X * 0.1f, -3f, base.Mod.Find<ModProjectile>("MagicLightBullet").Type, 40, 2f, Main.myPlayer, 0f, 0f);
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 770 && base.NPC.localAI[0] <= 830)
			{
				base.NPC.direction = ((num < 0f) ? -1 : 1);
				base.NPC.spriteDirection = base.NPC.direction;
				num4 = true;
				if(num > 0)
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X - 300, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.NPC.velocity = new Vector2(player.Center.X - vector.X + 300, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] >= 830 && base.NPC.localAI[0] <= 1000)
			{
				base.NPC.noTileCollide = false;
				base.NPC.velocity.Y = 2f;
				base.NPC.velocity.X = 0f;
			}
		    if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] == 990)
			{
                NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("MagicEgg").Type, 0, 0f, 0f, 0f, 0f, 255);
				base.NPC.velocity.Y = 0f;
			}
			if(base.NPC.life < base.NPC.lifeMax * 0.5 && base.NPC.localAI[0] == 1005)
			{
				base.NPC.noTileCollide = true;
				base.NPC.localAI[0] = 0;
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.NPC.life <= 0)
			{
				for (int j = 0; j < 80; j++)
				{
					Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 39, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
				for (int j = 0; j < 40; j++)
				{
					Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 191, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腐檀巨蛾碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腐檀巨蛾碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腐檀巨蛾碎块3"), 1f);
				Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腐檀巨蛾碎块4"), 1f);
			}
		}
		public override void FindFrame(int frameHeight)
		{
			base.NPC.frameCounter += 0.15;
			base.NPC.frameCounter %= (double)Main.npcFrameCount[base.NPC.type];
			int num = (int)base.NPC.frameCounter;
			base.NPC.frame.Y = num * frameHeight;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/腐檀巨蛾光辉").Width, (float)(base.Mod.GetTexture("NPCs/腐檀巨蛾光辉").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/腐檀巨蛾光辉"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
			SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 160;
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2) + 2, (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2) + 4);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
				Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition + vector + new Vector2(0f, NPC.gfxOffY);
                Color color = NPC.GetAlpha(lightColor) * ((float)(NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, new Rectangle(0 ,frameHeight * (3 - (((int)NPC.frameCounter + (int)(k / 1.58333333f)) % 4)), (int)(base.Mod.GetTexture("NPCs/CorruptMoth").Width) ,frameHeight), color, NPC.rotation, vector, NPC.scale, effects, 0f);
            }
            return true;
        }
		public override void OnKill()
        {
			bool expertMode = Main.expertMode;
            Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("EvilScaleDust").Type, 15, false, 0, false, false);
			Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenWingOfMoth").Type, 15, false, 0, false, false);
			if(expertMode)
			{
                Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("EvilScaleDust").Type, 15, false, 0, false, false);
                Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenWingOfMoth").Type, 15, false, 0, false, false);
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CorruptMothTreasureBag").Type, 1, false, 0, false, false);
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("FTJEChest").Type, 1, false, 0, false, false);
                    Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("EvilScaleDust").Type, 15, false, 0, false, false);
                    Item.NewItem((int)base.NPC.position.X - 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("BrokenWingOfMoth").Type, 15, false, 0, false, false);
                }
            }
			else
			{
				int type = 0;
                switch (Main.rand.Next(1, 7))
                {
                    case 1:
                        type = base.Mod.Find<ModItem>("DustOfCorrupt").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("PhosphorescenceGun").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("ScaleWingBlade").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("MothYoyo").Type;
                        break;
                    case 5:
                        type = base.Mod.Find<ModItem>("EvilChrysalis").Type;
                        break;
                    case 6:
                        type = base.Mod.Find<ModItem>("ShadowWingBow").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 1)
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("CorruptMothPlatform").Type, 1, false, 0, false, false);
            }
            if (!MythWorld.downedFTJE)
            {
                MythWorld.downedFTJE = true;
            }
        }
	}
}
