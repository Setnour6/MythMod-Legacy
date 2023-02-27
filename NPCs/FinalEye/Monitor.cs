using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.FinalEye
{
	// Token: 0x020004FC RID: 1276
        [AutoloadBossHead]
		
    public class Monitor : ModNPC
	{
		// Token: 0x06001BA4 RID: 7076 RVA: 0x0000B6E0 File Offset: 0x000098E0
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Eye");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "监测之眼");
			Main.npcFrameCount[base.NPC.type] = 1;
		}
        private bool canDespawn;
		private const int sphereRadius = 300;

		// Token: 0x06001BA5 RID: 7077 RVA: 0x001539E4 File Offset: 0x00151BE4
		internal int laser1 = -1;
		internal int laser2 = -1;
		internal int laserTimer = 0;
		private int moveTime = 300;
		private int moveTimer = 60;
		private int AI1 = 0;
		private float num3;
		public override void SetDefaults()
		{
			base.NPC.damage = 4000;
			base.NPC.width = 30;
			base.NPC.height = 30;
			base.NPC.defense = 0;
            base.NPC.lifeMax = 1;
			base.NPC.aiStyle = 94;
			this.AIType = -1;
			base.NPC.knockBackResist = 0f;
			base.NPC.alpha = 0;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.dontTakeDamage = true;
		}
		// Token: 0x06001BA6 RID: 7078 RVA: 0x00153AEC File Offset: 0x00151CEC
		public override void FindFrame(int frameHeight)
		{
			base.NPC.frameCounter += 0.15000000596046448;
			base.NPC.frameCounter %= (double)Main.npcFrameCount[base.NPC.type];
			int num = (int)base.NPC.frameCounter;
			base.NPC.frame.Y = num * frameHeight;
		}
		public override void AI()
		{
			if(NPC.CountNPCS(Mod.Find<ModNPC>("终天灭世眼").Type) < 1)
			{
				NPC.active = false;
			}
			canDespawn = false;
			Player player = Main.player[base.NPC.target];
			Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if(num3 < 400)
			{
				if(AI1 <= 99)
				{
                    AI1 += 2;
				}
				else
				{
					AI1 = 100;
				}
				Vector2 Speed =  new Vector2(base.NPC.Center.X - player.Center.X, base.NPC.Center.Y - player.Center.Y) / num3 * 6;
                int num35 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed.X * (int)AI1 / 100f, -Speed.Y * (int)AI1 / 100f, base.Mod.Find<ModProjectile>("灭世火光").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[num35].scale = (int)AI1 / 100f;
				Main.projectile[num35].timeLeft = (int)((int)AI1 / 1.25f + 20);
			}
			else
			{
                if(AI1 >= 1)
				{
                    AI1 -= 1;
					Vector2 Speed =  new Vector2(base.NPC.Center.X - player.Center.X, base.NPC.Center.Y - player.Center.Y) / num3 * 6;
                    int num35 = Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, -Speed.X * (int)AI1 / 100f, -Speed.Y * (int)AI1 / 100f, base.Mod.Find<ModProjectile>("灭世火光").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
				    Main.projectile[num35].scale = (int)AI1 / 100f;
				}
				else
				{
					AI1 = 0;
				}
			}
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/终天灭世眼/监测之眼Glow").Width, (float)(base.Mod.GetTexture("NPCs/终天灭世眼/监测之眼Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
			if (num3 > 750)
            {
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/终天灭世眼/监测之眼Glow"), vector2, new Rectangle?(base.NPC.frame), color * (500 / (num3 + 0.0001f)), base.NPC.rotation, vector, 1f, effects, 0f);
			}
			else
			{
                Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/终天灭世眼/监测之眼Glow"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
			}
		}
		public override bool CheckActive()
		{
			return this.canDespawn;
		}
	}
}
