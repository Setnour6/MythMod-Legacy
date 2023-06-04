using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.FinalEye
{
	// Token: 0x02000420 RID: 1056
    public class TerraStone : ModNPC
	{
		// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "大地封印石");
		}
		private bool canDespawn;
		private float M = 0.2f;
		public override void SetDefaults()
		{
			base.NPC.knockBackResist = 0f;
			base.NPC.noGravity = true;
			base.NPC.damage = 60;
			base.NPC.width = 36;
			base.NPC.height = 30;
			base.NPC.defense = 5;			
			base.NPC.lifeMax = 2000000;
			base.NPC.HitSound = SoundID.NPCHit2;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x000B3A6C File Offset: 0x000B1C6C
		public override void AI()
		{
			canDespawn = false;
			base.NPC.localAI[0] += 1;
	    	Player player = Main.player[base.NPC.target];
			if(base.NPC.localAI[0] >= 1260f && base.NPC.localAI[0] <= 1560f && base.NPC.localAI[0] % 2 == 0 && M < 1f)
	    	{
				M += 0.02f;
			}
			if(base.NPC.localAI[0] >= 1920f && base.NPC.localAI[0] <= 2240f && base.NPC.localAI[0] % 2 == 0 && M > 0.05f)
	    	{
				M -= 0.04f;
			}
			if(base.NPC.localAI[0] >= 1440f && base.NPC.localAI[0] <= 1920f && base.NPC.localAI[0] % 90 == 0)
	    	{
	    	        float num = player.position.X - base.NPC.Center.X;
                    float num2 = player.position.Y - base.NPC.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	    	        Vector2 Speed4 = new Vector2(base.NPC.Center.X - player.position.X, base.NPC.Center.Y - player.position.Y - 100) / num3 * 25f;
		            int num34 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y - 40, -Speed4.X, -Speed4.Y, base.Mod.Find<ModProjectile>("巨石").Type, 1500, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 180;
	    	}
			if(base.NPC.localAI[0] >= 1400f && base.NPC.localAI[0] <= 1920f)
	    	{
				Vector2 V = new Vector2(Main.rand.Next(-10000,10000) / 50f, Main.rand.Next(-10000,10000) / 50f);
				Vector2 V2 = V.RotatedBy(Main.rand.Next(-10000,10000) / 5000f * Math.PI);
                int ID = Dust.NewDust(new Vector2(base.NPC.Center.X, base.NPC.Center.Y) + V2, 0, 0, 0, 0, 0, 0, default(Color), 0.3f);/*粉尘效果不用管*/
		    	Main.dust[ID].noGravity = true;
				Dust dust = Main.dust[ID];
				Main.dust[ID].velocity = (new Vector2(base.NPC.Center.X,base.NPC.Center.Y - 40) - dust.position) * 0.05f;
				if (Math.Sqrt(dust.velocity.X * dust.velocity.X + dust.velocity.Y * dust.velocity.Y) <= 0.1f)
			    {
				    dust.active = false;
			    }
				else
				{
					Main.dust[ID].scale += 0.5f;
					Main.dust[ID].scale *= 1.2f;
				}
				V = new Vector2(Main.rand.Next(-10000,10000) / 50f, Main.rand.Next(-10000,10000) / 50f);
				V2 = V.RotatedBy(Main.rand.Next(-10000,10000) / 5000f * Math.PI);
                int ID2 = Dust.NewDust(new Vector2(base.NPC.Center.X, base.NPC.Center.Y) + V2, 0, 0, 0, 0, 0, 0, default(Color), 0.3f);/*粉尘效果不用管*/
		    	Main.dust[ID2].noGravity = true;
				Dust dust2 = Main.dust[ID2];
				Main.dust[ID2].velocity = (new Vector2(base.NPC.Center.X,base.NPC.Center.Y - 40) - dust2.position) * 0.05f;
				Main.dust[ID2].scale += 2f;
				if (Math.Sqrt(dust2.velocity.X * dust2.velocity.X + dust2.velocity.Y * dust2.velocity.Y) <= 0.1f)
			    {
				    dust2.active = false;
			    }
				else
				{
					Main.dust[ID2].scale += 0.5f;
					Main.dust[ID2].scale *= 1.2f;
				}
	    	}
			if(base.NPC.localAI[0] >= 3360)
			{
				base.NPC.localAI[0] = 0;
			}
			base.NPC.velocity.Y = (float)Math.Sin((float)base.NPC.localAI[0] / 105f * Math.PI);
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x000A9970 File Offset: 0x000A7B70
		public override void FindFrame(int frameHeight)
		{
		}
		// Token: 0x0600147B RID: 5243 RVA: 0x000A99DC File Offset: 0x000A7BDC
		public override void HitEffect(NPC.HitInfo hit)
		{
		}
        // Token: 0x02000413 RID: 1043
        public override void OnKill()
        {
        }
		public override bool CheckActive()
		{
			return this.canDespawn;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/终天灭世眼/大地封印石_Glow").Width, (float)(base.Mod.GetTexture("NPCs/终天灭世眼/大地封印石_Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/终天灭世眼/大地封印石_Glow"), vector2, new Rectangle?(base.NPC.frame), color * M, base.NPC.rotation, vector, 1f, effects, 0f);
		}
	}
}
