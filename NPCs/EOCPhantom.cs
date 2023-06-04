using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs
{
	    // Token: 0x02000413 RID: 1043
        [AutoloadBossHead]
	// Token: 0x02000487 RID: 1159
    public class EOCPhantom : ModNPC
	{
		
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("克苏鲁之眼幻影");
			Main.npcFrameCount[base.NPC.type] = 2;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之眼幻影");
		}
        private bool A2 = true;
		private int num4;	
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.NPC.damage = 27;
			base.NPC.width = 150;
			base.NPC.height = 150;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 300;
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 60;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void AI()
        {
			Player player = Main.player[base.NPC.target];
			Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
			float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if (A2 == true)
            {
                base.NPC.localAI[0] = -1;
                A2 = false;
				num4 = Main.rand.Next(-10,10);
            }
            base.NPC.localAI[0] += 1;
            Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            float num400 = player.Center.X - vector1.X;
            float num401 = player.Center.Y - vector1.Y;
			if (base.NPC.timeLeft > 150)
            {
                base.NPC.timeLeft = 150;
            }
            if (Math.Sqrt(base.NPC.velocity.X * base.NPC.velocity.X + base.NPC.velocity.Y * base.NPC.velocity.Y) < 50f)
            {
                base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            else
            {
                base.NPC.rotation = (float) - (Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y));
            }
			if (base.NPC.localAI[0] >= 0 && base.NPC.localAI[0] % (50 + num4) == 0)
            {
			    Vector2 Speed =  new Vector2(base.NPC.Center.X - player.Center.X, base.NPC.Center.Y - player.Center.Y) / num3 * (16 + num3 / 50);
				Vector2 Speed2 = new Vector2(Main.rand.Next(-200,200) / 100f ,Main.rand.Next(-200,200) / 100f);
                base.NPC.velocity = -Speed + Speed2;
			}  
			if (base.NPC.localAI[0] >= 0)
            {
			    base.NPC.velocity *= 0.98f;
			} 
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 5, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
			if (base.NPC.life <= 0)
			{
				for (int j = 0; j < 20; j++)
				{
					Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 5, (float)hitDirection, -1f, 0, default(Color), 1f);
				}
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                for (int j = 0; j < 40; j++)
                {
                    int num = Dust.NewDust(new Vector2(base.NPC.position.X, base.NPC.position.Y), base.NPC.width, base.NPC.height, 5, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num].scale = 0.5f;
                        Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int k = 0; k < 70; k++)
                {
                    int num2 = Dust.NewDust(new Vector2(base.NPC.position.X, base.NPC.position.Y), base.NPC.width, base.NPC.height, 5, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num2].noGravity = true;
                    Main.dust[num2].velocity *= 5f;
                    num2 = Dust.NewDust(new Vector2(base.NPC.position.X, base.NPC.position.Y), base.NPC.width, base.NPC.height, 5, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num2].velocity *= 2f;
                }
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/克苏鲁碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/克苏鲁碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/克苏鲁碎块3"), 1f);
			}
                
		}
		// Token: 0x0600180C RID: 6156 RVA: 0x0010AEF8 File Offset: 0x001090F8
		public override void OnKill()
		{
			Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, 72, Main.rand.Next(2, 4), false, 0, false, false);
		}
	}
}
