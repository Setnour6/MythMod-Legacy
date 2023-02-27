using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.IO;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.Yasitaya
{
    public class BloodSwordGas : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodBlade");
        }
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 138;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 1081;
            projectile.penetrate = 1;
            projectile.scale = 1;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private bool Finish = false;
        private bool Ini = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f - 1f / projectile.velocity.Length(), 1f - 1f / projectile.velocity.Length(), 1f - 1f / projectile.velocity.Length(), 0));
        }
        private float Cl = 0;
        public override void AI()
        {
            if(Ini)
            {
                projectile.timeLeft = (int)(1080 + projectile.ai[0]);
                Cl = projectile.ai[0];
                Ini = false;
                
            }
            if(Finish)
            {
                projectile.velocity.Y += 2f;
                projectile.hostile = true;
            }

            if(projectile.timeLeft == 1079)
            {
                for (int i = 0; i < 90; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                    int num5 = Dust.NewDust(new Vector2(projectile.Top.X, projectile.Top.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(projectile.damage)));
                    Main.dust[num5].velocity = v;
                }
            }
            int num = Dust.NewDust(projectile.Center - new Vector2(4, 4) + new Vector2(0, 12).RotatedBy(projectile.timeLeft / 4f), 2, 2, mod.DustType("RedEffect2"), 0, 0, 0, default(Color), 1f);
            Main.dust[num].noGravity = false;
            Main.dust[num].velocity *= 0;
            int num20 = Dust.NewDust(projectile.Center - new Vector2(4, 4) - new Vector2(0, 12).RotatedBy(projectile.timeLeft / 4f), 2, 2, mod.DustType("RedEffect2"), 0, 0, 0, default(Color), 1f);
            Main.dust[num20].noGravity = false;
            Main.dust[num20].velocity *= 0;
            int num21 = Dust.NewDust(projectile.Center - new Vector2(4, 4), 2, 2, mod.DustType("RedEffect2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num21].velocity *= 0;
            int num22 = Dust.NewDust(projectile.Center - new Vector2(4, 4) + new Vector2(0, Main.rand.NextFloat(0, 8f)).RotatedByRandom(Math.PI * 2), 2, 2, mod.DustType("RedEffect2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 90; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(16 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(projectile.Bottom.X, projectile.Bottom.Y), 0, 0, 183, 0f, 0f, 100, Color.White, (float)(1f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.3f;
            }
            for (int i = 0; i <= 32; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 40f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 40f;
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("RedGemDust"), 0, 0, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
            }
        }
        private int Dely = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            if (projectile.timeLeft <= 1079)
            {
                Dely = (1080 - projectile.timeLeft) * 3;
                if (Dely > 138)
                {
                    Dely = 138;
                    Finish = true;
                    projectile.tileCollide = true;
                }
                Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, Dely)), new Color(0.8f, 0.8f, 0.8f, 0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            }
            else
            {
                Main.spriteBatch.Draw(mod.GetTexture("NPCs/Yasitaya/RedPixel"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY - 2000), new Rectangle?(new Rectangle(0, 0, 10, 4000)), new Color(0.8f * (projectile.timeLeft - 1080) / Cl, 0.8f * (projectile.timeLeft - 1080) / Cl, 0.8f * (projectile.timeLeft - 1080) / Cl, 0), 0, new Vector2(5, 5), base.projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < projectile.oldPos.Length; ++i)
            {
                if (projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 30;
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, factor);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(19, 130) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(19, 130) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
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
                mod.GetEffect("Effects/Trail").Parameters["uTransform"].SetValue(model * projection);
                mod.GetEffect("Effects/Trail").Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = mod.GetTexture("NPCs/Yasitaya/heatmapRed");
                Main.graphics.GraphicsDevice.Textures[1] = mod.GetTexture("NPCs/Yasitaya/Lightline");
                Main.graphics.GraphicsDevice.Textures[2] = mod.GetTexture("NPCs/Yasitaya/FogTrace");
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                mod.GetEffect("Effects/Trail").CurrentTechnique.Passes[0].Apply();


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