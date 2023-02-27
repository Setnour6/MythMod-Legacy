using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	public class VinePro : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.aiStyle = 7;
			base.projectile.friendly = true;
			base.projectile.penetrate = 100;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft *= 10;
			Main.projHook[base.projectile.type] = true;
		}
		public override bool PreAI()
		{
			if (Main.player[base.projectile.owner].dead || Main.player[base.projectile.owner].stoned || Main.player[base.projectile.owner].webbed || Main.player[base.projectile.owner].frozen)
			{
				base.projectile.Kill();
				return false;
			}
			Vector2 mountedCenter = Main.player[base.projectile.owner].MountedCenter;
			Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
			float num = mountedCenter.X - vector.X;
			float num2 = mountedCenter.Y - vector.Y;
			float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
			base.projectile.rotation = (float)Math.Atan2((double)num2, (double)num) - 1.57f;
			if (base.projectile.ai[0] == 0f)
			{
				if (num3 > 400f)
				{
					base.projectile.ai[0] = 1f;
				}
				Vector2 value = base.projectile.Center - new Vector2(5f);
				Vector2 value2 = base.projectile.Center + new Vector2(5f);
				Point point = Utils.ToTileCoordinates(value - new Vector2(16f));
				Point point2 = Utils.ToTileCoordinates(value2 + new Vector2(32f));
				int num4 = point.X;
				int num5 = point2.X;
				int num6 = point.Y;
				int num7 = point2.Y;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int i = num4; i < num5; i++)
				{
					int j = num6;
					while (j < num7)
					{
						if (Main.tile[i, j] == null)
						{
							Main.tile[i, j] = new Tile();
						}
						Vector2 vector2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						if (value.X + 10f > vector2.X && value.X < vector2.X + 16f && value.Y + 10f > vector2.Y && value.Y < vector2.Y + 16f && Main.tile[i, j].nactive() && (Main.tileSolid[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 314) && (base.projectile.type != 403 || Main.tile[i, j].type == 314))
						{
							if (Main.player[base.projectile.owner].grapCount < 3)
							{
								Main.player[base.projectile.owner].grappling[Main.player[base.projectile.owner].grapCount] = base.projectile.whoAmI;
								Main.player[base.projectile.owner].grapCount++;
							}
							if (Main.myPlayer == base.projectile.owner)
							{
								int num8 = 0;
								int num9 = -1;
								int num10 = 92500;
								int num11 = 1;
								for (int k = 0; k < 1000; k++)
								{
									if (Main.projectile[k].active && Main.projectile[k].owner == base.projectile.owner && Main.projectile[k].type == base.projectile.type)
									{
										if (Main.projectile[k].timeLeft < num10)
										{
											num9 = k;
											num10 = Main.projectile[k].timeLeft;
										}
										num8++;
									}
								}
								if (num8 > num11)
								{
									Main.projectile[num9].Kill();
								}
							}
							WorldGen.KillTile(i, j, true, true, false);
							Main.PlaySound(0, i * 16, j * 16, 1, 1f, 0f);
							base.projectile.velocity.X = 0f;
							base.projectile.velocity.Y = 0f;
							base.projectile.ai[0] = 2f;
							base.projectile.position.X = (float)(i * 16 + 8 - base.projectile.width / 2);
							base.projectile.position.Y = (float)(j * 16 + 8 - base.projectile.height / 2);
							base.projectile.damage = 0;
							base.projectile.netUpdate = true;
							if (Main.myPlayer == base.projectile.owner)
							{
								NetMessage.SendData(13, -1, -1, null, base.projectile.owner, 0f, 0f, 0f, 0, 0, 0);
								break;
							}
							break;
						}
						else
						{
							j++;
						}
					}
					if (base.projectile.ai[0] == 2f)
					{
						return false;
					}
				}
				return false;
			}
			if (base.projectile.ai[0] == 1f)
			{
				float num12 = 20f;
				if (num3 < 24f)
				{
					base.projectile.Kill();
				}
				num3 = num12 / num3;
				num *= num3;
				num2 *= num3;
				base.projectile.velocity.X = num;
				base.projectile.velocity.Y = num2;
				return false;
			}
			if (base.projectile.ai[0] == 2f)
			{
				int num13 = (int)(base.projectile.position.X / 16f) - 1;
				int num14 = (int)((base.projectile.position.X + (float)base.projectile.width) / 16f) + 2;
				int num15 = (int)(base.projectile.position.Y / 16f) - 1;
				int num16 = (int)((base.projectile.position.Y + (float)base.projectile.height) / 16f) + 2;
				if (num13 < 0)
				{
					num13 = 0;
				}
				if (num14 > Main.maxTilesX)
				{
					num14 = Main.maxTilesX;
				}
				if (num15 < 0)
				{
					num15 = 0;
				}
				if (num16 > Main.maxTilesY)
				{
					num16 = Main.maxTilesY;
				}
				bool flag = true;
				for (int l = num13; l < num14; l++)
				{
					for (int m = num15; m < num16; m++)
					{
						if (Main.tile[l, m] == null)
						{
							Main.tile[l, m] = new Tile();
						}
						Vector2 vector3;
						vector3.X = (float)(l * 16);
						vector3.Y = (float)(m * 16);
						if (base.projectile.position.X + (float)(base.projectile.width / 2) > vector3.X && base.projectile.position.X + (float)(base.projectile.width / 2) < vector3.X + 16f && base.projectile.position.Y + (float)(base.projectile.height / 2) > vector3.Y && base.projectile.position.Y + (float)(base.projectile.height / 2) < vector3.Y + 16f && Main.tile[l, m].nactive() && (Main.tileSolid[(int)Main.tile[l, m].type] || Main.tile[l, m].type == 314 || Main.tile[l, m].type == 5))
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					base.projectile.ai[0] = 1f;
					return false;
				}
				if (Main.player[base.projectile.owner].grapCount < 10)
				{
					Main.player[base.projectile.owner].grappling[Main.player[base.projectile.owner].grapCount] = base.projectile.whoAmI;
					Main.player[base.projectile.owner].grapCount++;
					return false;
				}
			}
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = base.mod.GetTexture("Projectiles/缠绕藤蔓Pro_Chain");
			Vector2 vector = base.projectile.Center;
			Vector2 mountedCenter = Main.player[base.projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = null;
			Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num = (float)texture.Height;
			Vector2 vector2 = mountedCenter - vector;
			float rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(vector.X) && float.IsNaN(vector.Y))
			{
				flag = false;
			}
			if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
			{
				flag = false;
			}
			while (flag)
			{
				if ((double)vector2.Length() < (double)num + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 value = vector2;
					value.Normalize();
					vector += value * num;
					vector2 = mountedCenter - vector;
					Color color = Lighting.GetColor((int)vector.X / 16, (int)((double)vector.Y / 16.0));
					color = base.projectile.GetAlpha(color);
					Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
				}
			}
		}
	}
}
