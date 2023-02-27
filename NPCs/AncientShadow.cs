using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class AncientShadow : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.SetDefault("远古暗影球");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "远古暗影球");
		}
		public override void SetDefaults()
		{
			base.npc.damage = 120;
			base.npc.width = 54;
			base.npc.height = 52;
			base.npc.defense = 120;
			base.npc.lifeMax = 30000;
			base.npc.knockBackResist = 0;
			base.npc.alpha = 0;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
            base.npc.aiStyle = -1;
            npc.dontTakeDamage = true;
            npc.boss = false;
        }
        private int Xa = 0;
        public override void FindFrame(int frameHeight)
        {
            base.npc.frameCounter += 0.15;
            base.npc.frameCounter %= (double)Main.npcFrameCount[base.npc.type];
            int num = (int)base.npc.frameCounter;
            base.npc.frame.Y = num * frameHeight;
        }
        public override void AI()
        {
            Xa += 1;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            Vector2 playerposition = Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
            Vector2 vector = new Vector2(base.npc.position.X + (float)base.npc.width * 0.5f, base.npc.position.Y + (float)base.npc.height * 0.5f);
            Vector2 v3 = new Vector2(300, 0).RotatedBy(Xa / 200f);
            float num4 = player.Center.X + v3.X - vector.X;
            float num5 = player.Center.Y + v3.Y - vector.Y;
            float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
            npc.velocity += new Vector2(num4, num5) / num6 * 0.04f * ((npc.Center - player.Center - v3).Length() / 300 + 1);
            if (npc.velocity.Length() < 4)
            {
                npc.velocity *= 1.01f;
            }
            if (npc.velocity.Length() > 10)
            {
                npc.velocity *= 0.98f;
            }
            npc.damage = 120;
            if (Xa % 15 == 0)
            {
                for (int o = 0; o < 4; o++)
                {
                    Vector2 v = new Vector2(0, 3.2f).RotatedBy(Math.PI * 2 / 4 * o);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, 468, 100, 0, Main.myPlayer, 10, 0f);
                }
            }
            if (Xa > 2400)
            {
                Xa = 1;
            }
            if(NPC.CountNPCS(439) == 0)
            {
                npc.active = false;
            }
            Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 27, 0, 0, 0, default(Color), 1f);
        }
	}
}
