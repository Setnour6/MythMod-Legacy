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
	// Token: 0x02000487 RID: 1159
    public class EOCShadow : ModNPC
	{
		
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之眼残影");
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之眼残影");
		}
        private bool A2 = true;
		private int num4;	
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.npc.damage = 30;
            base.npc.dontTakeDamage = true;
            base.npc.width = 150;
			base.npc.height = 150;
			base.npc.defense = 0;
			base.npc.lifeMax = 300;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 2, 0, 0);
			base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 60;
			base.npc.lavaImmune = false;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
		}

		// Token: 0x0600180B RID: 6155 RVA: 0x0010AE44 File Offset: 0x00109044
		public override void AI()
        {
			Player player = Main.player[base.npc.target];
			Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
			float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			if (A2 == true)
            {
                base.npc.localAI[0] = -1;
                A2 = false;
            }
            base.npc.localAI[0] += 1;
            Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            float num400 = player.Center.X - vector1.X;
            float num401 = player.Center.Y - vector1.Y;
			if (base.npc.timeLeft > 150)
            {
                base.npc.timeLeft = 150;
            }
            if (Math.Sqrt(base.npc.velocity.X * base.npc.velocity.X + base.npc.velocity.Y * base.npc.velocity.Y) < 50f)
            {
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            else
            {
                base.npc.rotation = (float) - (Math.Atan2((double)base.npc.velocity.X, (double)base.npc.velocity.Y));
            }
			if (base.npc.localAI[0] == 0)
            {
			    Vector2 Speed =  new Vector2(base.npc.Center.X - player.Center.X, base.npc.Center.Y - player.Center.Y) / num3 * (16 + num3 / 50);
				Vector2 Speed2 = new Vector2(Main.rand.Next(-200,200) / 100f ,Main.rand.Next(-200,200) / 100f);
                base.npc.velocity = -Speed * 2f + Speed2;
			}  
			if (base.npc.localAI[0] >= 0)
            {
			    base.npc.velocity *= 0.98f;
			}
            if (base.npc.localAI[0] >= 50)
            {
                npc.alpha += 15;
            }
            if(base.npc.localAI[0] >= 70)
            {
                npc.active = false;
            }
        }
	}
}
