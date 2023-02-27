using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 荧光虾酱 : ModProjectile
	{
		private int num = 480;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("荧光虾酱");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 28;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 480;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			num -= 1;
			base.projectile.spriteDirection = 1;
			base.projectile.rotation += (float)0.2 + (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) / 40f;
			base.projectile.velocity.Y += 0.15f;
			if(base.projectile.timeLeft == 479)
			{
				float num1 = (float)Main.rand.Next(-2000,2000) / 1000f;
		    	Gore.NewGore(base.projectile.position, new Vector2(num1, 0), base.mod.GetGoreSlot("Gores/荧光虾酱瓶塞"), 1f);
			}
			if(Main.rand.Next(20) != 5)
			{
				int num3 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 183, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 183, Color.White, 1.2f);
			}
			else
			{
				int num3 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 174, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 174, Color.White, 0.9f);
			}
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
			if(num > 2)
			{
				float num2 = (float)Main.rand.Next(-2000,2000) / 1000f;
				float num3 = (float)Main.rand.Next(-2000,2000) / 1000f;
				Gore.NewGore(base.projectile.position, new Vector2(num2, num3), base.mod.GetGoreSlot("Gores/荧光虾酱1"), 1f);
                Gore.NewGore(base.projectile.position, new Vector2(num2, num3), base.mod.GetGoreSlot("Gores/荧光虾酱2"), 1f);
                Gore.NewGore(base.projectile.position, new Vector2(num2, num3), base.mod.GetGoreSlot("Gores/荧光虾酱3"), 1f);
                Gore.NewGore(base.projectile.position, new Vector2(num2, num3), base.mod.GetGoreSlot("Gores/荧光虾酱1"), 1f);
				Gore.NewGore(base.projectile.position, new Vector2(num2, num3), base.mod.GetGoreSlot("Gores/荧光虾酱2"), 1f);
				for(int i = 0;i < 50;i++)
				{
					if(Main.rand.Next(20) != 5)
	     	    	{
			        	int num4 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 183, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 183, Color.White, 1.2f);
		          	}
		        	else
			        {
			        	int num4 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 174, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 174, Color.White, 0.9f);
		        	}
				}
			}
			Player player = Main.player[Main.myPlayer];
			if(base.projectile.wet && NPC.CountNPCS(base.mod.NPCType("StarJellyfish")) < 1 && player.position.Y < (float)(Main.maxTilesY * 0.7 * 16))
			{
				int num21 = NPC.NewNPC((int)base.projectile.position.X, (int)base.projectile.position.Y, base.mod.NPCType("StarJellyfish"), 0, 0f, 0f, 0f, 0f, 255);
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			return true;
		}
	}
}
