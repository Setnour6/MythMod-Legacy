using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;

namespace MythMod.Projectiles.CorruptMoth
{
    public class ButterflyDream : ModProjectile
    { public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("蓝蝶幻梦");
            ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
            Main.projFrames[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            base.Projectile.width = 24;
            base.Projectile.height = 24;
            base.Projectile.netImportant = true;
            base.Projectile.friendly = true;
            base.Projectile.penetrate = 3;
            base.Projectile.timeLeft = 900;
            base.Projectile.tileCollide = true;
            base.Projectile.usesLocalNPCImmunity = false;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
       
        private float K = 10;
        public override void AI()
		{
            Projectile.spriteDirection = Projectile.velocity.X > 0 ? -1 : 1;
            float num2 = base.Projectile.Center.X;
			float num3 = base.Projectile.Center.Y;
			float num4 = 400f;
            
            if(K >= 40)
            {
                K *= 0.96f;
            }
            if (K <= 6)
            {
                K *= 1.05f;
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            bool flag = false;
            if(Projectile.timeLeft == 899)
            {
                Projectile.frame = Main.rand.Next(2);
                Projectile.timeLeft -= Main.rand.Next(29);
            }
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 20);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4 && Projectile.timeLeft > 120)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                    if (num7 < 20)
                    {
                        Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f,1.15f)), Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                        NPC target = Main.npc[j];
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag && Projectile.timeLeft % 30 > 15)
			{
				float num8 = 5f;
				Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 10f + num9) / 11f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 10f + num10) / 11f;
			}
            else
            {
                Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.Next(-20000, 20000) / 400000f);
            }
            if (Projectile.timeLeft < 120)
			{
                Projectile.tileCollide = false;
				flag = false;
                Projectile.alpha = (int)(255 - 255 * (Projectile.timeLeft / 120f));
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f * (Projectile.timeLeft / 120f));
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f * (Projectile.timeLeft / 120f));
                    }
                }
            }
            else
            {
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f);
                    }
                }
            }
            if (!flag)
			{
            }
			if (base.Projectile.frame > 2)
			{
				base.Projectile.frame = 0;
			}
			if(base.Projectile.timeLeft % 10 == 0)
			{
				base.Projectile.frame++;
			}
		}
        private int y = 0;
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 18; i++)
            {
                Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 0);
        }
        public override void PostDraw(Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < Projectile.oldPos.Length; ++i)
            {
                if (Projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 30;
                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)Projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Blue, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width + new Vector2(13, 13) - Projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width + new Vector2(13, 13) - Projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(Projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
                triangleList.Add(bars[1]);
                triangleList.Add(vertex);
                for (int i = 0; i < bars.Count - 2; i += 2)
                {
                    triangleList.Add(bars[i]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 1]);

                    triangleList.Add(bars[i + 1]);
                    triangleList.Add(bars[i + 2]);
                    triangleList.Add(bars[i + 3]);
                }


                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                // 干掉注释掉就可以只显示三角形栅格
                //RasterizerState rasterizerState = new RasterizerState();
                //rasterizerState.CullMode = CullMode.None;
                //rasterizerState.FillMode = FillMode.WireFrame;
                //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                // 把变换和所需信息丢给shader
                MythMod.DefaultEffectB2.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectB2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorBlueD;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectB2.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
        }


        // 自定义顶点数据结构，注意这个结构体里面的顺序需要和shader里面的数据相同
        private struct CustomVertexInfo : IVertexType
        {
            private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement[3]
            {
                new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
                new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
            });
            public Vector2 Position;
            public Color Color;
            public Vector3 TexCoord;

            public CustomVertexInfo(Vector2 position, Color color, Vector3 texCoord)
            {
                this.Position = position;
                this.Color = color;
                this.TexCoord = texCoord;
            }

            public VertexDeclaration VertexDeclaration
            {
                get
                {
                    return _vertexDeclaration;
                }
            }
        }
    }
}
