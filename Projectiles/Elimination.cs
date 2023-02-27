using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class Elimination : ModProjectile
	{
		private float num4;
		private bool num5 = true;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("代码杀射线");
		}
		public override void SetDefaults()
		{
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 10;
			base.projectile.timeLeft = 24;
			base.projectile.alpha = 0;
			base.projectile.tileCollide = false;
		}
		public override void AI()
		{
			if (base.projectile.localAI[1] >= 21f && base.projectile.owner == Main.myPlayer)
			{
				base.projectile.localAI[1] = 0f;
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.X * 0.35f, base.projectile.velocity.Y * 0.35f, base.mod.ProjectileType("TerraOrb"), (int)((double)base.projectile.damage * 0.699999988079071), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
			}
			if(num6)
			{
				num6 = false;
				vector3 = base.projectile.Center;
			}
            for(int i = 0;i < 200;i++)
            {
                if ((Main.npc[i].Center - projectile.Center).Length() < 100)
                {
                    if (Main.npc[i].type == NPCID.TargetDummy)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (Main.tile[(int)(Main.npc[i].position.X / 16f) + k, (int)(Main.npc[i].position.Y / 16f) + j].type == 378)
                                {
                                    WorldGen.KillTile((int)(Main.npc[i].position.X / 16f) + k, (int)(Main.npc[i].position.Y / 16f) + j, false, false, true);
                                }
                            }
                        }
                    }
                    if(Main.npc[i].active)
                    {
                        Main.npc[i].lifeMax = 1;
                        Main.npc[i].life = 1;
                        Main.npc[i].NPCLoot();
                        Main.npc[i].active = false;
                        Projectile.NewProjectile((float)Main.npc[i].Center.X, (float)Main.npc[i].Center.Y, 0, 0, mod.ProjectileType("Infinite"), 0, 0, Main.myPlayer, 0f, 0f);
                    }
                    Main.npc[i].noGravity = false;
                    Main.npc[i].noTileCollide = false;
                    Main.npc[i].damage = 0;
                    Main.npc[i].AddBuff(mod.BuffType("Ban"), 210000000, false);
                    Main.npc[i].lifeMax = 0;
                    Main.npc[i].life = 0;

                    if (Main.npc[i].active)
                    {
                        Main.npc[i].NPCLoot();
                    }
                }
            }
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.lifeMax = 1;
            target.life = 1;
            target.NPCLoot();
            target.lifeMax = 0;
            target.life = 0;
            target.active = false;
            target.life = 0;			
            for (int i = 0; i < 45; i++)
            {
                int num2 = Dust.NewDust(target.Center, base.projectile.width, base.projectile.height, 182, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7, 150, default(Color), 2.5f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity.X = (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2;
                Main.dust[num2].velocity.Y = (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7;
                int num3 = Dust.NewDust(target.Center, base.projectile.width, base.projectile.height, 182, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 2, 150, default(Color), 2.5f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity.X = (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7;
                Main.dust[num3].velocity.Y = (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 2;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100 * projectile.timeLeft / 24f + 155, 100 * projectile.timeLeft / 24f + 155, 100 * projectile.timeLeft / 24f + 155, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float maxDistance = 1000f;
            float step = 9f * (projectile.timeLeft + 4) / 24f;
            Vector2 unit = projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation() - 1.57f;
            for (float i = 66; i < maxDistance; i += step)
            {
				Texture2D texture;
				if(i == 66)
				{
					texture = base.mod.GetTexture("Projectiles/代码杀射线发射端");
				}
				else
				{
					texture = Main.projectileTexture[projectile.type];
				}
				float[] samples = new float[2];
                Collision.LaserScan(vector3, unit, 3f, 1200f, samples);
                float maxDis = (samples[0] + samples[1]) * 0.5f;
                maxDistance = maxDis;
				Distance = maxDis;
                
                if (i == 66 && num5)
				{
					num5 = false;
					num4 = maxDistance - 15;
				}
				if(i > 78)
				{
					spriteBatch.Draw(texture, vector3 + unit * (i + 0.04f) - Main.screenPosition, null,  base.projectile.GetAlpha(lightColor), r, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f * (projectile.timeLeft + 4) / 24f, SpriteEffects.None, 0f);
				}
				if(i == 66)
				{
					spriteBatch.Draw(texture, vector3 + unit * (i + (24 - base.projectile.timeLeft) / 1.85f) - Main.screenPosition, null,  base.projectile.GetAlpha(lightColor), r, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f * (projectile.timeLeft + 2) / 24f, SpriteEffects.None, 0f);
					spriteBatch.Draw(base.mod.GetTexture("Projectiles/代码杀射线发射端"), vector3 + unit * (num4 + (24 - base.projectile.timeLeft) / 2f) - Main.screenPosition, null,  base.projectile.GetAlpha(lightColor), r, Main.projectileTexture[projectile.type].Size() * 0.5f, 1f * (projectile.timeLeft + 10) / 40f, SpriteEffects.None, 0f);
				}
            }
			return false;
        }
		public override void CutTiles()
        {
            Vector2 unit = projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance, (projectile.width + 16) * projectile.scale,  new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[projectile.owner];
            Vector2 unit = projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * Distance, 14, ref point);
        }
	}
}
