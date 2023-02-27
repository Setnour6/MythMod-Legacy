using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class AncientFire : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.SetDefault("远古烈火灵");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "远古烈火灵");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 120;
			base.NPC.width = 54;
			base.NPC.height = 52;
			base.NPC.defense = 120;
			base.NPC.lifeMax = 30000;
			base.NPC.knockBackResist = 0;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
            base.NPC.aiStyle = -1;
            NPC.dontTakeDamage = true;
            NPC.boss = false;
        }
        private int Xa = 0;
        public override void FindFrame(int frameHeight)
        {
            base.NPC.frameCounter += 0.15;
            base.NPC.frameCounter %= (double)Main.npcFrameCount[base.NPC.type];
            int num = (int)base.NPC.frameCounter;
            base.NPC.frame.Y = num * frameHeight;
        }
        public override void AI()
        {
            Xa += 1;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            Vector2 playerposition = Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
            Vector2 vector = new Vector2(base.NPC.position.X + (float)base.NPC.width * 0.5f, base.NPC.position.Y + (float)base.NPC.height * 0.5f);
            Vector2 v3 = new Vector2(300, 0).RotatedBy(Xa / 200f);
            float num4 = player.Center.X + v3.X - vector.X;
            float num5 = player.Center.Y + v3.Y - vector.Y;
            float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
            NPC.velocity += new Vector2(num4, num5) / num6 * 0.04f * ((NPC.Center - player.Center - v3).Length() / 300 + 1);
            if (NPC.velocity.Length() < 4)
            {
                NPC.velocity *= 1.01f;
            }
            if (NPC.velocity.Length() > 10)
            {
                NPC.velocity *= 0.98f;
            }
            NPC.damage = 120;
            if (Xa < 1200 && Xa % 60 == 0)
            {
                for (int o = 0; o < 15; o++)
                {
                    Vector2 v = new Vector2(0, 8).RotatedBy(Math.PI * 2 / 15 * o);
                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, 467, 100, 0, Main.myPlayer, 10, 0f);
                }
            }
            if (Xa >= 1200 && Xa % 4 == 0 && Xa < 2400)
            {
                Vector2 v = new Vector2(0, 8).RotatedBy(Math.PI * 2 / 60 * Xa);
                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, 467, 100, 0, Main.myPlayer, 10, 0f);
            }
            if (Xa > 2400)
            {
                Xa = 1;
            }
            if(NPC.CountNPCS(439) == 0)
            {
                NPC.active = false;
            }
            Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 6, 0, 0, 0, default(Color), 1f);
        }
	}
}
