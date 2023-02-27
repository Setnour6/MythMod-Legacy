using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile5
{
    public class GoldLanternLine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灯笼须");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.light = 0.1f;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;

            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            Vector2 v = player.Center - projectile.Center;
            v = v / (v.Length() + 1) / (v.Length() + 1) * 100;
            Vector2 v2 = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.2f,0.2f));
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v2.X, v2.Y, mod.ProjectileType("GoldLanternLine2"), 2, 0, Main.myPlayer, 0, 0);
            projectile.velocity.Y += 0.2f;
            projectile.velocity += v;
            if(sca < 1)
            {
                sca += 0.03f;
            }
            else
            {
                sca = 1;
            }
            if(Wid < 12f)
            {
                Wid += 0.2f;
            }
            else
            {
                Wid = 12;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            for(int j = 0;j < 10; j++)
            {
                Vector2 v2 = projectile.velocity.RotatedBy(j / 5f * Math.PI);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v2.X, v2.Y, mod.ProjectileType("GoldLanternLine3"), 0, 0, Main.myPlayer, 0, 0);
            }
            base.Kill(timeLeft);
        }
        private float Wid = 0;
        private float sca = 0;
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < projectile.oldPos.Length; ++i)
            {
                if (projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = (int)(Wid);
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {
                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 18, Color.White,
                    new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffect2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorGoldYellow;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("UIImages/Lightline2");
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

                x += 0.01f;
                float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 0.8f * sca, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.8f * sca, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 0.8f * sca, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 0.8f * sca, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, x * 6f, new Vector2(512f, 512f), (M + K) * 0.8f * sca, SpriteEffects.None, 0f);
                spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, -x * 6f, new Vector2(512f, 512f), (float)Math.Sqrt(M * M + K * K) * 0.8f * sca, SpriteEffects.None, 0f);
            }
        }
        private float x = 0;

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
