using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("代码杀射线");
		}
		public override void SetDefaults()
		{
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = 10;
			base.Projectile.timeLeft = 24;
			base.Projectile.alpha = 0;
			base.Projectile.tileCollide = false;
		}
		public override void AI()
		{
			if (base.Projectile.localAI[1] >= 21f && base.Projectile.owner == Main.myPlayer)
			{
				base.Projectile.localAI[1] = 0f;
				Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.X * 0.35f, base.Projectile.velocity.Y * 0.35f, base.Mod.Find<ModProjectile>("TerraOrb").Type, (int)((double)base.Projectile.damage * 0.699999988079071), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
			}
			if(num6)
			{
				num6 = false;
				vector3 = base.Projectile.Center;
			}
            for(int i = 0;i < 200;i++)
            {
                if ((Main.npc[i].Center - Projectile.Center).Length() < 100)
                {
                    if (Main.npc[i].type == NPCID.TargetDummy)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (Main.tile[(int)(Main.npc[i].position.X / 16f) + k, (int)(Main.npc[i].position.Y / 16f) + j].TileType == 378)
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
                        Projectile.NewProjectile((float)Main.npc[i].Center.X, (float)Main.npc[i].Center.Y, 0, 0, Mod.Find<ModProjectile>("Infinite").Type, 0, 0, Main.myPlayer, 0f, 0f);
                    }
                    Main.npc[i].noGravity = false;
                    Main.npc[i].noTileCollide = false;
                    Main.npc[i].damage = 0;
                    Main.npc[i].AddBuff(Mod.Find<ModBuff>("Ban").Type, 210000000, false);
                    Main.npc[i].lifeMax = 0;
                    Main.npc[i].life = 0;

                    if (Main.npc[i].active)
                    {
                        Main.npc[i].NPCLoot();
                    }
                }
            }
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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
                int num2 = Dust.NewDust(target.Center, base.Projectile.width, base.Projectile.height, 182, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7, 150, default(Color), 2.5f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity.X = (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2;
                Main.dust[num2].velocity.Y = (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7;
                int num3 = Dust.NewDust(target.Center, base.Projectile.width, base.Projectile.height, 182, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 2, 150, default(Color), 2.5f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity.X = (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 7;
                Main.dust[num3].velocity.Y = (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 2;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100 * Projectile.timeLeft / 24f + 155, 100 * Projectile.timeLeft / 24f + 155, 100 * Projectile.timeLeft / 24f + 155, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
        {
            float maxDistance = 1000f;
            float step = 9f * (Projectile.timeLeft + 4) / 24f;
            Vector2 unit = Projectile.velocity;
            unit.Normalize();
            float r = unit.ToRotation() - 1.57f;
            for (float i = 66; i < maxDistance; i += step)
            {
				Texture2D texture;
				if(i == 66)
				{
					texture = base.Mod.GetTexture("Projectiles/代码杀射线发射端");
				}
				else
				{
					texture = TextureAssets.Projectile[Projectile.type].Value;
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
					spriteBatch.Draw(texture, vector3 + unit * (i + 0.04f) - Main.screenPosition, null,  base.Projectile.GetAlpha(lightColor), r, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f * (Projectile.timeLeft + 4) / 24f, SpriteEffects.None, 0f);
				}
				if(i == 66)
				{
					spriteBatch.Draw(texture, vector3 + unit * (i + (24 - base.Projectile.timeLeft) / 1.85f) - Main.screenPosition, null,  base.Projectile.GetAlpha(lightColor), r, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f * (Projectile.timeLeft + 2) / 24f, SpriteEffects.None, 0f);
					spriteBatch.Draw(base.Mod.GetTexture("Projectiles/代码杀射线发射端"), vector3 + unit * (num4 + (24 - base.Projectile.timeLeft) / 2f) - Main.screenPosition, null,  base.Projectile.GetAlpha(lightColor), r, TextureAssets.Projectile[Projectile.type].Value.Size() * 0.5f, 1f * (Projectile.timeLeft + 10) / 40f, SpriteEffects.None, 0f);
				}
            }
			return false;
        }
		public override void CutTiles()
        {
            Vector2 unit = Projectile.velocity;
            Terraria.Utils.PlotTileLine(vector3, vector3 + unit * Distance, (Projectile.width + 16) * Projectile.scale,  new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 unit = Projectile.velocity;
            float point = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * Distance, 14, ref point);
        }
	}
}
