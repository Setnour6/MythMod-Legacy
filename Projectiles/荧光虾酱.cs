using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 荧光虾酱 : ModProjectile
	{
		private int num = 480;
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("荧光虾酱");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 28;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 480;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			num -= 1;
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation += (float)0.2 + (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) / 40f;
			base.Projectile.velocity.Y += 0.15f;
			if(base.Projectile.timeLeft == 479)
			{
				float num1 = (float)Main.rand.Next(-2000,2000) / 1000f;
		    	Gore.NewGore(base.Projectile.position, new Vector2(num1, 0), base.Mod.GetGoreSlot("Gores/荧光虾酱瓶塞"), 1f);
			}
			if(Main.rand.Next(20) != 5)
			{
				int num3 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 183, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 183, Color.White, 1.2f);
			}
			else
			{
				int num3 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 174, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 174, Color.White, 0.9f);
			}
		}
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			if(num > 2)
			{
				float num2 = (float)Main.rand.Next(-2000,2000) / 1000f;
				float num3 = (float)Main.rand.Next(-2000,2000) / 1000f;
				Gore.NewGore(base.Projectile.position, new Vector2(num2, num3), base.Mod.GetGoreSlot("Gores/荧光虾酱1"), 1f);
                Gore.NewGore(base.Projectile.position, new Vector2(num2, num3), base.Mod.GetGoreSlot("Gores/荧光虾酱2"), 1f);
                Gore.NewGore(base.Projectile.position, new Vector2(num2, num3), base.Mod.GetGoreSlot("Gores/荧光虾酱3"), 1f);
                Gore.NewGore(base.Projectile.position, new Vector2(num2, num3), base.Mod.GetGoreSlot("Gores/荧光虾酱1"), 1f);
				Gore.NewGore(base.Projectile.position, new Vector2(num2, num3), base.Mod.GetGoreSlot("Gores/荧光虾酱2"), 1f);
				for(int i = 0;i < 50;i++)
				{
					if(Main.rand.Next(20) != 5)
	     	    	{
			        	int num4 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 183, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 183, Color.White, 1.2f);
		          	}
		        	else
			        {
			        	int num4 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 174, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 174, Color.White, 0.9f);
		        	}
				}
			}
			Player player = Main.player[Main.myPlayer];
			if(base.Projectile.wet && NPC.CountNPCS(base.Mod.Find<ModNPC>("StarJellyfish").Type) < 1 && player.position.Y < (float)(Main.maxTilesY * 0.7 * 16))
			{
				int num21 = NPC.NewNPC((int)base.Projectile.position.X, (int)base.Projectile.position.Y, base.Mod.Find<ModNPC>("StarJellyfish").Type, 0, 0f, 0f, 0f, 0f, 255);
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			return true;
		}
	}
}
