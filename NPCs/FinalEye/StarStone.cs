using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.FinalEye
{
	// Token: 0x02000420 RID: 1056
    public class StarStone : ModNPC
	{
		// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星辰封印石");
		}
		private bool canDespawn;
		private float M = 0.04f;
		public override void SetDefaults()
		{
			base.npc.knockBackResist = 0f;
			base.npc.noGravity = true;
			base.npc.damage = 60;
			base.npc.width = 38;
			base.npc.height = 32;
			base.npc.defense = 5;			
			base.npc.lifeMax = 2000000;
			base.npc.HitSound = SoundID.NPCHit2;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x000B3A6C File Offset: 0x000B1C6C
		public override void AI()
		{
			canDespawn = false;
			base.npc.localAI[0] += 1;
	    	Player player = Main.player[base.npc.target];
			if(base.npc.localAI[0] >= 1740f && base.npc.localAI[0] <= 2040f && base.npc.localAI[0] % 2 == 0 && M < 1f)
	    	{
				M += 0.02f;
			}
			if(base.npc.localAI[0] >= 2400f && base.npc.localAI[0] <= 2720f && base.npc.localAI[0] % 2 == 0 && M > 0.05f)
	    	{
				M -= 0.04f;
			}
	    	if(base.npc.localAI[0] >= 1920f && base.npc.localAI[0] <= 2400f && base.npc.localAI[0] % 60 == 0)
	    	{
                int num4 = Main.rand.Next(0,100);
				if(num4 <= 60)
				{
	    	        float num = player.position.X - base.npc.Center.X;
                    float num2 = player.position.Y - base.npc.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
					for (int a = 0 ; a < 6 ; a++)
					{
	    	            Vector2 Speed4 = new Vector2(base.npc.Center.X - player.position.X, base.npc.Center.Y - player.position.Y) / num3 * 14f;
						Vector2 Speed3 = Speed4.RotatedBy((3 - (float)a) / 15 * Math.PI);
		                int num34 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, -Speed3.X, -Speed3.Y, base.mod.ProjectileType("星光"), 555, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 600;
					}
				}
				if(num4 > 60 && num4 <= 90)
				{
					for (int a = 0 ; a < 10 ; a++)
					{
					    Vector2 Speed4 = new Vector2(Main.rand.Next(0, 1000), Main.rand.Next(0, 1000));
						Vector2 Speed3 = Speed4.RotatedBy(Main.rand.Next(-10000, 10000) / 10000f * Math.PI);
		                int num34 = Projectile.NewProjectile(base.npc.Center.X - Speed3.X, base.npc.Center.Y - Speed3.Y, 0, 0, base.mod.ProjectileType("爆炸星星"), 0, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].scale = 0;
						Main.projectile[num34].timeLeft = Main.rand.Next(50, 120);
					}
				}
				if(num4 > 90 && num4 <= 100)
				{
	    	        float num = player.position.X - base.npc.Center.X;
                    float num2 = player.position.Y - base.npc.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	    	        Vector2 Speed4 = new Vector2(base.npc.Center.X - player.position.X, base.npc.Center.Y - player.position.Y) / num3 * 12f;
		            int num34 = Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, -Speed4.X, -Speed4.Y, base.mod.ProjectileType("连线星星"), 888, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 601;
				}
	    	}
			if(base.npc.localAI[0] >= 3360)
			{
				base.npc.localAI[0] = 0;
			}
			base.npc.velocity.Y = (float)Math.Sin((float)base.npc.localAI[0] / 105f * Math.PI);
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/终天灭世眼/星辰封印石_Glow").Width, (float)(base.mod.GetTexture("NPCs/终天灭世眼/星辰封印石_Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/终天灭世眼/星辰封印石_Glow"), vector2, new Rectangle?(base.npc.frame), color * (float)M, base.npc.rotation, vector, 1f, effects, 0f);
		}
		public override bool CheckActive()
		{
			return this.canDespawn;
		}
		// Token: 0x06001478 RID: 5240 RVA: 0x000A9970 File Offset: 0x000A7B70
		public override void FindFrame(int frameHeight)
		{
		}
		// Token: 0x0600147B RID: 5243 RVA: 0x000A99DC File Offset: 0x000A7BDC
		public override void HitEffect(int hitDirection, double damage)
		{
		}
        // Token: 0x02000413 RID: 1043
        public override void NPCLoot()
        {
        }
	}
}
