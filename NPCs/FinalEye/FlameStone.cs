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
    public class FlameStone : ModNPC
	{
		// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "烈焰封印石");
		}
		private bool canDespawn;
		private float M = 0.04f;
		public override void SetDefaults()
		{
			base.NPC.knockBackResist = 0f;
			base.NPC.noGravity = true;
			base.NPC.damage = 60;
			base.NPC.width = 28;
			base.NPC.height = 44;
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
			if(base.NPC.localAI[0] >= 300f && base.NPC.localAI[0] <= 600f && base.NPC.localAI[0] % 2 == 0 && M < 1f)
	    	{
				M += 0.02f;
			}
			if(base.NPC.localAI[0] >= 960f && base.NPC.localAI[0] <= 1280f && base.NPC.localAI[0] % 2 == 0 && M > 0.05f)
	    	{
				M -= 0.04f;
			}
	    	if(base.NPC.localAI[0] >= 480f && base.NPC.localAI[0] <= 960f && base.NPC.localAI[0] % 60 == 0)
	    	{
                int num4 = Main.rand.Next(0,100);
				if(num4 <= 60)
				{
	    	        float num = player.position.X - base.NPC.Center.X;
                    float num2 = player.position.Y - base.NPC.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	    	        Vector2 Speed4 = new Vector2(base.NPC.Center.X - player.position.X, base.NPC.Center.Y - player.position.Y) / num3 * 14f;
					Vector2 Speed5 = Speed4.RotatedBy(Math.PI * Main.rand.Next(-100,100) / 750f) * (1 + Main.rand.Next(-50,50) / 150f);
		            int num34 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed4.X, -Speed4.Y, base.Mod.Find<ModProjectile>("小火球").Type, 555, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 300;
					int num35 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed5.X, -Speed5.Y, base.Mod.Find<ModProjectile>("小火球").Type, 555, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].timeLeft = 300;
					Vector2 Speed6 = Speed4.RotatedBy(Math.PI * Main.rand.Next(-100,100) / 750f) * (1 + Main.rand.Next(-50,50) / 150f);
					int num36 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed6.X, -Speed6.Y, base.Mod.Find<ModProjectile>("小火球").Type, 555, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num36].timeLeft = 300;
					Vector2 Speed7 = Speed4.RotatedBy(Math.PI * Main.rand.Next(-100,100) / 750f) * (1 + Main.rand.Next(-50,50) / 150f);
					int num37 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed7.X, -Speed7.Y, base.Mod.Find<ModProjectile>("小火球").Type, 555, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num37].timeLeft = 300;
				}
				if(num4 > 60 && num4 <= 90)
				{
	    	        float num = player.position.X - base.NPC.Center.X;
                    float num2 = player.position.Y - base.NPC.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	    	        Vector2 Speed4 = new Vector2(base.NPC.Center.X - player.position.X, base.NPC.Center.Y - player.position.Y) / num3 * 15f;
		            int num34 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed4.X, -Speed4.Y, base.Mod.Find<ModProjectile>("大火球").Type, 777, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 300;
				}
				if(num4 > 90 && num4 <= 100)
				{
	    	        float num = player.position.X - base.NPC.Center.X;
                    float num2 = player.position.Y - base.NPC.Center.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
	    	        Vector2 Speed4 = new Vector2(base.NPC.Center.X - player.position.X, base.NPC.Center.Y - player.position.Y) / num3 * 12f;
		            int num34 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed4.X, -Speed4.Y, base.Mod.Find<ModProjectile>("爆炸火球").Type, 888, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 50;
				}
	    	}
			if(base.NPC.localAI[0] >= 3360)
			{
				base.NPC.localAI[0] = 0;
			}
			base.NPC.velocity.Y = (float)Math.Sin((float)base.NPC.localAI[0] / 105f * Math.PI);
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/终天灭世眼/烈焰封印石_Glow").Width, (float)(base.Mod.GetTexture("NPCs/终天灭世眼/烈焰封印石_Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/终天灭世眼/烈焰封印石_Glow"), vector2, new Rectangle?(base.NPC.frame), color * (float)M, base.NPC.rotation, vector, 1f, effects, 0f);
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
        public override void OnKill()
        {
        }
	}
}
