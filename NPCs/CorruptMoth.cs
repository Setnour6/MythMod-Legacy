using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
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
			Main.npcFrameCount[base.npc.type] = 4;
		}
		private float m;
		private bool num4;
		private bool k;
		private bool X = true;
		public override void SetDefaults()
		{
			base.npc.damage = 40;
			base.npc.width = 128;
			base.npc.height = 160;
			base.npc.defense = 0;
			base.npc.lifeMax = (Main.expertMode ? 2520 : 4000);
			if(MythWorld.Myth)
			{
				base.npc.lifeMax = 2650;
			}
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 0;
            base.npc.boss = true;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			NPCID.Sets.TrailCacheLength[base.npc.type] = 4;
            NPCID.Sets.TrailingMode[base.npc.type] = 0;
		}
		public override void AI()
		{
			base.npc.TargetClosest(false);
            Player player = Main.player[base.npc.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			base.npc.dontTakeDamage = !player.ZoneCorrupt;
			base.npc.localAI[0] += 1;
			Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 191, base.npc.velocity.X * 0.5f,  base.npc.velocity.Y * 0.5f, 0, default(Color), 0.6f);
			if(Main.rand.Next(10) == 5)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 172, base.npc.velocity.X * 0.5f,  base.npc.velocity.Y * 0.5f, 0, default(Color), 0.75f);
			}
            if (!player.active || player.dead)
            {
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.velocity = new Vector2(0f, 10f);
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    return;
                }
            }
			if(base.npc.life > base.npc.lifeMax * 0.5 && base.npc.localAI[0] <= 120)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.npc.life > base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 120 && base.npc.localAI[0] < 185)
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
					base.npc.velocity.X = 12f;
				}
				else
				{
					base.npc.velocity.X = -12f;
				}
			}
			if(base.npc.localAI[0] > 200 && base.npc.life > base.npc.lifeMax * 0.5)
			{
				base.npc.localAI[0] = 30;
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && X)
			{
				X = false;
				base.npc.localAI[0] = 0;
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] <= 120)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 120 && base.npc.localAI[0] < 160)
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
					base.npc.velocity.X = 19.5f;
				}
				else
				{
					base.npc.velocity.X = -19.5f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 170 && base.npc.localAI[0] <= 220)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 220 && base.npc.localAI[0] < 260)
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
					base.npc.velocity.X = 19.5f;
				}
				else
				{
					base.npc.velocity.X = -19.5f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 290 && base.npc.localAI[0] <= 340)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 500, player.Center.Y - vector.Y) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 500, player.Center.Y - vector.Y) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 340 && base.npc.localAI[0] < 400)
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
					base.npc.velocity.X = 19.5f;
				}
				else
				{
					base.npc.velocity.X = -19.5f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 410 && base.npc.localAI[0] <= 460)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 900, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 900, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 460 && base.npc.localAI[0] < 585)
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
					base.npc.velocity.X = 12f;
				}
				else
				{
					base.npc.velocity.X = -12f;
				}
				if(base.npc.localAI[0] % (Main.expertMode ? 12 : 15) == 0 && base.npc.localAI[0] > 460 && base.npc.localAI[0] < 585 && !MythWorld.Myth)
			    {
					int num5 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.2f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
			    }
				if(MythWorld.Myth && base.npc.localAI[0] % 20 == 10 && base.npc.localAI[0] > 460 && base.npc.localAI[0] < 585)
				{
					int num6 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.05f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.npc.localAI[0] % 20 == 0 && base.npc.localAI[0] > 460 && base.npc.localAI[0] < 585)
				{
					int num7 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.4f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.npc.localAI[0] % 10 == 0 && base.npc.localAI[0] > 460 && base.npc.localAI[0] < 585)
				{
					int num8 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.1f, -3f, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 585 && base.npc.localAI[0] <= 635)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 900, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 900, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] > 635 && base.npc.localAI[0] < 760)
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
					base.npc.velocity.X = 12f;
				}
				else
				{
					base.npc.velocity.X = -12f;
				}
				if(base.npc.localAI[0] % (Main.expertMode ? 12 : 15) == 0 && base.npc.localAI[0] > 635 && base.npc.localAI[0] < 760 && !MythWorld.Myth)
			    {
					int num5 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.2f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
			    }
				if(MythWorld.Myth && base.npc.localAI[0] % 20 == 10 && base.npc.localAI[0] > 635 && base.npc.localAI[0] < 760)
				{
					int num6 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.05f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.npc.localAI[0] % 20 == 0 && base.npc.localAI[0] > 635 && base.npc.localAI[0] < 760)
				{
					int num7 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.4f, 1, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
				if(MythWorld.Myth && base.npc.localAI[0] % 10 == 0 && base.npc.localAI[0] > 635 && base.npc.localAI[0] < 760)
				{
					int num8 = Projectile.NewProjectile(vector.X, vector.Y, base.npc.velocity.X * 0.1f, -3f, base.mod.ProjectileType("MagicLightBullet"), 40, 2f, Main.myPlayer, 0f, 0f);
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 770 && base.npc.localAI[0] <= 830)
			{
				base.npc.direction = ((num < 0f) ? -1 : 1);
				base.npc.spriteDirection = base.npc.direction;
				num4 = true;
				if(num > 0)
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X - 300, player.Center.Y - vector.Y - 200) / 16f;
				}
				else
				{
					base.npc.velocity = new Vector2(player.Center.X - vector.X + 300, player.Center.Y - vector.Y - 200) / 16f;
				}
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] >= 830 && base.npc.localAI[0] <= 1000)
			{
				base.npc.noTileCollide = false;
				base.npc.velocity.Y = 2f;
				base.npc.velocity.X = 0f;
			}
		    if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] == 990)
			{
                NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("MagicEgg"), 0, 0f, 0f, 0f, 0f, 255);
				base.npc.velocity.Y = 0f;
			}
			if(base.npc.life < base.npc.lifeMax * 0.5 && base.npc.localAI[0] == 1005)
			{
				base.npc.noTileCollide = true;
				base.npc.localAI[0] = 0;
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
				for (int j = 0; j < 80; j++)
				{
					Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 39, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
				for (int j = 0; j < 40; j++)
				{
					Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 191, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
                base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腐檀巨蛾碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腐檀巨蛾碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腐檀巨蛾碎块3"), 1f);
				Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腐檀巨蛾碎块4"), 1f);
			}
		}
		public override void FindFrame(int frameHeight)
		{
			base.npc.frameCounter += 0.15;
			base.npc.frameCounter %= (double)Main.npcFrameCount[base.npc.type];
			int num = (int)base.npc.frameCounter;
			base.npc.frame.Y = num * frameHeight;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/腐檀巨蛾光辉").Width, (float)(base.mod.GetTexture("NPCs/腐檀巨蛾光辉").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/腐檀巨蛾光辉"), vector2, new Rectangle?(base.npc.frame), color, base.npc.rotation, vector, 1f, effects, 0f);
        }
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 160;
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2) + 2, (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2) + 4);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
				Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + vector + new Vector2(0f, npc.gfxOffY);
                Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, new Rectangle(0 ,frameHeight * (3 - (((int)npc.frameCounter + (int)(k / 1.58333333f)) % 4)), (int)(base.mod.GetTexture("NPCs/CorruptMoth").Width) ,frameHeight), color, npc.rotation, vector, npc.scale, effects, 0f);
            }
            return true;
        }
		public override void NPCLoot()
        {
			bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("EvilScaleDust"), 15, false, 0, false, false);
			Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenWingOfMoth"), 15, false, 0, false, false);
			if(expertMode)
			{
                Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("EvilScaleDust"), 15, false, 0, false, false);
                Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenWingOfMoth"), 15, false, 0, false, false);
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("CorruptMothTreasureBag"), 1, false, 0, false, false);
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("FTJEChest"), 1, false, 0, false, false);
                    Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("EvilScaleDust"), 15, false, 0, false, false);
                    Item.NewItem((int)base.npc.position.X - 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("BrokenWingOfMoth"), 15, false, 0, false, false);
                }
            }
			else
			{
				int type = 0;
                switch (Main.rand.Next(1, 7))
                {
                    case 1:
                        type = base.mod.ItemType("DustOfCorrupt");
                        break;
                    case 2:
                        type = base.mod.ItemType("PhosphorescenceGun");
                        break;
                    case 3:
                        type = base.mod.ItemType("ScaleWingBlade");
                        break;
                    case 4:
                        type = base.mod.ItemType("MothYoyo");
                        break;
                    case 5:
                        type = base.mod.ItemType("EvilChrysalis");
                        break;
                    case 6:
                        type = base.mod.ItemType("ShadowWingBow");
                        break;
                }
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 1)
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("CorruptMothPlatform"), 1, false, 0, false, false);
            }
            if (!MythWorld.downedFTJE)
            {
                MythWorld.downedFTJE = true;
            }
        }
	}
}
