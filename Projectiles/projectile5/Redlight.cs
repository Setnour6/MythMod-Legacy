﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;


namespace MythMod.Projectiles.projectile5
{
    public class Redlight : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("红光柱");
		}
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 8000;
            projectile.tileCollide = false;
        }
        float r = 0;
        private Vector2 v0;
        private float b = 0;
        
        public override void AI()
        {
            if (projectile.timeLeft == 7999)
            {
                projectile.timeLeft = Main.rand.Next(600, 700);
                b = Main.rand.NextFloat(0, 100f);
                v0 = projectile.Center;
            }
            if (projectile.timeLeft > 300 && r < 200)
            {
                r += 5f;
            }
            if (projectile.timeLeft > 200 && projectile.timeLeft % 4 == 1)
            {
                int h = Projectile.NewProjectile(projectile.Center.X + Main.rand.NextFloat(-50f,50f), projectile.Center.Y - 1800, 0, Main.rand.NextFloat(7f, 8f), mod.ProjectileType("floatLantern5"), 50, 0f, Main.myPlayer, 0, 0);
                Main.projectile[h].timeLeft = 360;
                Main.projectile[h].scale = Main.rand.NextFloat(1f, 2.7f);
            }
            if (projectile.timeLeft < 200 && r > 2.5f)
            {
                r -= 2.5f;
            }
            int Dx = (int)(r * 1.5f);
            int Dy = (int)(r * 1.5f);

            if(v0 != Vector2.Zero)
            {
                projectile.position = v0 - new Vector2(Dx, Dy) / 2f;
            }

            projectile.width = Dx;
            projectile.height = Dy;
            /* if(projectile.timeLeft >= 200 && projectile.timeLeft <= 1000 && projectile.timeLeft % 100 == 0)
             {
                 double io = Main.rand.NextFloat(0, 10f);
                 for (int i = 0; i < 16; i++)
                 {
                     Vector2 v = new Vector2(0,8).RotatedBy(i * Math.PI / 8d + io);
                     Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("DarkFlameball2"), 40, 0f, Main.myPlayer, 0f, 0f);
                 }
             }
             for (int k = 0;k < r;k++)
             {
                 Vector2 v = projectile.Center + new Vector2(0, r).RotatedByRandom(Math.PI * 2);
                 int l = Dust.NewDust(v, 0, 0, mod.DustType("DarkF"), 0, 0, 0, default(Color), 2f);
                 Main.dust[l].velocity.X = 0;
                 Main.dust[l].velocity.Y = 0;
                 Main.dust[l].noGravity = true;
             }*/
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    projectile.Kill();
			return false;
		}
        /*public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 16; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(0,14)).RotatedByRandom(Math.PI);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("DarkFlameball"), 40, 0f, Main.myPlayer, 0f, 0f);
            }
            for (int a = 0; a < 180; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("DarkF"), v.X, v.Y, 0, default(Color), Main.rand.NextFloat(1.1f, 2.2f));
                Main.dust[num].velocity = v;
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
        }*/
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 900);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序

            for (int k = 0; k < 180; k++)
            {
                float alpha = 1f;
                if (r <= 10)
                {
                    alpha = (10 - r) / 10f + 0.2f;
                }
                else
                {
                    alpha = 0.2f;
                }
                var factor = k / 18f;
                var color = Color.Lerp(Color.White, Color.Red, 0.2f);
                var w = MathHelper.Lerp(1f, 0.05f, alpha);
                bars.Add(new CustomVertexInfo(projectile.Center + new Vector2(r, -1800 + k * 20), color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.Center + new Vector2(-r, -1800 + k * 20), color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }


            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f, Color.White, new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffect2.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffect2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f + b);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorRed;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("UIImages/FogTraceBeta");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffect2.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/Redlight"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + new Vector2(0, -2560), new Rectangle?(new Rectangle(128 - (int)(r * 0.64), 0, (int)(r * 1.28), 5120)), new Color(r / 10f, 0, 0, 0), 0, new Vector2((int)(r * 0.64), 128), base.projectile.scale, SpriteEffects.None, 1f);
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