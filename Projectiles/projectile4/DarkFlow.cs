using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using TemplateMod2.Utils;


namespace MythMod.Projectiles.projectile4
{
    public class DarkFlow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DarkFlow");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 60;
            projectile.penetrate = 1;
            projectile.scale = 1;

            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int y = 0; y < 40; y++)
            {
                int num90 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - new Vector2(4, 4), 4, 4, 64, 0f, 0f, 100, default(Color), Main.rand.NextFloat(2.8f, 4.5f));
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity = new Vector2(Main.rand.NextFloat(2.0f, 2.5f), Main.rand.NextFloat(1.8f, 2.5f)).RotatedByRandom(Math.PI * 2d);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        public override void AI()
        {
            /*if (Main.myPlayer == projectile.owner)
            {
                var projectileToMouse = Vector2.Normalize(Main.MouseWorld - projectile.Center) * 16;
                projectile.velocity = projectileToMouse;

                for (int i = projectile.oldPos.Length - 1; i > 0; --i)
                    projectile.oldRot[i] = projectile.oldRot[i - 1];
                projectile.oldRot[0] = projectile.rotation;
            }*/
            base.projectile.rotation = (float)(Math.Atan2(base.projectile.velocity.Y, base.projectile.velocity.X) + Math.PI * 0.25);
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(base.projectile.damage, base.projectile.knockBack, base.projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        base.projectile.penetrate--;
                    }
                }
            }
            projectile.velocity *= 0.96f;
            if (K >= 40)
            {
                K *= 0.96f;
            }
            if (K <= 6)
            {
                K *= 1.05f;
            }
            if(projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            K += Main.rand.NextFloat(-0.025f, 0.025f);
            float num2 = projectile.Center.X;
            float num3 = projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(base.projectile.damage, base.projectile.knockBack, base.projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        base.projectile.penetrate--;
                        NPC target = Main.npc[j];
                    }
                }
            }
            if (flag)
            {
                float num8 = 50f;
                Vector2 vector1 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                projectile.velocity.X = (projectile.velocity.X * 20f + num9) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + num10) / 21f;
                if(projectile.velocity.Length() > 0.005f)
                {
                    projectile.velocity *= 0.95f;
                }

            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

            // 把所有的点都生成出来，按照顺序
            for (int i = 2; i < projectile.oldPos.Length - 1; ++i)
            {
                if (projectile.oldPos[i] == Vector2.Zero) break;
                //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                int width = 30;
                var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var alpha = i / (float)projectile.oldPos.Length * (float)Math.Log10((60 - projectile.timeLeft) + 1);
                var factor = i / (float)projectile.oldPos.Length;
                var color = Color.Lerp(Color.White, Color.Red, factor);
                var w = MathHelper.Lerp(1f, 0.05f, alpha);

                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + projectile.velocity * 2, Color.White, new Vector3(0, 0.5f, 1));
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
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
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
                MythMod.DefaultEffectDarkRedGold2.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectDarkRedGold2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorDarkRedGold;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectDarkRedGold2.CurrentTechnique.Passes[0].Apply();


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