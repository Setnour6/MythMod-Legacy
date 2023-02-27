﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 藤蔓散裂 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		private int num;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("藤蔓散裂");
			Main.projFrames[base.Projectile.type] = 1;
		}

        public override void SetDefaults()
        {
            base.Projectile.extraUpdates = 3;
            base.Projectile.width = 8;
            base.Projectile.height = 8;
            base.Projectile.hostile = true;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 300;
            base.Projectile.alpha = 255;
            this.CooldownSlot = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 60;
        }
        public override void AI()
		{
			if (initialization)
            {
				int num = Main.rand.Next(0,100000);
                X = Main.rand.Next(0,2000) / 1000f;
				initialization = false;
            }
			if(base.Projectile.timeLeft < 75)
			{
				if(num >= 50000)
				{
			        Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / -20f);
			    	Projectile.velocity *= 0.975f;
			    	//int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.2f * (float)base.projectile.timeLeft / 75f + 0.2f);
		    	    //Main.dust[r].velocity.X = 0;
		    	    //Main.dust[r].velocity.Y = 0;
		    	    //Main.dust[r].noGravity = true;
                	Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
				}
				else
				{
					Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / 20f);
			    	Projectile.velocity *= 0.975f;
			    	//int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.2f * (float)base.projectile.timeLeft / 75f + 0.2f);
		    	    //Main.dust[r].velocity.X = 0;
		    	    //Main.dust[r].velocity.Y = 0;
		    	   // Main.dust[r].noGravity = true;
                	Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
				}
			}
			else
			{
				X += 1 / 30f;
			    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / 60f * (float)Math.Sin(X * Math.PI));
			    //int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.4f);
			    //Main.dust[r].velocity.X = 0;
			    //Main.dust[r].velocity.Y = 0;
			    //Main.dust[r].noGravity = true;
            	Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
			}
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

                int width = 15;
                var normalDir = Projectile.oldPos[i - 1] - Projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)Projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Green, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * width + new Vector2(4, 4) - Projectile.velocity, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Projectile.oldPos[i] + normalDir * -width + new Vector2(4, 4) - Projectile.velocity, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(Projectile.velocity), Color.White, new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffectB.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectB.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorGreen;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = Mod.GetTexture("UIImages/Lightline2");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectB.CurrentTechnique.Passes[0].Apply();


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
