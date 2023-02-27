using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles
{
	public class 时空限制网 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("时空限制网");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 2;
			Projectile.timeLeft = 120;
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.alpha = 0;
		}

		public override void AI()
		{
			NPC npc = Main.npc[(int)Projectile.ai[0]];
			if (Projectile.localAI[0] == 0f)
			{
				if (npc.type == Mod.Find<ModNPC>("监测之眼").Type && npc.ai[1] == 2f && Main.expertMode)
				{
					CooldownSlot = 1;
				}
			}
			Projectile.Center = npc.Center;
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] > 120f)
			{
				Projectile.alpha = (int)((int)Projectile.localAI[0] + 100f);
				Projectile.damage = 0;
			}
			if (Projectile.localAI[0] > 120f)
			{
				Projectile.Kill();
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Projectile.localAI[0] > 200f)
			{
            player.lastDeathPostion = player.Center;
            player.lastDeathTime = DateTime.Now;
            player.showLastDeath = true;
            if (Main.myPlayer == player.whoAmI)
            {
                player.lostCoinString = Main.ValueToCoins(player.lostCoins);
            }
            SoundEngine.PlaySound(SoundID.PlayerKilled, player.position);
            player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            if (player.stoned)
            {
                player.headPosition = Vector2.Zero;
                player.bodyPosition = Vector2.Zero;
                player.legPosition = Vector2.Zero;
            }
            for (int j = 0; j < 100; j++)
            {
                Dust.NewDust(player.position, player.width, player.height, 235, 0f, -2f, 0, default(Color), 1f);
            }
            player.statLife = 0;
            player.dead = true;
            player.respawnTimer = 600;
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            player.handon = -1;
            player.handoff = -1;
            player.back = -1;
            player.front = -1;
            player.shoe = -1;
            player.waist = -1;
            player.shield = -1;
            player.neck = -1;
            player.face = -1;
            player.balloon = -1;
            player.mount.Dismount(player);
            if (Main.expertMode)
            {
               player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
            }
            player.immuneAlpha = 0;
            player.palladiumRegen = false;
            player.iceBarrier = false;
            player.crystalLeaf = false;
            PlayerDeathReason playerDeathReason = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
            NetworkText deathText = playerDeathReason.GetDeathText(player.name);
            if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
            {
                player.DropCoins();
            }
            else if (player.difficulty == 1)
            {
                player.DropItems();
            }
            else if (player.difficulty == 2)
            {
                player.DropItems();
                player.KillMeForGood();
            }
			}
		}
		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float point = 0f;
			Vector2 endPoint = Main.npc[(int)Projectile.ai[1]].Center;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, endPoint, 4f, ref point);
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Vector2 endPoint = Main.npc[(int)Projectile.ai[1]].Center;
			Vector2 unit = endPoint - Projectile.Center;
			float length = unit.Length();
			unit.Normalize();
			if(Math.Abs(length) < 500)
			{
			    for (float k = 0; k <= length; k += 1f)
			    {
			    	Vector2 drawPos = Projectile.Center + unit * k - Main.screenPosition;
			    	spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, Color.White, (float)Math.Atan2(unit.X, unit.Y), new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
		    	}
			}
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
	}
}